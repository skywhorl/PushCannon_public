﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeManager : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;
    int position = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1);
        for (int i = 0; i < pos.Length; i++) 
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else 
        {
            for (int i = 0; i < pos.Length; i++) 
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2)) 
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
                    position = i;
                }
            }
        }
    }

    public void next()
    {
        if (position < pos.Length - 1)
        {
            position += 1;
            scroll_pos = pos[position];
        }
    }

    public void prev()
    {
        if (position > 0)
        {
            position -= 1;
            scroll_pos = pos[position];
        }
    }

}
