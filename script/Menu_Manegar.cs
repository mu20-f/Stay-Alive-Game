using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manegar : MonoBehaviour
{
    public GameObject Menu_panel;
    public GameObject Levels_panel;

   
    public void ShowLevels()
    {   SceneManager.LoadScene("levels");
       
    }
    public void ShowMenu()
    {SceneManager.LoadScene("main_menu");
        
    }
      public void QuitGame()
   {
    Debug.Log("out game");
    Application.Quit();
    
   }
    
}
