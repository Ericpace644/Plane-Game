using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlaneBobber : MonoBehaviour
{
    [SerializeField] GameObject[] Plane;
    [SerializeField] GameObject Light;
    public Transform prop;

    private int onTimer = 1;
    public int onDuration = 10;
    private int offTimer = 0;
    public int offDuration = 20;
    private int counter = 0;

    private bool rollDirection = true;
    

    private void Update()
    {
        LightUpdate();
        RollUpdate();
        prop.Rotate(Vector3.right * 50);

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

    }
}
