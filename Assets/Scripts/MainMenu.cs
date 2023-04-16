using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    int sceneIndex;
    
    public void PlayGame()
    {
        /*sceneIndex = SceneManager.GetActiveScene (). buildIndex;
        if (sceneIndex == 5) {
            sceneIndex = 0;
        }
        SceneManager.LoadScene (sceneIndex+1);*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
