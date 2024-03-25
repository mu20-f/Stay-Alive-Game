using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont_destroy_voice : MonoBehaviour
{
    public static dont_destroy_voice instance;
    void Awake()
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
}

