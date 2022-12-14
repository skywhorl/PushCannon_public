using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public int HP;
    int CurHP ;
    public Slider HPbar;
    public int thisbuilding;
    private void Start()
    {
        CurHP = HP;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Bullet")
        {

            if (collision.gameObject.activeSelf == true)
            {
                CurHP -= DataManager.instance.Damages();
                HPbar.value = (float)CurHP/(float)HP;
                if (CurHP <= 0)
                {
                    this.gameObject.SetActive(false);
                    GamePlayManager.instance.countFragments += 20;
                    DataManager.instance.MemorySet(thisbuilding);
                }
            }
            collision.gameObject.SetActive(false); 
            
        }

    }
}
