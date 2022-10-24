 using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
 using UnityEngine.SceneManagement; 
 
 public class MainMenu : MonoBehaviour {
    public GameObject Instructions; 
    
     public void LoadGame()
     {
        SceneManager.LoadScene("Day");
     }
     
     public void EnableInstructions()
    {
        Instructions.SetActive(true);
        
       //SceneManager.LoadScene("Instructions");
    }
 }
