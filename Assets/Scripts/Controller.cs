using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]


public class Controller : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    private float horizontalInput;
    public Rigidbody rig;

    // Settings
    [SerializeField] private float motorForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;


    private void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = 1 * motorForce;
        frontRightWheelCollider.motorTorque = 1 * motorForce;
    }

    private void HandleSteering()
    {
        frontLeftWheelCollider.steerAngle = horizontalInput * maxSteerAngle;
        frontRightWheelCollider.steerAngle = horizontalInput * maxSteerAngle;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }


    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }


/*    public bool isFalling()
    {
        if (rig.position.y < -1.0)
        {
            Debug.Log("isFall");
            return true;
        }
        else
            return false;
    }*/
}
