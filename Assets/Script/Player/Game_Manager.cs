using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
   
    CarController myCar;
    public int index;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Speedometer speedometer;
    [SerializeField] private Camera minimapCamera;
    public CarUserControl gasPedal;
    public CarUserControl brakePedal;
    void Awake()
    {
        index = PlayerPrefs.GetInt("CarIndex");
        myCar = Instantiate(Resources.Load("Cars/Car" + (index + 1), typeof(CarController))) as CarController;
        myCar.transform.position = new UnityEngine.Vector3(-58f, 0.1f, -132.9f);
        virtualCamera.Follow = myCar.GetFollowPoint();
        virtualCamera.LookAt = myCar.GetFollowPoint();      
        speedometer.target = myCar.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
            GetInput();  
    }
    private void GetInput()
    {
        myCar.verticalIput = /*Input.GetAxis(VERTICAL);*/ Input.GetAxis("Vertical");
        if (gasPedal.isPressed)
        {

            myCar.verticalIput += gasPedal.dampenPress;
        }
        if (brakePedal.isPressed)
        {
            myCar.verticalIput -= brakePedal.dampenPress;
        }
        myCar.horizontalIput = /*Input.GetAxis(HORIZONTAL);*/  SimpleInput.GetAxis("Horizontal");
    
        //verticalIput = /*Input.GetAxis(VERTICAL);*/  SimpleInput.GetAxis(vericalAxis);
        //isBreaking = Input.GetKey(KeyCode.Space);
        transform.Rotate(0, myCar.horizontalIput * 5f, 0f, Space.Self);
    }


    
}
