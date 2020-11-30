using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorsePlayerController : MonoBehaviour {
    
    private Rigidbody rb;

    private Tank tankInfo;

    private float horizontalInput;
    private float verticalInput;

    private float steerAngle;
    private const float steerSpeed=2;

    // public float forwardAcceleration=2;
    // public float backwardAcceleration=1;
    // public float maxBackwardSpeed;
    // public float maxForwardSpeed=1;

    public GameObject pivot;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        tankInfo = GetComponent<Tank>();
    }

    private void handleInput() {
        horizontalInput = Input.GetAxis("Horizontal")*-1;
        verticalInput = Input.GetAxis("Vertical")*-1;
    }

    private void steer() {
        steerAngle = horizontalInput*Time.deltaTime*verticalInput*tankInfo.maxForwardSpeed*tankInfo.forwardAcceleration*steerSpeed;
        transform.RotateAround(pivot.transform.position, Vector3.up, steerAngle);
    }

    private void accelerate() {

        if(verticalInput<0 && rb.velocity.magnitude <= tankInfo.maxForwardSpeed) { // if moving forwards
            rb.velocity += transform.forward*tankInfo.forwardAcceleration*verticalInput;
        } else if(verticalInput>0 && rb.velocity.magnitude <= tankInfo.maxBackwardSpeed) { // if moving backwards
            rb.velocity += transform.forward*tankInfo.backwardAcceleration*verticalInput;
        }
    }

    private void FixedUpdate() {
        handleInput();
        steer();
        accelerate();
    }


}
