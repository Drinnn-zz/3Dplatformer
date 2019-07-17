using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    [SerializeField] public int score;

    [NonSerialized] public bool isPaused;

    public static GameManager instance;
    
    private void Awake(){
        if (instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update(){
        PauseGameListener();
    }
    
    public void AddScore(int scoreToAdd){
        score += scoreToAdd;
        UIController.instance.UpdateScoreText();
    }

    public void OnLevelEnd(){
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1){
            OnWinGame();
        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnWinGame(){
        UIController.instance.SetEndScreen(true);
        Time.timeScale = 0.0f;
    }

    public void OnGameOver(){
        UIController.instance.SetEndScreen(false);
        Time.timeScale = 0.0f;
    }

    private void PauseGameListener(){
        if (Input.GetButtonDown("Cancel"))
            HandlePause();
    }

    public void HandlePause(){
        isPaused = !isPaused;
        
        if (isPaused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
            
        UIController.instance.TogglePauseScreen(isPaused);
    }
}
