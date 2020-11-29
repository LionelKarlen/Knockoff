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

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            fire();
        }
        if (Input.GetMouseButtonDown(1)) {
            isAimMode=true;
            setAimMode();
        } else if(Input.GetMouseButtonUp(1)){
            isAimMode=false;
            setNormalMode();
        }
    }

    private void setAimMode() {
        thirdPersonCamera.transform.position=new Vector3(thirdPersonCamera.transform.position.x-surfValue,thirdPersonCamera.transform.position.y,thirdPersonCamera.transform.position.z);
    }

    private void setNormalMode() {
        thirdPersonCamera.transform.position=new Vector3(thirdPersonCamera.transform.position.x+surfValue,thirdPersonCamera.transform.position.y,thirdPersonCamera.transform.position.z);
    }

    void fire() {
        if(canFire) {
                    //Raycast from firepoint$
                    //This works perfectly if we don't want projectiles

                    // RaycastHit hit;
                    // // Does the ray intersect any objects excluding the player layer
                    // if (Physics.Raycast(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.back), out hit, tankInfo.attackDistance))
                    // {
                    //     Debug.DrawRay(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
                    //     Debug.Log("Did Hit");
                    //     Tank enemy = hit.collider.GetComponent<Tank>();
                    //     enemy.getDamage(tankInfo.attackDamage);
                    //     Debug.Log(enemy.healthPoints);
                    // }
                    // else
                    // {
                    //     Debug.DrawRay(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.back) * 1000, Color.red);
                    //     Debug.Log("Did not Hit");
                    // }
                GameObject missile = Instantiate(projectile, firePoint.transform.position, transform.rotation);
                missile.GetComponent<Rigidbody>().AddRelativeForce(0,0,-10000);
                missile.GetComponent<Projectile>().setSenderTank(tankInfo);

            //start reload coroutine
            // canFire=false;
            // StartCoroutine(ReloadCoroutine());
            //deal with hitting enemy
        }
    }

    IEnumerator ReloadCoroutine() {
        yield return new WaitForSeconds(5);

        canFire=true;
    }
}
