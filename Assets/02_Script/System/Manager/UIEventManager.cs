using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventManager : MonoBehaviour
{
    
    public void LoadSceneEvent(string value)
    {

        SceneManager.LoadScene(value);

    }

}
