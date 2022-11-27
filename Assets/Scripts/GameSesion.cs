using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSesion : MonoBehaviour
{
    public int lives = 3;
    public TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Awake()
    {
        int numGameSesion = FindObjectsOfType<GameSesion>().Length;
        if (numGameSesion > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = lives.ToString();
    }
    public void ProccesPlayerDeth()
    {
        if (lives > 1)
        {
            TakeLives();
        }
        else
        {
            RestartGame();
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    void TakeLives()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        lives--;
        livesText.text = lives.ToString();

    }

    // Update is called once per frame

}
