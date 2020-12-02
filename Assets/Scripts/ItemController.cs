using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    
    public Item item;


    private void OnTriggerStay(Collider collider) {
        if(collider.tag=="player") {
            Tank player = collider.GetComponent<Tank>();
            if(player.pickupItem(item)) {
                Destroy(this.gameObject);
            }
        }
    }
}
