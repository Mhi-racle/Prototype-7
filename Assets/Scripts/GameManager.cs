
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool levelCompleted = false;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;

    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public Slider progressSlider;

    public static int numberOfPassedRings;
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

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
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
