using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    [SerializeField] GameObject buybutton;
    [SerializeField] GameObject adbutton;

    public static RewardManager instance; 
    // 어디서나 접근할 수 있도록 static으로 자기 자신을 저장할 변수
    public Text CountText;
    // 얼마나 광고를 봤는지 표시하는 Text
    [SerializeField]private int Count = 0;
    // 얼마나 광고를 봤는지 관리할 정수

    void Awake()
    {
        if (!instance)
        // 정적으로 자신을 체크
        { 
            instance = this;
            // 정적으로 자신을 저장
        }
    }
   
    private void Start()
    {
        Count = DataManager.instance.GetAdCount();
        buybutton.SetActive(false);
        CountText.text = Count + " / 10  ADS";
        if (DataManager.instance.CannonCheck(4)==true)
        {
            adbutton.SetActive(false);
            buybutton.SetActive(true);           
        }

    }
    private void Update()
    {
        if (Count == 10)
        {
            if(DataManager.instance.nowCannon != 4)
            {
                adbutton.SetActive(false);
                buybutton.SetActive(true);
            } 
        }
    }
    public void AddCount(int num)
    // 점수를 추가해줄 메소드
    {
        Count += num;
        // 점수 추가
        CountText.text = Count + " / 10  ADS";
        // 텍스트에 반영
        DataManager.instance.SetAdCount(Count);
    }
}
