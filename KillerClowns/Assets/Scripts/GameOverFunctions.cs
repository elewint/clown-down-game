using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOverFunctions : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene("Day"); 
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu"); 
    }
}
