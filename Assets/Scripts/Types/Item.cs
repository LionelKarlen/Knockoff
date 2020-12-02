using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Item")]
public class Item : ScriptableObject {
    
    public AffectableProperties property;
    public float percentage;

    public void applyItem(Tank tank) {
        switch (property) {
            case AffectableProperties.ARMOUR:
                tank.armourPiercing+=Mathf.CeilToInt(tank.armourPiercing*percentage);
                break;
            case AffectableProperties.ATTACK:
                tank.attackDamage+=Mathf.CeilToInt(tank.attackDamage*percentage);
                break;
            case AffectableProperties.HEALTH:
                int increaseHealth = Mathf.CeilToInt(tank.maxHealthPoints*percentage);
                tank.maxHealthPoints+=increaseHealth;
                tank.currentHealthPoints+=increaseHealth;
                break;
            case AffectableProperties.SHIELD:
                int increaseShield = Mathf.CeilToInt(tank.maxShieldPoints*percentage);
                tank.maxShieldPoints+=increaseShield;
                tank.currentShieldPoints+=increaseShield;
                break;
        }
    }
}
