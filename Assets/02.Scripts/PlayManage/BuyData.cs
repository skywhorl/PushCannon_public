using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyData : MonoBehaviour
{
    public int buynum; //몇번째 인지 필수!
    public int buyMoney; //가격
    public Text names; //구매했는지 눈으로 확인용
    
    public GameObject button; //버튼 활성화
    public GameObject Image; //현재 사용중인 대포

    int counts;
    private void Start()
    {
        Image.SetActive(false); //처음엔 안보이게(구매 안했기에)
        bool result = DataManager.instance.CannonCheck(buynum); //이 아이템을 구매헀는지 확인
        if(result == true)
        {
            if(DataManager.instance.nowCannon == buynum) //이 아이템이 현재 착용중인 대포이면
            {
                button.SetActive(false);
                Image.SetActive(true);
                names.text = "Change";
            }
            else 
            {
                names.text = "Change";
            }
            
        }
    }
    private void Update()
    {        
        if (DataManager.instance.nowCannon != buynum) //다른 것으로 변경했을 경우 아닌 것들은 다시 변경 할 수 있도록 버튼화
        {
            if(buynum == 4)
            {
                counts = DataManager.instance.GetAdCount();
                if(counts == 10)
                {
                    button.SetActive(true);
                    Image.SetActive(false);
                }
            }
            else
            {
                button.SetActive(true);
                Image.SetActive(false);
            }
        }
        else
        {
            button.SetActive(false);
            Image.SetActive(true);
        }
    }
    public void Buy() //구매버튼
    {
        if(names.text != "Change") //이미 구매한 것이 아니면
        {
            bool result = DataManager.instance.MoneySpend(buyMoney, buynum); //구매시도 

            if (result == true) //성공시 
            {
                button.SetActive(false);
                Image.SetActive(true);
                names.text = "Change";
                DataManager.instance.nowCannon = buynum;
                DataManager.instance.GetMoney();
                DataManager.instance.NowCannonsave();
            }
            else
            {

            }
        }
        else //이미구매한 것이면
        {
            DataManager.instance.nowCannon = buynum;
            DataManager.instance.NowCannonsave();
            DataManager.instance.CannonBoolenSave(buynum);
            button.SetActive(false);
            Image.SetActive(true);
        }
       
    }
}
