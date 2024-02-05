using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] Button returnButton;
    [SerializeField] SceneLoader sceneLoader;


    void Start()
    {
        returnButton.onClick.AddListener(HandleReturnButton);
    }

    private void HandleReturnButton()
    {
        sceneLoader.ChangeScene(0);
    }
}
