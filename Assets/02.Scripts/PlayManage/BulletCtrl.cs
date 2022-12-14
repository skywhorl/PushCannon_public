using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    float timer;
    float defaultTimer;
    private void OnCollisionEnter(Collision collision)
    {
        defaultTimer = Time.deltaTime;
        timer = defaultTimer;
        if(timer - defaultTimer >= 3)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
