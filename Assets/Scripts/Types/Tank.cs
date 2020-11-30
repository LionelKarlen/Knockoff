using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour{
    
    // Health Values
    [Header("Health Values")]
    public int healthPoints;
    public int attackDamage;
    public int attackDistance;
    public int reloadSpeed;

    // Movement Values
    [Header("Movement Values")]
    public float forwardAcceleration;
    public float backwardAcceleration;
    public float maxBackwardSpeed;
    public float maxForwardSpeed;

    // Add this back for physics based movement
    // public int movementSpeed;

    private GameObject tankObject;

    public void getDamage(int damageAmount) {
        healthPoints-=damageAmount;
        print(healthPoints);
        destroyOnDead();
    } 

    public void destroyOnDead() {
        if(healthPoints<=0) {
            Transform.Destroy(tankObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag=="projectile") {
            getDamage(collision.collider.GetComponent<Projectile>().getSenderTank().attackDamage);
        }
    }

    public void setTankObject(GameObject gameObject) {
        tankObject=gameObject;
    }

}
