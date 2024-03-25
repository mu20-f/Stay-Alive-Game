using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager_for_panels : MonoBehaviour
{
    public voice_contorl voiceoverController1;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;


    bool isPaused = false;
    private void PlayerUnpause()
    {
        voiceoverController1.UnpauseVoiceover();
    }
    private void PlayerPause()
    {
        voiceoverController1.PauseVoiceover();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {//Debug.Log("Escape key pressed");
            if (!isPaused)
            {
                PlayerPause();
                Time.timeScale = 0f;
                isPaused = true;
                pauseMenuScreen.SetActive(true);
                gameOverScreen.SetActive(false);
            }
            else
            {
                PlayerUnpause();
                Time.timeScale = 1f;
                isPaused = false;
                pauseMenuScreen.SetActive(false);
                gameOverScreen.SetActive(false);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            CoinManeger1.instance.final = 0;
            Debug.Log("Player collided with obstacle");

            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }
    public void ReplayLevel()
    {
        CoinManeger1.instance.final = 0;
        Time.timeScale = 1f;
        isPaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
    }



    public void GoToMenu()
    {
        // Check if dont_destroy_voice.instance is not null before accessing its AudioSource
        if (dont_destroy_voice.instance != null)
        {
            // Play AudioSource if it exists
            AudioSource audioSource = dont_destroy_voice.instance.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogError("AudioSource component not found on dont_destroy_voice.instance!");
            }
        }
        else
        {
            Debug.LogError("dont_destroy_voice.instance is null!");
        }

        // Check if CoinManeger1.instance is not null before accessing it
        if (CoinManeger1.instance != null)
        {
            // Reset final coins count to 0
            CoinManeger1.instance.final = 0;
        }
        else
        {
            Debug.LogError("CoinManeger1.instance is null!");
        }

        // Load the main menu scene
        SceneManager.LoadScene("main_menu");

        // Set game over screen inactive
        gameOverScreen.SetActive(false);

        // Resume time scale
        Time.timeScale = 1f;

        // Set isPaused to true
        isPaused = true;
    }
}

