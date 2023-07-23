using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventManager : MonoBehaviour
{

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {

            PlayerPrefs.DeleteAll();

        }

    }

    public void LoadSceneEvent(string value)
    {

        SceneManager.LoadScene(value);

    }

    public void TTRLSceneLoad()
    {

        if(PlayerPrefs.GetInt("TTC") != int.MaxValue)
        {

            SceneManager.LoadScene("StoryTutorial");

        }
        else
        {

            SceneManager.LoadScene("Lobby");

        }
    }

    public void ExitGameEvent()
    {

        Application.Quit();

    }

}
