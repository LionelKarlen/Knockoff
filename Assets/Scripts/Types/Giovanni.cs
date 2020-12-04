using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giovanni : Tank {
    

    public Giovanni() {

        // Setup
        resetValues();
        applyAllItems();
    
        // Add this back for physics based movement
        // movementSpeed=100;
    }

    public override void resetValues() {
        healthPoints=500;
        shieldPoints=250;
        attackDamage=50;
        attackDistance=50;
        reloadSpeed=4;
        armourPiercing=0.01f;

        forwardAcceleration=2;
        backwardAcceleration=1;
        maxBackwardSpeed=5;
        maxForwardSpeed=10;
    }

    private void Start() {
        setTankObject(gameObject);
    }
}
