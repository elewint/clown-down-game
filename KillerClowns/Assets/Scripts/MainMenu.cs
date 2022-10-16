 using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
 using UnityEngine.SceneManagement; 
 
 public class MainMenu : MonoBehaviour {
 
     public void LoadGame()
     {
        SceneManager.LoadScene("Day");
     }
 }
