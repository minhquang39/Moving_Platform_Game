using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace to manage scenes
public class GameManager : MonoBehaviour
{
  private int score = 0;
  [SerializeField] private TextMeshProUGUI scoreText;
  [SerializeField] private TextMeshProUGUI highScore; // Reference to the player object
  [SerializeField] private GameObject gameOverUI;
  [SerializeField] private GameObject gameWinUI;
  [SerializeField] private GameObject pauseUI; // Reference to the player object
  [SerializeField] private GameObject darkPanel; // Reference to the player object

  [SerializeField] private AudioManager audioManager;

  private bool isGameOver = false;
  private bool isGameWin = false;
  void Start(){
    UpdateScore();
    gameOverUI.SetActive(false); // Hide the Game Over UI at the start of the game
    gameWinUI.SetActive(false); // Hide the Game Win UI at the start of the game
  }
  
  public void AddScore(int point){
    if(isGameOver || isGameWin) return; // If the game is over, do not add score
    score += point; // Add points to the score
    UpdateScore(); // Update the score display
  } 

  public void UpdateScore(){
    scoreText.text = score.ToString(); // Update the UI Text component with the current score
  }

  public void GameOver(){
    isGameOver = true;
    gameOverUI.SetActive(true); // Show the Game Over UI
    Time.timeScale = 0; // Pause the game by setting time scale to 0
    score=0;
    audioManager.PauseBackgroundMusic(); // Pause the background music when game over
  }
  public void GameWin(){
    isGameWin = true;
    gameWinUI.SetActive(true); // Show the Game Over UI
    Time.timeScale = 0; // Pause the game by setting time scale to 0
    highScore.text = $"High Score: {score}";
    audioManager.PauseBackgroundMusic(); // Pause the background music when game win
  }

  public void GoToMenu(){
    SceneManager.LoadScene("Menu"); // Load the Menu scene
    Time.timeScale = 1; // Resume the game by setting time scale to 1
  }

  public void StartGame(){
    isGameOver = false;
    score = 0;
    UpdateScore(); // Reset the score to 0 and update the display
    Time.timeScale = 1; // Resume the game by setting time scale to 1
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene to restart the game
  }

public void PauseGame(){
    audioManager.PauseBackgroundMusic(); // Tắt nhạc nền khi pause
    Debug.Log("PauseGame called");
    Time.timeScale = 0;
    pauseUI.SetActive(true);
    darkPanel.SetActive(true);
}

public void ResumeGame(){
    audioManager.ResumeBackgroundMusic(); // Mở lại nhạc nền khi resume
    Time.timeScale = 1;
    pauseUI.SetActive(false);
    darkPanel.SetActive(false);
}

  public void RestartGame(){
    Time.timeScale = 1; // Resume the game by setting time scale to 1
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene to restart the game
  }

  public bool IsGameOver(){
    return isGameOver;
  }

  public bool IsGameWin(){
    return isGameWin;
  }
}
