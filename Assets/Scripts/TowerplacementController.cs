using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerplacementController : MonoBehaviour {

    public GameObject towerPrefab;
    public bool canPlace;

    public Camera orthogonalCamera;
    
    public Material obstacleMaterial;
    public string obstacleTag;

    void Update() {
        if(canPlace) {
            if(Input.GetMouseButtonDown(0)) {

            Instantiate(towerPrefab, new Vector3(orthogonalCamera.ScreenToWorldPoint(Input.mousePosition).x,0,orthogonalCamera.ScreenToWorldPoint(Input.mousePosition).z), towerPrefab.transform.rotation);
            canPlace=false;
            }
        }
    }



}