using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giovanni : Tank {
    

    public Giovanni() {
        healthPoints=500;
        attackDamage=50;
        attackDistance=50;
        reloadSpeed=4;
        movementSpeed=100;
    }

    private void Start() {
        tankObject=gameObject;
    }
}
