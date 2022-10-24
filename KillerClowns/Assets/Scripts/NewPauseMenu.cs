using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement; 

public class NewPauseMenu : MonoBehaviour
{
    public void RESUME()
    {
       SceneManager.LoadScene("Day");
    }
    
    public void RESTART()
    {
       SceneManager.LoadScene("MainMenu");
    }
    
    public void QUIT()
    {
       SceneManager.LoadScene("MainMenu");
    }
    
    
}
