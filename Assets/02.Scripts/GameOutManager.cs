using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOutManager : MonoBehaviour
{
    int exitCount = 0;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) 
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                exitCount++;

                if (!IsInvoking("disable_DoubleClick"))
                {
                    Invoke("disable_DoubleClick", 0.3f);
                }

                if (exitCount == 2)
                {
                    CancelInvoke("disable_DoubleClick");
                    Application.Quit();
                }
            }
        } 
    }

    void disable_DoubleClick() 
    {
        exitCount = 0;    
    }

}
