
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool levelCompleted = false;
    public static bool isGameStarted = false;
    public static bool mute = false;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public Slider progressSlider;

    public static int numberOfPassedRings;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private void Awake()
    {
        // PlayerPrefs.DeleteAll();
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        levelCompleted = false;
        numberOfPassedRings = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Update UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        //makes the slider indicate the progress of the game
        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        progressSlider.value = progress;


        //display score
        scoreText.text = score.ToString();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                score = 0;
                SceneManager.LoadScene("Level");
            }
        }


        if (levelCompleted)
        {
            Time.timeScale = 0;
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
            }
        }

    }
}
