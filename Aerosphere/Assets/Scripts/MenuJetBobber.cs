using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJetBobber : MonoBehaviour
{
    [SerializeField] GameObject Light;

    private int onTimer = 1;
    public int onDuration = 10;
    private int offTimer = 0;
    public int offDuration = 20;
    private int counter = 0;

    public int pausecounter = 0;
    public int rollIncrement = 5;
    private bool rollRight = true;
    private bool rollLeft = false;
    private bool pause = false;
    private Vector3 temp;


    private void Update()
    {
        LightUpdate();
        RollUpdate();

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

    private void RollUpdate()
    {
        temp = gameObject.transform.eulerAngles;
        if (rollRight == true && rollLeft == false && pause == false && temp.z > -20)
        {
            temp.z -= rollIncrement;
        }
        if (rollRight == true && rollLeft == false && pause == false && temp.z <= -20)
        {
            pause = true;
        }
        if (rollRight == true && rollLeft == false && pause == true && pausecounter < 20)
        {
            pausecounter++;
        }
        if (rollRight == true && rollLeft == false && pause == true && pausecounter >= 20)
        {
            rollRight = false;
            pause = false;
            rollLeft = true;
            pausecounter = 0;
        }


        if (rollRight == false && rollLeft == true && pause == false && temp.z < 20)
        {
            temp.z += rollIncrement;
        }
        if (rollRight == false && rollLeft == true && pause == false && temp.z >= 20)
        {
            pause = true;
        }
        if (rollRight == false && rollLeft == true && pause == true && pausecounter < 20)
        {
            pausecounter++;
        }
        if (rollRight == false && rollLeft == true && pause == true && pausecounter >= 20)
        {
            rollRight = true;
            pause = false;
            rollLeft = false;
            pausecounter = 0;
        }
        gameObject.transform.Rotate(temp.x, temp.y, temp.x, Space.World);
    }
}
