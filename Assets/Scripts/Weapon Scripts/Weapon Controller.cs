using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponItem weapon;
    public int currentMagazine;
    public bool isReloading = false;
    public float reloadCooldown;
    public float attackCooldown;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        currentMagazine = Mathf.Min(weapon.maxMagazineSize, Inventory.instance.CountItem(weapon.bulletItem));
        Inventory.instance.RemoveItem(new InventorySlot
        {
            item = weapon.bulletItem,
            amount = currentMagazine
        });
    }

    Touch? getValidTouch()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > 350 && touch.position.y > 350)
            {
                return touch;
            }
        }
        return null;
    }

    void fireBullet(Touch validTouch)
    {
        weapon.weaponAttackBehaviour.Attack(weapon.bulletItem, (new Vector3(validTouch.position.x, validTouch.position.y, 0) - transform.position).normalized, transform.position, true, bulletPrefab);
        currentMagazine -= 1;
    }

    void startReloading()
    {
        if (Inventory.instance.CountItem(weapon.bulletItem) > 0)
        {
            isReloading = true;
            reloadCooldown = weapon.reloadTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            reloadCooldown -= Time.deltaTime;
            if (reloadCooldown <= 0)
            {
                isReloading = false;
                currentMagazine = Mathf.Min(weapon.maxMagazineSize, Inventory.instance.CountItem(weapon.bulletItem));
                Inventory.instance.RemoveItem(new InventorySlot
                {
                    item = weapon.bulletItem,
                    amount = currentMagazine
                });
            }
            
            return;
        }
        
        attackCooldown -= Time.deltaTime;
        
        Touch? validTouch = getValidTouch();
        
        bool isTap = validTouch != null && validTouch.Value.phase == TouchPhase.Began;
        bool isHolding = validTouch != null;

        if ((weapon.autoFire && isHolding) || (!weapon.autoFire && isTap))
        {
            if (attackCooldown <= 0)
            {
                if (currentMagazine > 0)
                {
                    fireBullet(validTouch.Value);
                    attackCooldown = weapon.fireRate;
                }
                else
                {
                    startReloading();
                }
            }
        }
        
    }
}
