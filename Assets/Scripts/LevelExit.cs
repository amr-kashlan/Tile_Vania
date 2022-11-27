using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public float levelLoad = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            StartCoroutine(RestartLevel());
        }
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoad);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene + 1 == SceneManager.sceneCount)
        {
            currentScene = -1;
        }
        SceneManager.LoadScene(currentScene + 1);



    }
}
