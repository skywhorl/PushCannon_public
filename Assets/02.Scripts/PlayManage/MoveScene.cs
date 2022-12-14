using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // 버튼이 눌렸을 때
    public void PointerDown(string types) 
    {
        switch (types)
        {
            case "Play":
                SceneManager.LoadScene("Play");
                DataManager.instance.Canvasobj.SetActive(false);
                break;
            case "Shop":
                SceneManager.LoadScene("Shop");
                DataManager.instance.Canvasobj.SetActive(true);
                break;
            case "Back":
                SceneManager.LoadScene("Main");
                break;
            case "Select":
                SceneManager.LoadScene("Select");
                DataManager.instance.Canvasobj.SetActive(true);
                break;
            case "StoryAndHowtoPlay":
                SceneManager.LoadScene("StoryHowtoPlay");
                DataManager.instance.Canvasobj.SetActive(false);
                break;
        }
    }

    public void ActiveSoundCtrl()
    {
        SoundCtrl.instance.audioChange.SetActive(true);
        DataManager.instance.Canvasobj.SetActive(false);
    }
}
