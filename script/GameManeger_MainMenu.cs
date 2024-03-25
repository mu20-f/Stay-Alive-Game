using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger_MainMenu : MonoBehaviour
{

    public void ShowLevel1()
    {
        dont_destroy_voice.instance.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Level1");

    }
    public void ShowLevel2()
    {
        dont_destroy_voice.instance.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Level2");

    }
    public void ShowLevel3()
    {
        dont_destroy_voice.instance.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Level3");

    }
    public void ShowLevel()
    {
        SceneManager.LoadScene("levels");

    }
    public void ShowMainmenu()
    {
        SceneManager.LoadScene("main_menu");

    }
    public void Exit()
    {
        Application.Quit();
    }
}
