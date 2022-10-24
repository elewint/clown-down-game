using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NewPauseMenu : MonoBehaviour
{
   public GameController gc;

   public void RESUME()
   {
      gc.Resume();
      gameObject.SetActive(false);
   }
   
   public void RESTART()
   {
      gc.Resume();
      SceneManager.LoadScene("Day");
   }
   
   public void QUIT()
   {
      SceneManager.LoadScene("MainMenu");
   }
   
   
}
