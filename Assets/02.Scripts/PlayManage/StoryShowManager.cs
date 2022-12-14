using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryShowManager : MonoBehaviour
{
    public GameObject Image1 = null;
    public GameObject Image2 = null;
    public GameObject Image3 = null;
    public GameObject Image3_1 = null;

    public GameObject text1 = null;
    public GameObject text2 = null;
    public GameObject text3 = null;

    public GameObject content1 = null;
    public GameObject content2 = null;
    public GameObject content3 = null;

    public GameObject next1 = null;
    public GameObject next2 = null;
    public GameObject before1 = null;
    public GameObject before2 = null;

    void Start()
    {
        Image1.SetActive(true);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image3_1.SetActive(false);

        text1.SetActive(true);
        text2.SetActive(false);
        text3.SetActive(false);

        content1.SetActive(true);
        content2.SetActive(false);
        content3.SetActive(false);

        next1.SetActive(true);
        next2.SetActive(false);
        before1.SetActive(false);
        before2.SetActive(false);
    }

    public void Next1()
    {
        Image1.SetActive(false);
        Image2.SetActive(true);
        Image3.SetActive(false);
        Image3_1.SetActive(false);

        text1.SetActive(false);
        text2.SetActive(true);
        text3.SetActive(false);

        content1.SetActive(false);
        content2.SetActive(true);
        content3.SetActive(false);

        next1.SetActive(false);
        next2.SetActive(true);
        before1.SetActive(true);
        before2.SetActive(false);
    }

    public void Next2()
    {
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(true);
        Image3_1.SetActive(true);

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(true);

        content1.SetActive(false);
        content2.SetActive(false);
        content3.SetActive(true);

        next1.SetActive(false);
        next2.SetActive(false);
        before1.SetActive(false);
        before2.SetActive(true);
    }

    public void Before1()
    {
        Image1.SetActive(true);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image3_1.SetActive(false);

        text1.SetActive(true);
        text2.SetActive(false);
        text3.SetActive(false);

        content1.SetActive(true);
        content2.SetActive(false);
        content3.SetActive(false);

        next1.SetActive(true);
        next2.SetActive(false);
        before1.SetActive(false);
        before2.SetActive(false);
    }

    public void Before2()
    {
        Image1.SetActive(false);
        Image2.SetActive(true);
        Image3.SetActive(false);
        Image3_1.SetActive(false);

        text1.SetActive(false);
        text2.SetActive(true);
        text3.SetActive(false);

        content1.SetActive(false);
        content2.SetActive(true);
        content3.SetActive(false);

        next1.SetActive(false);
        next2.SetActive(true);
        before1.SetActive(true);
        before2.SetActive(false);
    }
}
