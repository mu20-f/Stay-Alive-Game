using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_script : MonoBehaviour
{
    public Gamemodes Gamemode;
    public Speeds Speed;
    public bool gravity;
    public int State;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            try{
            Movement movement = other.gameObject.GetComponent<Movement>();
            movement.ChangeThroughPortal(Gamemode, Speed,gravity?1:-1, State);
            }
        catch
        {

        }
        }
    }
}
