using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_coin_value : MonoBehaviour
{    //public static change_coin_value instance;
public int coins;
public Text coinText;
void Start()
  {
    coins = PlayerPrefs.GetInt("CoinCount", 0);
    
    Debug.Log(coins.ToString());
    coinText.text = coins.ToString();
  }

}


