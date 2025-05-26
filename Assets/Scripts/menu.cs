using UnityEngine;
using UnityEngine.SceneManagement; 
public class menu : MonoBehaviour
{

     [SerializeField] private GameObject levelMenu; // Reference to the main menu GameObject
     [SerializeField] private GameObject mainMenu; // Reference to the level menu GameObject
     
   public void PlayGame(){
        SceneManager.LoadScene("Game");
                Debug.Log("Scene 1 loaded");
   }

   public void QuitGame(){
        Application.Quit(); // Quit the game application
   }
   

   public void DisplayLevel(){
          levelMenu.SetActive(true); // Show the level menu
          mainMenu.SetActive(false); // Hide the main menu
   }

   public void PlaySceneOne(){
        SceneManager.LoadScene("Game");
        levelMenu.SetActive(false); // Hide the level menu
        mainMenu.SetActive(false); // Hide the main menu
        Debug.Log("Scene 1 loaded");
   }
     public void PlaySceneTwo(){
               Debug.Log("Scene 2 loaded");
               // Load the second scene
            SceneManager.LoadScene("Game2");
               levelMenu.SetActive(false); // Hide the level menu
     }
     public void PlaySceneThree(){
               Debug.Log("Scene 3 loaded");
               SceneManager.LoadScene("Game3");
               levelMenu.SetActive(false); // Hide the level menu
               mainMenu.SetActive(false); // Hide the main menu
     }
}
