using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour{
    
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject pauseScreen;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endScreenHeader;
    [SerializeField] private TextMeshProUGUI endScreenScore;

    public static UIController instance;

    private void Awake(){
        instance = this;
    }

    private void Start(){
        UpdateScoreText();
    }

    public void UpdateScoreText(){
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void SetEndScreen(bool hasWon){
        endScreen.SetActive(true);
        endScreenScore.text = "<b>Score</b>\n" + GameManager.instance.score;

        if (hasWon)
            endScreenHeader.text = "You Won!";
        else
            endScreenHeader.text = "You Lose!";

    }

    public void OnRestartButton(){
        SceneManager.LoadScene(1);
    }

    public void OnMenuButton(){
        if (GameManager.instance.isPaused)
            GameManager.instance.HandlePause();
        SceneManager.LoadScene(0);
    }

    public void TogglePauseScreen(bool paused){
        pauseScreen.SetActive(paused);
    }

    public void OnResumeButton(){
        GameManager.instance.HandlePause();
    }
    
}
