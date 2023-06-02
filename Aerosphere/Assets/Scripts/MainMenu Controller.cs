using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject controlCanvas;
    public GameObject creditsCanvs;

    void Start()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ControlsButton()
    {

    }

    public void CreditsButton()
    {

    }
}
