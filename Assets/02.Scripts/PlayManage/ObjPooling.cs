using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    public static ObjPooling instance;
    public GameObject play_obj; //빈게임오브젝트(?)

    //대포탄
    public GameObject poolobj; //프리팹 생성할것
    public int poolAmount_0 = 10; //0번째를 생성할 양
    public List<GameObject> poolobj_0;

    //적(?)
    //public GameObject Enemy;
    //public int Enermycount;
    //public List<GameObject> EnemyList;
    //public GameObject EnemysParse;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
    }
    private void Start()
    {
        //EnemyList = new List<GameObject>();
        poolobj_0 = new List<GameObject>();

        for (int i = 0; i < poolAmount_0; i++)
        {
            GameObject obj_0 = Instantiate(poolobj);
            obj_0.transform.parent = play_obj.transform;
            obj_0.name = "Clone" + i;
            obj_0.SetActive(false);
            poolobj_0.Add(obj_0);
        }
        //for (int i = 0; i < Enermycount; i++)
        //{
        //    GameObject obj_0 = Instantiate(Enemy);
        //    obj_0.transform.parent = EnemysParse.transform;
        //    obj_0.name = "Clone" + i;
        //    obj_0.SetActive(false);
        //    EnemyList.Add(obj_0);
        //}
    }
    public void ResetObj()
    {
        for (int i = 0; i < poolobj_0.Count; i++)
        {
            poolobj_0[i].SetActive(false);
        }
    }
    //public GameObject GetPoolEnemy()
    //{
    //    for (int i = 0; i < EnemyList.Count; i++)
    //    {
    //        if (!EnemyList[i].activeInHierarchy) //obj.setactive가 false이면 실행
    //        {
    //            return EnemyList[i];
    //        }
    //    }
    //    return null;
    //}
    public GameObject GetPooledObj()
    {
        for (int i = 0; i < poolobj_0.Count; i++)
        {
            if (!poolobj_0[i].activeInHierarchy) //obj.setactive가 false이면 실행
            {
                return poolobj_0[i];
            }
        }
        return null;
    }
}
