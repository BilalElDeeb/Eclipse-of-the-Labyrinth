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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        WeaponController weaponController = player.GetComponentInChildren<WeaponController>();

        if (weaponController.weapon != null)
        {
            Inventory.instance.AddItem(new InventorySlot
            {
                item = weaponController.weapon,
                amount = 1
            });
        }
        
        weaponController.initialize(this);
        
        Inventory.instance.RemoveItem(new InventorySlot
        {
            item = this,
            amount = 1
        });
    }
}
