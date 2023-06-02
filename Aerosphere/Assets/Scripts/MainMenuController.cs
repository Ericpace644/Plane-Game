using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject controlCanvas;
    public GameObject creditsCanvs;
    private int activeMenu = 0;

    private GameObject current;

    [SerializeField] GameObject[] cams;
    [SerializeField] GameObject[] plane;
    [SerializeField] GameObject[] darkness;


    void Start()
    {
        if (activeMenu != 0) activeMenu = 0;
        Display.displays[activeMenu].Activate();

    }

    void Update()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ControlsButton()
    {
        activeMenu = 1;
        Display.displays[activeMenu].Activate();

    }

    public void CreditsButton()
    {
        activeMenu = 2;
        Display.displays[activeMenu].Activate();
    }

    public void BackButton1()
    {
        activeMenu = 0;
        Display.displays[activeMenu].Activate();
    }

    public void BackButton2()
    {
        activeMenu = 0;
        Display.displays[activeMenu].Activate();
    }

    private void UpdateDarkness()
    {

    }
}
