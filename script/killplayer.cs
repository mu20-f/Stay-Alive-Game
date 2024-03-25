using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject[] coins;
    public GameObject gameOverScreen;
    public Animator animator;
    public float speedLimit;
    public Movement script;

    void Start()
    {
        script = GameObject.Find("player").GetComponent<Movement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandlePlayerDeath();
        }
    }

    void HandlePlayerDeath()
    {
        animator.SetBool("IsDead", true);

        script.ChangeThroughPortal(Gamemodes.Cube, Speeds.Static, 1, 0);
        StartCoroutine(RunAnimationAndShowGameOverScreen());
        // Set speed to 0 in static mode
        CoinManeger1.instance.final = 0;
       
        
        
    }

    IEnumerator RunAnimationAndShowGameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        animator.SetBool("IsDead", false);
        gameOverScreen.SetActive(true); 
    }

    public void ReplayLevel()
    {
        foreach (GameObject coin in coins)
        {
            string coinName = coin.GetComponent<Take_coin_and_destroy>().coinName;
            if (PlayerPrefs.GetInt(coinName, 0) == 1)
            {
                PlayerPrefs.SetInt(coinName, 0);
            }
        }
        CoinManeger1.instance.final = 0;
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        foreach (GameObject coin in coins)
        {
            string coinName = coin.GetComponent<Take_coin_and_destroy>().coinName;
            if (PlayerPrefs.GetInt(coinName, 0) == 1)
            {
                PlayerPrefs.SetInt(coinName, 0);
            }
        }
        // dont_destroy_voice.instance.GetComponent<AudioSource>().Play();
        CoinManeger1.instance.final = 0;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu");
    }
}
