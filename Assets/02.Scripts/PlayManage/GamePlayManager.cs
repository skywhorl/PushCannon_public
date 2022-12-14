using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayManager : MonoBehaviour
{
    public enum GameStatus
    {
        Ready, GameStart, END
    }
    public GameStatus status;

    [SerializeField] float timer; //대기 시간
    [SerializeField] Text Times;
    [SerializeField] Text CountResult;
    [SerializeField] GameObject ResultWindowPanel; //정산창

    public static GamePlayManager instance;
    public int countFragments = 0; //최종 갯수
    public float playTime = 0; //플레이타임 설정

    public Text playTimer;
    public Text fragments;
    public Text totalGoldText;
    public Text BestScore;
    [SerializeField] Text appendCoinText;
    public int totalGold; //최종 골드
    private bool IsStart;
    private int playTimeText;
    private int countThree;

    public GameObject[] prefebs; //건물들
    public GameObject[] Clone = new GameObject[3]; //기본건물들

    public int nextCount; //버튼 몇번 눌렸는지
    public GameObject BulldingSpawnner; //건물들 이동담당및 부모

    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        // 설정 값 초기화
        //playTime = 20;
        nextCount = 0;
        IsStart = true;
        playTimer.gameObject.SetActive(false);
        Times.gameObject.SetActive(true);
        fragments.gameObject.SetActive(false);
        countFragments = 0;
        ResultWindowPanel.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            Clone[i] = Instantiate(prefebs[0]);
            Clone[i].transform.parent = BulldingSpawnner.transform;
        }

        Clone[0].transform.position = new Vector3(-7.06f, 0, 0);
        Clone[1].transform.position = new Vector3(-0.85f, 0, 0);
        Clone[2].transform.position = new Vector3(5.59f, 0, 0);
        BulldingSpawnner.transform.position = new Vector3(-15, 0, 0);
        status = GameStatus.Ready;


    }


    void Update()
    {
        // 3을 센 후
        if (timer <= 0)
        {
            if (IsStart)
            {
                if (playTimer.gameObject.activeSelf == false)
                {
                    playTimer.gameObject.SetActive(true);
                }
                if (fragments.gameObject.activeSelf == false)
                {
                    fragments.gameObject.SetActive(true);
                }
                Times.gameObject.SetActive(false);
                status = GameStatus.GameStart;
            }
        }
        // 3을 세기
        else
        {
            timer -= Time.deltaTime;
            countThree = (int)timer + 1;
            Times.text = countThree.ToString();
            if (BulldingSpawnner != null)
            {
                if (BulldingSpawnner.transform.position.x < 0)
                {
                    BulldingSpawnner.transform.Translate(0.05f, 0, 0);
                }
            }
        }

        // 제한시간이 경과되었을 때
        if (status == GameStatus.GameStart)
        {
            if (playTime <= 0)
            {
                status = GameStatus.END;
                playTimer.gameObject.SetActive(false);
                fragments.gameObject.SetActive(false);
                ResultWindowPanel.SetActive(true);
                CountResult.text = "처리한 조각" + countFragments.ToString() + "개";
                appendCoinText.text = "총 모은 골드 : " + countFragments.ToString();
                BestScore.text = "최고 점수 : " + DataManager.instance.BestScoreCheck(countFragments).ToString();
                totalGold = countFragments;
                totalGoldText.text = "실질적으로 받는 골드: " + totalGold.ToString();
            }
            // 제한시간이 남았을 때
            else
            {
                playTime -= Time.deltaTime;
                playTimeText = (int)playTime;
                playTimer.text = "남은 시간 : " + playTimeText.ToString();
            }

            fragments.text = "처리한 조각 : " + countFragments + "개";
        }

    }

    public void MainButton()
    {
        DataManager.instance.MoneyAdd(totalGold);
        DataManager.instance.GetMoney();
        SceneManager.LoadScene("Main");
    }

    public void RestartButton()
    {
        DataManager.instance.MoneyAdd(totalGold);
        SceneManager.LoadScene("Play");
    }

    public void NextButton()
    {
        if (status == GameStatus.GameStart)
        {
            nextCount++;
            status = GameStatus.Ready;
            timer = 3;
            Times.gameObject.SetActive(true);
            if (nextCount == 5) //특정건물
            {
                for (int i = 0; i < 3; i++)
                {
                    Clone[i].SetActive(false);
                }
                int r = Random.Range(1, 5);
                if (r == 1)
                {
                    Clone[0] = Instantiate(prefebs[1]);
                    Clone[0].transform.position = new Vector3(0, 0.34632f, 7.84805f);
                }
                else if (r == 2)
                {
                    Clone[0] = Instantiate(prefebs[2]);
                    Clone[0].transform.position = new Vector3(0, 0.25632f, 7.95975f);
                }
                else if (r == 3)
                {
                    Clone[0] = Instantiate(prefebs[3]);
                    Clone[0].transform.position = new Vector3(0, 0.25632f, 7.64884f);
                }
                else if (r == 4)
                {
                    Clone[0] = Instantiate(prefebs[4]);
                    Clone[0].transform.position = new Vector3(0, 0.25632f, 8.5f);
                }
                else if (r == 5)
                {
                    Clone[0] = Instantiate(prefebs[5]);
                    Clone[0].transform.position = new Vector3(0, 0.25632f, 8.6f);
                }
                Clone[0].transform.parent = BulldingSpawnner.transform;
                BulldingSpawnner.transform.position = new Vector3(-15, 0, 0);
            }
            else //기본건물
            {
                for (int i = 0; i < 3; i++)
                {
                    Clone[i].SetActive(false);
                    Clone[i] = Instantiate(prefebs[0]);
                    Clone[i].transform.parent = BulldingSpawnner.transform;
                }
                Clone[0].transform.position = new Vector3(-7.06f, 0, 0);
                Clone[1].transform.position = new Vector3(-0.85f, 0, 0);
                Clone[2].transform.position = new Vector3(5.59f, 0, 0);
                BulldingSpawnner.transform.position = new Vector3(-15, 0, 0);

            }
        }

    }
}
