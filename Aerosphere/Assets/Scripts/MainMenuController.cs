using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject controlCanvas;
    public GameObject creditsCanvs;

    public float OCR = 1f;

    private bool runningdarkness = false;
    private bool runningbrightness = false;
    private bool brightnesscomplete = true;
    private bool darknesscomplete = true;

    public GameObject Fade;

    public Image darkness;
    public Transform camtran;

    public GameObject cam;

    [SerializeField] Transform[] povs;
    

    private int index = 0;
    


    private void Awake()
    {
        float temp = OCR;
        OCR = temp / 255;

    }

    private void Start()
    {
        darkness = Fade.GetComponent<Image>();
        camtran = cam.GetComponent<Transform>();
        Fade.SetActive(false);
    }

    private void Update()
    {   

        if(camtran.position != povs[index].position || brightnesscomplete != true || darknesscomplete != true)
        {
            UpdateCamera();
        }

    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ControlsButton()
    {
        Fade.SetActive(true);
        index = 1;
        TriggerCamChange();
    }

    public void CreditsButton()
    {
        Fade.SetActive(true);
        index = 2;
        TriggerCamChange();
    }

    public void BackButton1()
    {
        Fade.SetActive(true);
        index = 0;
        TriggerCamChange();
    }

    public void BackButton2()
    {
        Fade.SetActive(true);
        index = 0;
        TriggerCamChange();
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    private void UpdateCamera()
    {
        var tempcolor = darkness.color;

        if(runningdarkness == true)
        {
            if (tempcolor.a < 1f)
            {
                tempcolor.a += OCR;
            }
            else
            {
                runningdarkness = false;
                darknesscomplete = true;
            }
        }
        if(darknesscomplete == true && brightnesscomplete == false && runningbrightness != true)
        {
            camtran.position = povs[index].position;
            camtran.rotation = povs[index].rotation;
            runningbrightness = true;
        }
        if(runningbrightness == true)
        {
            
            if (tempcolor.a > 0f)
            {
                tempcolor.a -= OCR;
            }
            else
            {
                runningbrightness = false;
                brightnesscomplete = true;
                Fade.SetActive(false);
            }
        }
        darkness.color = tempcolor;
    }

    private void TriggerCamChange()
    {
        runningdarkness = true;
        runningbrightness = false;
        brightnesscomplete = false;
        darknesscomplete = false;
    }
}
