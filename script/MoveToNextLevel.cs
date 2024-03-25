using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour

{
    public GameObject[] coins;

    public int nextSceneLoad;
    bool hasWon = false;
    public GameObject win_panel;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

        foreach (GameObject coin in coins)
        {
            string coinName = coin.GetComponent<Take_coin_and_destroy>().coinName;
       PlayerPrefs.SetInt(coinName, 0);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasWon = true;
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                Debug.Log("You Completed ALL Levels");

                //Show Win Screen or Somethin.
            }
            else
            {
                if (hasWon)
                {
                    PlayerPrefs.SetInt("CoinsCollected", 1);
                    CoinManeger1.instance.AddCoins(CoinManeger1.instance.final);
                    PlayerPrefs.SetInt("CoinCount", CoinManeger1.instance.coinCount);
                    CoinManeger1.instance.final = 0;
                    Time.timeScale = 0f;
                    win_panel.SetActive(true);


                    //Setting Int for Index
                    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                    {
                        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                    }
                }
                else
                    CoinManeger1.instance.coinCount = 0;
            }
        }


    }
    public void GoToMenu()
    {
        dont_destroy_voice.instance.GetComponent<AudioSource>().Play();

        CoinManeger1.instance.final = 0;
        win_panel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu");
    }

}
