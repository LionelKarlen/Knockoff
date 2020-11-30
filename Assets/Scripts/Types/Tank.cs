using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour{
    
    // Health Values
    [Header("Health Values")]
    public int healthPoints;
    public int shieldPoints;
    private int deaths;

    // Damage Values
    [Header("Damage Values")]
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
        healthPoints-=(damageAmount-shieldPoints);
        print(healthPoints);
        checkDead();
    } 

    #region Death

        private void checkDead() {
            if(healthPoints<=0) {
                destroy();
                StartCoroutine(RespawnTimeCoroutine(calculateRespawnTime()));
                deaths++;
            }
        }

        private int calculateRespawnTime() {
            int defaultRespawnTime = 10;
            return defaultRespawnTime+5*deaths;
        }

        private IEnumerator RespawnTimeCoroutine(int seconds) {
            yield return new WaitForSeconds(seconds);
        }

        private void destroy() {
            Transform.Destroy(tankObject);
        }

        private void respawn() {

        }

    #endregion
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag=="projectile") {
            getDamage(collision.collider.GetComponent<Projectile>().getSenderTank().attackDamage);
        }
    }

    public void setTankObject(GameObject gameObject) {
        tankObject=gameObject;
    }

}
