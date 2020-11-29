using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;

    public WheelCollider frontWheel;
    public WheelCollider backWheel;
    public Transform frontWheelTransform;
    public Transform backWheelTransform;

    public WheelCollider frontWheel_aux_1;
    public WheelCollider backWheel_aux_1;
    
    private float maxSteerAngle = 30;
    private float movementSpeed;

    // public float maxLeanAngle = 30;

    private void Start() {
        movementSpeed=GetComponent<Tank>().movementSpeed;
    }

    private void getInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical")*-1;
    }
    
    private void Steer() {
        steerAngle = maxSteerAngle * horizontalInput;
        frontWheel.steerAngle = steerAngle;
        frontWheel_aux_1.steerAngle = steerAngle;
    }

    private void Accelerate() {
        backWheel.motorTorque = verticalInput * movementSpeed;
        backWheel_aux_1.motorTorque = verticalInput * movementSpeed;
    }

    private void UpdateWheels() {
        UpdateWheelsIndividual(frontWheel, frontWheelTransform);
        UpdateWheelsIndividual(backWheel, backWheelTransform);
        // limitRotation();
        // lean();
    }

    // private void lean() {
    //     if(horizontalInput>0) {
    //         frontWheel.transform.position=new Vector3(0,frontWheel.transform.position.y+maxLeanAngle*horizontalInput,0);
    //         backWheel.transform.position=new Vector3(0,backWheel.transform.position.y+maxLeanAngle*horizontalInput,0);
    //     }
    // }

    // private void limitRotation() {
    //     if(transform.eulerAngles.z<-maxLeanAngle) {
    //         transform.eulerAngles=new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,-maxLeanAngle);
    //     } else if(transform.eulerAngles.z>maxLeanAngle) {
    //        transform.eulerAngles=new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,maxLeanAngle);
    //     }
    // }

    private void UpdateWheelsIndividual(WheelCollider collider, Transform transform) {
        Vector3 position = transform.position;
        Quaternion quaternion = transform.rotation;

        collider.GetWorldPose(out position, out quaternion);

        transform.position = position;
        transform.rotation = quaternion;
    }

    private void FixedUpdate() {
        getInput();
        Steer();
        Accelerate();
        UpdateWheels();
        // handleStandstill();
    }

}
