using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    
    // Health Values
    public int healthPoints;
    public int shieldPoints;

    // Damage Values
    public int attackDamage;
    public float armourPiercing;

    public abstract void applyItem(Tank tank);
}
