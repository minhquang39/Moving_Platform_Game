using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
  // Reference to the UI Text component to display the score
    private void Awake(){
        gameManager = FindFirstObjectByType<GameManager>(); // Find the GameManager in the scene
        audioManager = FindFirstObjectByType<AudioManager>(); // Find the AudioManager in the scene
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Coin")){
            Destroy(collision.gameObject); 
            audioManager.PlayCoinSound(); // Play the coin sound effect
            gameManager.AddScore(1);
        } else if(collision.CompareTag("Trap")){
            gameManager.GameOver(); // Call the GameOver method in the GameManager
        } else if(collision.CompareTag("Enemy")){
            gameManager.GameOver();
        } else if(collision.CompareTag("Key")){
            Destroy(collision.gameObject); // Destroy the key object
            gameManager.GameWin(); // Call the GameOver method in the GameManager
        }
    }
}
