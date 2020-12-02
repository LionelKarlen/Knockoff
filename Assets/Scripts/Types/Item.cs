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
                tank.healthPoints+=Mathf.CeilToInt(tank.healthPoints*percentage);
                break;
            case AffectableProperties.SHIELD:
                tank.shieldPoints+=Mathf.CeilToInt(tank.shieldPoints*percentage);
                break;
        }
    }

    public void disapplyItem(Tank tank) {
        switch (property) {
            case AffectableProperties.ARMOUR:
                tank.armourPiercing-=Mathf.CeilToInt(tank.armourPiercing*percentage);
                break;
            case AffectableProperties.ATTACK:
                tank.attackDamage-=Mathf.CeilToInt(tank.attackDamage*percentage);
                break;
            case AffectableProperties.HEALTH:
                tank.healthPoints-=Mathf.CeilToInt(tank.healthPoints*percentage);
                break;
            case AffectableProperties.SHIELD:
                tank.shieldPoints-=Mathf.CeilToInt(tank.shieldPoints*percentage);
                break;
        }
    }
}
