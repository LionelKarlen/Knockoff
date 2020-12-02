using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour {
    
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
    public float armourPiercing;

    // Movement Values
    [Header("Movement Values")]
    public float forwardAcceleration;
    public float backwardAcceleration;
    public float maxBackwardSpeed;
    public float maxForwardSpeed;

    // Add this back for physics based movement
    // public int movementSpeed;

    public Item[] items;

    private GameObject tankObject;

    public Tank() {
        items=new Item[9];
    }

    private void Update() {
        pickupItem();
    }

    public void pickupItem() {
        if(Input.GetKeyDown(KeyCode.G)) {
            resetValues();
            applyAllItems();
        }
    }

    public void getDamage(Tank attackingTank) {

        if(shieldPoints<=0) {
            healthPoints-=attackingTank.attackDamage;
        } else {
            shieldPoints-=attackingTank.attackDamage;
            healthPoints-=Mathf.CeilToInt(attackingTank.attackDamage*attackingTank.armourPiercing);
        }

        // healthPoints-=(damageAmount-shieldPoints);
        print(healthPoints);
        print(shieldPoints);
        checkDead();
    } 

    #region Deal with Death

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
            respawn();
        }

        private void destroy() {
            Transform.Destroy(tankObject);
        }

        private void respawn() {

        }

    #endregion
    
    // Add this back for projectiles
    // private void OnCollisionEnter(Collision collision) {
    //     if(collision.collider.tag=="projectile") {
    //         getDamage(collision.collider.GetComponent<Projectile>().getSenderTank());
    //     }
    // }

    public void setTankObject(GameObject gameObject) {
        tankObject=gameObject;
    }

    public abstract void resetValues();

    public void applyAllItems() {
        if(items.Length>0) {
            foreach (Item item in items) {
                if(item!=null) {
                    item.applyItem(this);
                }
                
            }
        }
    }
}
