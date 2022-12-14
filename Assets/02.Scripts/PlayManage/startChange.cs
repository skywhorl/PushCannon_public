using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startChange : MonoBehaviour
{
    //public GameObject Cannon;
    public GameObject[] Cannons;
    GameObject Clone;
    private void Start()
    {
        //if (DataManager.instance.nowCannon != 0) //기본 대포랑 다른거면 기본대포는 안보이게 하고 새로운 대포 생성
        //{
        //    Cannon.SetActive(false);
        //    Clone = Instantiate(DataManager.instance.Cannon[DataManager.instance.nowCannon]);
        //    Clone.transform.parent = this.gameObject.transform;
        //    Clone.transform.position = new Vector3(0, 0.86f, 0.75f) ;
        //}
        Starts();
    }

    public void Starts()
    {
        switch (DataManager.instance.nowCannon)
        {
            case 0:
                break;
            case 1:
                Cannons[0].SetActive(false);
                Cannons[1].SetActive(true);
                break;
            case 2:
                Cannons[0].SetActive(false);
                Cannons[2].SetActive(true);
                break;
            case 3:
                Cannons[0].SetActive(false);
                Cannons[3].SetActive(true);
                break;
            case 4:
                Cannons[0].SetActive(false);
                Cannons[4].SetActive(true);
                break;
        }
    }
}
