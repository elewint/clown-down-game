using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOverReturn : MonoBehaviour
{
    public void LoadGame() {
        
        SceneManager.LoadScene("MainMenu"); 
        
    }
}
