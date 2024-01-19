using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    private string horizontalAxis = "Horizontal";
    private string vericalAxis = "Vertical";
    public float horizontalIput;
    public float verticalIput;
    private float steerAngle;
    private bool isBreaking;
    private float currentbreakForce;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    private float currentSteerAngle;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRighttWheelCollider;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRighttWheelTransform;
    [SerializeField] Transform followPoint;
    [SerializeField] private Camera minimapCamera;
    public TrailRenderer[] Tyremarks;
    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalIput * motorForce;
        frontRightWheelCollider.motorTorque = verticalIput * motorForce;
        breakForce = isBreaking ? breakForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking();
        }
    }
    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRighttWheelCollider.brakeTorque = currentbreakForce;
    }
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalIput;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRighttWheelCollider, rearLeftWheelTransform);
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
    public Transform GetFollowPoint()
    {
        return followPoint;
    }
    public Camera GetMinimapCamera()
    {
        return minimapCamera;
    }
}
