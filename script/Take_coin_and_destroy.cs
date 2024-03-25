using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_coin_and_destroy : MonoBehaviour
{
    
    public int coinValue = 1;
    public string coinName;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinManeger1.instance.final+=coinValue;
           //PlayerPrefs.SetInt()
            gameObject.SetActive(false);
            PlayerPrefs.SetInt(coinName, 1);
        }
    }
}

