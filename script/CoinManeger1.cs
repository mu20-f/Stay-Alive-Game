using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManeger1 : MonoBehaviour
{
     public static CoinManeger1 instance;
    public int coinCount =0;
    public int final = 0;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Load the current coin count from PlayerPrefs
        PlayerPrefs.SetInt("CoinCount", coinCount);
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
        
    }

    public void LoseCoins(int amount)
    { 
        coinCount -= amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
        
    }
}
