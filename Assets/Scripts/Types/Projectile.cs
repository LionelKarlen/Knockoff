using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    private Tank senderTank;
    
    // This works but I don't wanna deal with it
    // public float speed;

    // private void Start() {
    //     speed=-10;
    // }

    public void setSenderTank(Tank tank) {
        this.senderTank = tank;
    }

    public Tank getSenderTank() {
        return this.senderTank;
    }

    // private void Update() {
    //     // Same thing here
    //     // this.transform.position = transform.forward*speed;
    // }
}
