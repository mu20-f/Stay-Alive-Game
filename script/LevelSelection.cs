using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;

    void Start()
    {   //unlock level 1
        UnlockLevel1();

        // Check if level 2 is unlocked
        UnlockLevel2();

        // Check if level 3 is unlocked
        UnlockLevel3();
    }

    public void UnlockLevel2()
    {
        // Check if the player has collected enough coins for level 2
        if (PlayerPrefs.GetInt("CoinCount") >= 3)
        {
            // Mark level 2 as unlocked
            PlayerPrefs.SetInt("Level2Unlocked", 1);
            level2Button.SetActive(true);
        }
    }

    public void UnlockLevel3()
    {
        // Check if the player has collected enough coins for level 3
        if (PlayerPrefs.GetInt("CoinCount") >= 6 && PlayerPrefs.GetInt("Level2Unlocked") == 1)
        {
            // Mark level 3 as unlocked
            PlayerPrefs.SetInt("Level3Unlocked", 1);
            level3Button.SetActive(true);
        }
    }

    public void UnlockLevel1()
    {
        level2Button.SetActive(false);
        level3Button.SetActive(false);
        // Mark level 1 as unlocked
        PlayerPrefs.SetInt("Level1Unlocked", 1);
        level1Button.SetActive(true);
    }
}
