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
    [SerializeField] GameObject[] plane;
    //[SerializeField] GameObject darkness;

    private int index = 0;
    


    private void Awake()
    {
        

    }

    private void Start()
    {
        darkness = GameObject.Find("Darkness").GetComponent<Image>();
        camtran = cam.GetComponent<Transform>();
        Fade.SetActive(false);
        Debug.Log(camtran.position);
        Debug.Log(povs[index].position);
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
        Debug.Log("new index = " + index);
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

    private void UpdateCamera()
    {
        var tempcolor = darkness.color;

        if(runningdarkness == true)
        {
            if (tempcolor.a < 255f)
            {
                tempcolor.a += OCR;
                Debug.Log("Decrease Opacity = " + tempcolor.a);
            }
            else
            {
                Debug.Log("Finished Darkenning");
                runningdarkness = false;
                darknesscomplete = true;
            }
        }
        if(darknesscomplete == true && brightnesscomplete == false)
        {
            camtran.position = povs[index].position;
            camtran.rotation = povs[index].rotation;
            runningbrightness = true;
            Debug.Log("Changed Cam to index = " + index);
        }
        if(runningbrightness == true)
        {
            
            if (tempcolor.a > 0f)
            {
                tempcolor.a -= OCR;
                Debug.Log("Increase Opacity = " + tempcolor.a);
            }
            else
            {
                runningbrightness = false;
                brightnesscomplete = true;
                Fade.SetActive(false);
                Debug.Log("Finished Brightening");
            }
        }
        darkness.color = tempcolor;
        Debug.Log("Opacity is infact = " + darkness.color);
    }

    private void TriggerCamChange()
    {
        Debug.Log("TriggerCamChange");
        runningdarkness = true;
        runningbrightness = false;
        brightnesscomplete = false;
        darknesscomplete = false;
    }

    private void PlaneUpdate()
    {
        
    }
}
