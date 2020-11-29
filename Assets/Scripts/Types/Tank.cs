using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour{
    
    public int healthPoints;
    public int attackDamage;
    public int attackDistance;
    public int reloadSpeed;
    public int movementSpeed;

    public GameObject tankObject;

    public void getDamage(int damageAmount) {
        healthPoints-=damageAmount;
        destroyOnDead();
    } 

    public void destroyOnDead() {
        if(healthPoints<0) {
            Transform.Destroy(tankObject);
        }
    }

}
