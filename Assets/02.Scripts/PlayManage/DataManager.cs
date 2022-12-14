using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    int Money = 0; //돈
    public Text Gold;
    public GameObject Canvasobj; //돈보여주기
    public GameObject[] Cannon; //대포들 프리팹
     public int nowCannon =0; //현재 대포가 몇번째 대포인지
    [HideInInspector] public bool[] CannonBoolen; //내가 가지고 있는 대포확인용 위에 대포프리팹과 같아야함


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Money = PlayerPrefs.GetInt("Money"); //시작시 돈 불러오기
        nowCannon = PlayerPrefs.GetInt("NowCannon");
        
    }

    private void Start()
    {       
        if (CannonCheck(0) == false)
        {
            CannonBoolenSave(0);
        }
        //PlayerPrefs.DeleteAll(); //초기화용 저장변수들 리셋!
        Canvasobj.SetActive(false);
        GetMoney();
        CannonBoolen = new bool[Cannon.Length];
        for (int i = 0; i < CannonBoolen.Length; i++) //시작시 가지고 있는 대포들 불러오기
        {
            CannonBoolen[i] = CannonCheck(i);
        }
    }

    public void GetMoney() //돈 보여주기
    {
        if(Canvasobj.activeSelf == false)
        {
            Canvasobj.SetActive(true);
        }
        Gold.text = "Gold : " + Money.ToString();
    }
    public void MoneyAdd(int add) //돈 추가하기
    {
        Money += add;
        PlayerPrefs.SetInt("Money", Money);
        Debug.Log(Money);
    }
    public bool MoneySpend(int Gold, int num) //대포 사기 및 어떤 대포인지 
    {
        if (Money - Gold >= 0)
        {
            Money -= Gold;
            PlayerPrefs.SetInt("Money", Money);
            CannonBoolenSave(num);
            return true;
        }
        else
        {
            return false;
        }

    }
    public void NowCannonsave()
    {
        PlayerPrefs.SetInt("NowCannon", nowCannon);
    }
    public bool CannonCheck(int i) //대포를 가지고 있는지 확인용
    {
        int BoolenNum = PlayerPrefs.GetInt("Cannon" + i.ToString());
        if (BoolenNum == 0)
        {
            return false;
        }
        else if (BoolenNum == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void CannonBoolenSave(int i) //대포를 샀을 때 이건 샀어요 하고 저장하기
    {
        PlayerPrefs.SetInt("Cannon" + i.ToString(), 1);
        nowCannon = i;
    }
    public int BestScoreCheck(int score) //최고점수 측정용
    {
        int Best = PlayerPrefs.GetInt("Score");
        if (Best < score)
        {
            Best = score;
            PlayerPrefs.SetInt("Score", Best);
        }
        return Best;
    }

    public float CannonShotDelay() //대포 발사 딜레이 관리
    {
        float Delay =1.5f;
        switch (nowCannon)
        {
            case 0:
                Delay = 1.5f;
                break;
            case 1:
                Delay = 0.5f;
                break;
            case 2:
                Delay = 1f;
                break;
            case 3:
                Delay = 1f;
                break;
            case 4:
                Delay = 1.5f;
                break;
        }
        return Delay;

    }

    public void CannonScale(GameObject bullet) //대포알 크기, 무게정하기
    {
        if(nowCannon == 0)
        {
            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            bullet.GetComponent<Rigidbody>().mass = 10;
        }else if (nowCannon ==1)
        {
            bullet.transform.localScale = new Vector3(1, 1, 1);
            bullet.GetComponent<Rigidbody>().mass = 5;
        }else if (nowCannon == 2)
        {
            bullet.transform.localScale = new Vector3(1, 1, 1);
            bullet.GetComponent<Rigidbody>().mass = 5;
        }else if(nowCannon == 3)
        {
            bullet.transform.localScale = new Vector3(1, 1, 1);
            bullet.GetComponent<Rigidbody>().mass = 5;
        }else if(nowCannon == 4)
        {
            bullet.transform.localScale = new Vector3(1, 1, 1);
            bullet.GetComponent<Rigidbody>().mass = 5;
        } 
    }
    public Vector3 LocalScales() //크기
    {
        Vector3 xyz = new Vector3(0,0,0);
        switch (nowCannon)
        {
            case 0:
                xyz = new Vector3(0.5f, 0.5f, 0.5f);             
                break;
            case 1:
                xyz = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 2:
                xyz = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 3:
                xyz = new Vector3(0.2f, 0.2f, 0.2f);
                break;
            case 4:
                xyz = new Vector3(2f, 2f, 2f);
                break;
        }
        return xyz;
    }

    public float MassCtrl() //무게
    {
        float mass = 0;
        switch (nowCannon)
        {
            case 0:
                mass = 5f;
                break;
            case 1:
                mass = 7f;
                break;
            case 2:
                mass = 10f;
                break;
            case 3:
                mass = 3f;
                break;
            case 4:
                mass = 20f;
                break;
        }
        return mass;
    }
    public int Damages() //대포마다 대미지 정하기
    {
        int damage = 1;
        switch (nowCannon)
        {
            case 0:
                damage = 1;
                break;
            case 1:
                damage = 1;
                break;
            case 2:
                damage = 2;
                break;
            case 3:
                damage = 5;
                break;
            case 4:
                damage = 3;
                break;
        }
        return damage;
    }
    public float CannonVelocity() //속도
    {
        float velocity =30f;
        switch (nowCannon)
        {
            case 0:
                velocity = 30f;
                break;
            case 1:
                velocity = 30f;
                break;
            case 2:
                velocity = 30f;
                break;
            case 3:
                velocity = 30f;
                break;
        }
        return velocity;
    }

    public bool MemoryGet(int buildnum)
    {
        int a = PlayerPrefs.GetInt("Memory" + buildnum.ToString());
        if(a == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void MemorySet(int buildnum)
    {
        PlayerPrefs.SetInt("Memory" + buildnum.ToString(), 1);
    }

    public int GetAdCount()
    {
        return PlayerPrefs.GetInt("AdCount"); 
    }
    public void SetAdCount(int count)
    {
        PlayerPrefs.SetInt("AdCount",count);
    }
}
