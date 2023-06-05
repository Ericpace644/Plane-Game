using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlaneBobber : MonoBehaviour
{
    [SerializeField] GameObject Light;
    public Transform prop;

    private int onTimer = 1;
    public int onDuration = 10;
    private int offTimer = 0;
    public int offDuration = 20;
    private int counter = 0;

    private int pausecounter = 0;
    public float rollIncrement = 0.1f;
    private bool rollRight = true;
    private bool rollLeft = false;
    private bool pause = false;
    private Vector3 temp;
    

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
        temp = gameObject.transform.eulerAngles;
        if (rollRight == true && rollLeft == false && pause == false && temp.z > 340)
        {
            Debug.Log("1");
            temp.z -= rollIncrement;
          
        }
        if (rollRight == true && rollLeft == false && pause == false && temp.z <= 340)
        {
            Debug.Log("2");
            pause = true;
            
        }
        if (rollRight == true && rollLeft == false && pause == true && pausecounter < 20)
        {
            Debug.Log("3");
            pausecounter++;
        }
        if (rollRight == true && rollLeft == false && pause == true && pausecounter >= 20)
        {
            Debug.Log("4");
            rollRight = false;
            pause = false;
            rollLeft = true;
            pausecounter = 0;
        }


        if (rollRight == false && rollLeft == true && pause == false && temp.z < 20)
        {
            Debug.Log("5");
            temp.z += rollIncrement;
        }
        if (rollRight == false && rollLeft == true && pause == false && temp.z >= 20)
        {
            Debug.Log("6");
            pause = true;
        }
        if (rollRight == false && rollLeft == true && pause == true && pausecounter < 20)
        {
            Debug.Log("7");
            pausecounter++;
        }
        if (rollRight == false && rollLeft == true && pause == true && pausecounter >= 20)
        {
            Debug.Log("8");
            rollRight = true;
            pause = false;
            rollLeft = false;
            pausecounter = 0;
        }
        gameObject.transform.eulerAngles = temp;
    }
}
