using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdMobManager : MonoBehaviour
{
    public bool isTestMode;
    //광고를 띄울건가 안띄울건가
    public Text LogText;
    //확인용 로그를 띄우기 위한 텍스트
    public Button FrontAdsBtn, RewardAdsBtn;
    //전면광고와 보상광고 버튼
    string scenename = " ";


    void Awake()
    {
        LoadBannerAd();
        LoadFrontAd();
        LoadRewardAd();
    }

    void Start()
    {
        ToggleBannerAd(true);
    }

    void Update()
    {
        FrontAdsBtn.interactable = frontAd.IsLoaded();
        // 전면 광고 버튼 누르면 텍스트 활성화
        RewardAdsBtn.interactable = rewardAd.IsLoaded();
        // 보상 광고 버튼 누르면 텍스트 활성화
    }



    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().AddTestDevice("").Build(); // ID here
        // 이거 안하면 정지 당한다고 한다
    }


    #region 배너 광고
    const string bannerTestID = ""; // ID here
    const string bannerID = ""; // ID here
    BannerView bannerAd;
    // 배너 광고 ID와 배너뷰

    void LoadBannerAd()
    {
        bannerAd = new BannerView(isTestMode ? bannerTestID : bannerID, AdSize.SmartBanner, AdPosition.Bottom);
        // 테스트 ID면 배너 테스트 ID를, 아니면 배너 ID 사용 & 밑에다가 배너 광고
        bannerAd.LoadAd(GetAdRequest());
        // 광고 생성
        ToggleBannerAd(false);
        // 원할 때 광고 나오도록 설정
    }

    public void ToggleBannerAd(bool b)
    {
        if (b) bannerAd.Show();
        else bannerAd.Hide();
        // Bool값이 맞으면 보여주고 아니면 숨기고
    }
    #endregion

    #region 전면 광고
    const string frontTestID = ""; // ID here
    const string frontID = ""; // ID here
    InterstitialAd frontAd;
    // 전면 광고 ID와 배너뷰

    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(isTestMode ? frontTestID : frontID);
        // 배너 광고와 같은 원리
        frontAd.LoadAd(GetAdRequest());
        // 광고 생성
        frontAd.OnAdClosed += (sender, e) =>
        {
            LogText.text = "전면광고 성공";
        };
        // 성공하면 텍스트 호출
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
    // 버튼 누르면 광고 생성
    #endregion

    #region 보상 광고
    const string rewardTestID = ""; // ID here
    const string rewardID = ""; // ID here
    RewardedAd rewardAd;
    // 보상 광고 ID와 배너뷰


    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(isTestMode ? rewardTestID : rewardID);
        // 배너 광고와 같은 원리
        rewardAd.LoadAd(GetAdRequest());
        // 광고 생성
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            RewardManager.instance.AddCount(1);
            LogText.text = "보상 광고 성공";
        };
        // 성공하면 텍스트 호출
    }

    public void ShowRewardAd()
    {
        rewardAd.Show();
        LoadRewardAd();
    }
    // 버튼 누르면 광고 생성
    #endregion
}
