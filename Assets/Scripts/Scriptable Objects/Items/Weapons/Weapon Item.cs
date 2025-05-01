using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Eclipse of the Labyrinth/Items/Weapon")]

public class WeaponItem : ItemSO
{
    public AttackBehaviourSO weaponAttackBehaviour;
    public BulletItem bulletItem;
    public bool autoFire;
    public float fireRate;
    public int maxMagazineSize;
    public float reloadTime;
    
    public override void useItem()
    {
        
    }
}
