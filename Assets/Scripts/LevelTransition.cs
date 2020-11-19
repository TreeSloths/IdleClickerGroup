using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition : MonoBehaviour
{
   
public void LoadNextLevel()
    {
        SceneManager.LoadScene("HomeTree");
    }

    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene("TestSceneJimmie");
    }

}
