using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
    [Header("Plane Stats")]
    [Tooltip("How much the throttle ramps up or down")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum engine thrust at 100% throttle")]
    public float maxthrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching or yawing")]
    public float responsiveness = 10f;

    public float turnrate = 10f;

    public float lift = 135f;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

    private Vector3 temp;

    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    Rigidbody rb;

    [SerializeField] TextMeshProUGUI hud;
    [SerializeField] Transform prop;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    private void Update()
    {
        HandleInputs();
        UpdateHUD();
        if (throttle > 0 && throttle < 30)
        {
            prop.Rotate(Vector3.right * 10);
        }
        else if (throttle >= 40 && throttle < 80)
        {
            prop.Rotate(Vector3.right * 20);
        }
        else if (throttle >= 80)
        {
            prop.Rotate(Vector3.right * 30);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxthrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier);

        rb.AddForce(transform.up * rb.velocity.magnitude * lift);

        //if (transform.eulerAngles.z > 10 && transform.eulerAngles.z < 350)
        //{
        //    temp = gameObject.transform.eulerAngles;
        //    if (temp.y > 180) temp.y -= 360;
        //    if (temp.y >= 0) temp.y += (gameObject.transform.eulerAngles.z * 0.001f);
        //    if (temp.y < 0) temp.y -= (gameObject.transform.eulerAngles.z * 0.001f);
        //    if (temp.y < 0) temp.y += 360;
        //    gameObject.transform.eulerAngles = temp;
        //}
    }

    private void UpdateHUD()
    {
        hud.text = "Throttle " + throttle.ToString("F0") + "%\n";
        hud.text += "Airspeed: " + (rb.velocity.magnitude).ToString("F0") + "\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + "\n";
    }
}
