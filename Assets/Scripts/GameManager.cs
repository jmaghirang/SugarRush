using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // variable to keep track of the playback position of the audio clip
    private float audioClipPosition = 0f;
    public AudioSource theMusic;

    // i am so sorry there are so many audio variable
    public AudioSource winMusic;
    public AudioSource winFX;
    public AudioSource loseFX;
    //public AudioSource missSound;

    public bool startPlaying;

    public FoodPhysics veggies;
    public FoodPhysics sweets;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int missCounter = 50;
    public int veggieCounter = 0;
    public int candyCounter = 0;

    int sceneIndex;

    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;
    public Text missText;
    public Text veggieText;
    public Text candyText;

    public int veggiesToWin = 10;
    public int sweetsToWin = 6;
    public int scoreToWin = 6000;

    public GameObject pauseMenuPanel;
    // im so dumb i couldnt figure out how to make the win panel work for every game level i am sorry this is here now! we have so many UI panels ;-;
    public GameObject winPanel;
    public GameObject gameOverPanel;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "0/" + scoreToWin.ToString();
        missText.text = "50";
        veggieText.text = "0/" + veggiesToWin.ToString();
        candyText.text = "0/" + sweetsToWin.ToString();
        currentMultiplier = 1;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                veggies.hasStarted = true;
                sweets.hasStarted = true;

                theMusic.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void NoteHit()
    {
        // Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Streak: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = currentScore.ToString() + "/" + scoreToWin.ToString();
      
        /*if (missCounter < 49){
            missCounter += 2;
            missText.text = missCounter.ToString();
        }*/

        // win panel hereee
        if(currentScore >= scoreToWin && candyCounter >= sweetsToWin && veggieCounter >= veggiesToWin)
        {
            // BG music stops
            theMusic.Stop();
            // win music plays 
            winMusic.Play();
            winFX.Play();
            // win panel instead of a win scene!
            winPanel.SetActive(true);
            // pauses the game basically
            Time.timeScale = 0f;
        }

        /*if (missCounter != 0)
        {
            missCounter--;
            missText.text = missCounter.ToString();
        }
        else
        {
            // i think the code is same here except its for the game over panel
            theMusic.Stop();
            loseFX.Play();
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }*/

        if (Input.GetKeyDown("x"))
        {
            veggieCounter++;
            veggieText.text = veggieCounter.ToString() + "/" + veggiesToWin.ToString();
        }

        if (Input.GetKeyDown("z"))
        {
            candyCounter++;
            candyText.text = candyCounter.ToString() + "/" + sweetsToWin.ToString();
        }

    }

    public void NoteMissed()
    {
        // Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        /*if (missCounter > 0)
        {
            missCounter--;
            missText.text = missCounter.ToString();

            // Play miss sound effect
            //missSound.PlayOneShot(missSound.clip);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }*/

        if (missCounter != 0)
        {
            missCounter--;
            missText.text = missCounter.ToString();
        }
        else
        {
            // i think the code is same here except its for the game over panel
            theMusic.Stop();
            loseFX.Play();
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        multiText.text = "Streak: x" + currentMultiplier;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuPanel.SetActive(true);

        audioClipPosition = theMusic.time;
        theMusic.Pause();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuPanel.SetActive(false);

        theMusic.time = audioClipPosition;
        theMusic.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}