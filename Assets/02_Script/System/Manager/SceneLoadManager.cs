using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    
    public void LoadScene(string value)
    {

        SceneManager.LoadScene(value);

    }

}
