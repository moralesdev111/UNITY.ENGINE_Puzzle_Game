using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] SceneLoader sceneLoader;

    void Start()
    {
        playButton.onClick.AddListener(HandlePlayButton);
        quitButton.onClick.AddListener(HandleQuitButton);        
    }

    private void HandlePlayButton()
    {
        sceneLoader.ChangeScene(1);
    }

    private void HandleQuitButton()
    {
        Application.Quit();
    }
}
