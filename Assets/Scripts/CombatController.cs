using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

    private bool canFire = true;
    public bool isAimMode=false;
    public GameObject firePoint;

    public GameObject projectile;

    public float surfValue;

    public Camera thirdPersonCamera;

    private Tank tankInfo;

    private void Start() {
        tankInfo=GetComponent<Tank>();
    }

    private void FixedUpdate() {
        if(Input.GetMouseButtonDown(0)) {
            fire();
        }
        if (Input.GetMouseButtonDown(1)) {
            setAimMode();
        } else if(Input.GetMouseButtonUp(1)){
            setNormalMode();
        }
    }

    private void setAimMode() {
        isAimMode=true;
        thirdPersonCamera.transform.position=new Vector3(thirdPersonCamera.transform.position.x-surfValue,thirdPersonCamera.transform.position.y,thirdPersonCamera.transform.position.z);
    }

    private void setNormalMode() {
        isAimMode=false;
        thirdPersonCamera.transform.position=new Vector3(thirdPersonCamera.transform.position.x+surfValue,thirdPersonCamera.transform.position.y,thirdPersonCamera.transform.position.z);
    }

    void fire() {
        if(canFire) {
                    //Raycast from firepoint
                    //This works perfectly if we don't want projectiles

                    RaycastHit hit;
                    if (Physics.Raycast(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.back), out hit, tankInfo.attackDistance)) {
                        Debug.DrawRay(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
                        print("Hit");
                        Tank enemy = hit.collider.GetComponent<Tank>();
                        enemy.getDamage(tankInfo);
                    } else {
                        Debug.DrawRay(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.back) * tankInfo.attackDistance, Color.red);
                        print("No Hit");
                    }

                // Add this back for Projectiles but this don't work anyway
                // GameObject missile = Instantiate(projectile, firePoint.transform.position, transform.rotation);
                // // missile.GetComponent<Rigidbody>().AddRelativeForce(0,0,-10000);
                // missile.GetComponent<Projectile>().setSenderTank(tankInfo);

            //start reload coroutine
            canFire=false;
            StartCoroutine(ReloadCoroutine(tankInfo.reloadSpeed));
        }
    }

    IEnumerator ReloadCoroutine(int seconds) {
        yield return new WaitForSeconds(seconds);

        canFire=true;
    }
}
