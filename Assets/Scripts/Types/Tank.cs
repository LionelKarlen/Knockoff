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
        print(healthPoints);
        destroyOnDead();
    } 

    public void destroyOnDead() {
        if(healthPoints<=0) {
            Transform.Destroy(tankObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag=="projectile") {
            getDamage(collision.collider.GetComponent<Projectile>().getSenderTank().attackDamage);
        }
    }

}
