using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fragment" || collision.gameObject.tag == "Bullet")
        {
            if(collision.gameObject.tag == "Fragment")
            {
                GamePlayManager.instance.countFragments++;
            }
            collision.gameObject.SetActive(false);
        }
            
    }
}
