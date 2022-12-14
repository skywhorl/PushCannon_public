using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;

public class GoogleManager : MonoBehaviour
{
    public Text LogText;
    // 로그인한 ID를 표시할 텍스트
    public InputField HighScoreInput;
    // 점수를 넣을 인풋필드
    public InputField PiecesInput;
    // 업적 해금을 위한 누적된 얻은 조각들의 수

    int earned_pieces;
    int highscore;


    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        // 로그인을 위한 플랫폼 활성화

        LogIn();
        // 시작하자마자 로그인 되도록 설정
    }

    private void Start()
    {
        earned_pieces = PlayerPrefs.GetInt("Money");
        highscore = PlayerPrefs.GetInt("Score");
    }
    void Update()
    {
        earned_pieces = int.Parse(PiecesInput.text);
        Debug.Log(earned_pieces);

        if (earned_pieces >= 10)
        {
            Social.ReportProgress(GPGSIds.achievement_aim_to_rich, 100, (bool success) => { });
        }

        if (earned_pieces >= 100)
        {
            Social.ReportProgress(GPGSIds.achievement_aim_to_richer, 100, (bool success) => { });
        }

        if (earned_pieces >= 500)
        {
            Social.ReportProgress(GPGSIds.achievement_aim_to_richest, 100, (bool success) => { });
        }

        if (earned_pieces >= 1000)
        {
            Social.ReportProgress(GPGSIds.achievement_the_richest_person, 100, (bool success) => { });
        }
    }

    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success) LogText.text = Social.localUser.id + " \n " + Social.localUser.userName;
            else LogText.text = "구글 로그인 실패";
        });
        // 로그인
    }

    public void LogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        LogText.text = "구글 로그아웃";
        // 로그아웃
    }

    public void ShowAchievementUI() => Social.ShowAchievementsUI();
    // 모든 업적 공개

    public void ShowLeaderboardUI() => Social.ShowLeaderboardUI();
    // 모든 리더보드 공개
    public void SendtoLeaderBoard() => Social.ReportScore(highscore, GPGSIds.leaderboard_destroyed_cube_in_one_game, (bool success) => { });
}