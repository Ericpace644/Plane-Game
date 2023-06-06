using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJetBobber : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] GameObject[] RedBeacons;

    private int onTimer = 1;
    public int onDuration = 10;
    private int offTimer = 0;
    public int offDuration = 80;
    private int counter = 0;

    private int RonTimer = 1;
    public int RonDuration = 10;
    private int RoffTimer = 0;
    public int RoffDuration = 70;
    private int Rcounter = 0;

    public int pausecounter = 0;
    public float rollIncrement = 0.1f;
    private bool rollRight = true;
    private bool pause = false;
    private Vector3 temp;


    private void Update()
    {
        LightUpdate();
        RollUpdate();
        RedLightUpdate();
    }

    private void LightUpdate()
    {
        if (onTimer == 1 && counter < onDuration)
        {
            counter++;
        }
        if (onTimer == 1 && counter == onDuration)
        {
            Light.SetActive(false);
            counter = 0;
            onTimer = 0;
            offTimer = 1;
        }
        if (offTimer == 1 && counter < offDuration)
        {
            counter++;
        }
        if (offTimer == 1 && counter == offDuration)
        {
            Light.SetActive(true);
            counter = 0;
            onTimer = 1;
            offTimer = 0;
        }
    }


    private void RedLightUpdate()
    {
        if (RonTimer == 1 && Rcounter < RonDuration)
        {
            Rcounter++;
        }
        if (RonTimer == 1 && Rcounter == RonDuration)
        {
            RedBeacons[1].SetActive(false);
            RedBeacons[0].SetActive(false);
            Rcounter = 0;
            RonTimer = 0;
            RoffTimer = 1;
        }
        if (RoffTimer == 1 && Rcounter < RoffDuration)
        {
            Rcounter++;
        }
        if (RoffTimer == 1 && Rcounter == RoffDuration)
        {
            RedBeacons[1].SetActive(true);
            RedBeacons[0].SetActive(true);
            Rcounter = 0;
            RonTimer = 1;
            RoffTimer = 0;
        }
    }

    private void RollUpdate()
    {
        temp = gameObject.transform.eulerAngles;
        
        temp.z += 360;
        if (rollRight && !pause && temp.z > 340)
        {
            temp.z -= rollIncrement;

        }
        if (rollRight && !pause && temp.z <= 340)
        {
            pause = true;

        }
        if (pause && pausecounter < 20)
        {
            pausecounter++;
        }
        if (rollRight && pause && pausecounter >= 20)
        {
            rollRight = false;
            pause = false;

            pausecounter = 0;
        }


        if (!rollRight && !pause && temp.z < 380)
        {
            temp.z += rollIncrement;
        }
        if (!rollRight && !pause && temp.z >= 380)
        {
            pause = true;
        }
        if (!rollRight && pause && pausecounter < 20)
        {
            pausecounter++;
        }
        if (!rollRight && pause && pausecounter >= 20)
        {
            rollRight = true;
            pause = false;
            pausecounter = 0;
        }
        temp.z %= 360;
        gameObject.transform.eulerAngles = temp;
    }
}
