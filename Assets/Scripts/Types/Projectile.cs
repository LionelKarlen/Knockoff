using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    private Tank senderTank;

    public void setSenderTank(Tank tank) {
        this.senderTank = tank;
    }

    public Tank getSenderTank() {
        return this.senderTank;
    }
}
