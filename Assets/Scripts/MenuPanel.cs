using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPanel : MonoBehaviour
{
 
     public void StartScene()
     {
        SceneManager.LoadScene("Game");
     }

     public void Exit()
     {
        Application.Quit();
     }
}
