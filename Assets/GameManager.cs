using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float time = 60;
    public TextMeshProUGUI timeText;
    public GameObject gameOverScreen;
    public GameObject restartButton;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        UpdateTime(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0 && isGameActive) {
            GameOver();
        }

        UpdateTime(Time.deltaTime);

    }

    void UpdateTime(float timeToSubtract) {
        if (isGameActive) {
            time -= timeToSubtract;
            timeText.text = "Time: " + Mathf.RoundToInt(time);
        }
    }

    void GameOver() {
        isGameActive = false;
        gameOverScreen.SetActive(true);
        restartButton.SetActive(true);
    }

    public void HandleRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
