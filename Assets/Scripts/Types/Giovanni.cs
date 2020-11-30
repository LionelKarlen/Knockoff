using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giovanni : Tank {
    

    public Giovanni() {
        healthPoints=500;
        attackDamage=50;
        attackDistance=50;
        reloadSpeed=4;

        forwardAcceleration=2;
        backwardAcceleration=1;
        maxBackwardSpeed=5;
        maxForwardSpeed=10;

        // Add this back for physics based movement
        // movementSpeed=100;
    }

    private void Start() {
        setTankObject(gameObject);
    }
}
