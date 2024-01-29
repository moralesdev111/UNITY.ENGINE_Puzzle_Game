using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    [SerializeField] Canvas deathCanvas;
    [SerializeField] Oxygen oxygen;
    [SerializeField] SceneLoader sceneLoader;

    private bool isGameOver = false;

    void Update()
    {
        // Check if the game is over and pause the game if necessary
        if (isGameOver)
        {
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void Die()
    {
        if (oxygen.currentOxygen <= 0.01f && !isGameOver)
        {
            Debug.Log("Dead");
            deathCanvas.gameObject.SetActive(true);
            StartCoroutine(RestartTimer());
            isGameOver = true;
        }
    }

    private IEnumerator RestartTimer()
{
    float startTime = Time.realtimeSinceStartup;
    float waitTime = 3f;

    while (Time.realtimeSinceStartup - startTime < waitTime)
    {
        yield return null; // Wait for the next frame
    }

    deathCanvas.gameObject.SetActive(false);
    sceneLoader.ChangeScene(0);

    // Resume the game by setting time scale back to 1
    Time.timeScale = 1f;
}

}
