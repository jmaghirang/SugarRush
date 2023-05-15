using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    int sceneIndex;
    
    public void PlayGame()
    {
        /*sceneIndex = SceneManager.GetActiveScene (). buildIndex;
        if (sceneIndex == 5) {
            sceneIndex = 0;
        }
        SceneManager.LoadScene (sceneIndex+1);*/

        audioSource.Play();
        SceneManager.LoadScene("Level 1");
    }

    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene (). buildIndex;
    }

    /*public void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
            SceneManager.LoadScene ("Win");
    }*/

    public void SelectOne()
    {
        Debug.Log ("Level One");
        SceneManager.LoadScene("Level 1");
    }

    public void SelectTwo()
    {
        Debug.Log ("Level Two");
        SceneManager.LoadScene("Level 2");
    }

    public void SelectThree()
    {
        Debug.Log ("Level Three");
        SceneManager.LoadScene("Level 3");
    }

    public void NextLevel()
    {
        Debug.Log ("NextLevel!");
        SceneManager.LoadScene("Level 2");
    }

    public void QuitGame()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene (sceneIndex - sceneIndex);
    }
}
