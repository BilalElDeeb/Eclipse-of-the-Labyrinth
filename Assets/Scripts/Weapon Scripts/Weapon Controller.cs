using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public WeaponItem weapon;
    public int currentMagazine;
    public bool isReloading = false;
    public float reloadCooldown;
    public float attackCooldown;
    public GameObject bulletPrefab;
    public Slider reloadSlider;

    // Start is called before the first frame update
    void Start()
    {
        initialize(weapon);
    }
    
    public void initialize(WeaponItem weaponItem)
    {
        if (currentMagazine > 0)
        {
            Inventory.instance.AddItem(new InventorySlot()
            {
                item = weapon.bulletItem,
                amount = currentMagazine
            });
        }
        
        this.weapon = weaponItem;
        this.GetComponent<SpriteRenderer>().sprite = weapon.itemImage;
        this.transform.localScale = new Vector3(weapon.itemScale, weapon.itemScale, 1);
        
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
            if (touch.position.x > 750 || touch.position.y > 750)
            {
                return touch;
            }
        }
        return null;
    }

    void fireBullet(Touch validTouch)
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(validTouch.position);
        touchPosition.z = 0;
        weapon.weaponAttackBehaviour.Attack(weapon.bulletItem, (touchPosition - transform.position).normalized, transform.position, true, bulletPrefab);
        currentMagazine -= 1;
    }

    void startReloading()
    {
        if (Inventory.instance.CountItem(weapon.bulletItem) > 0)
        {
            StartCoroutine(reloadUI());
            isReloading = true;
            reloadCooldown = weapon.reloadTime;
        }
    }

    IEnumerator reloadUI()
    {
        float numberOfIterations = weapon.reloadTime/0.1f;

        reloadSlider.gameObject.SetActive(true);
        
        for (int i = 0; i < numberOfIterations; i++)
        {
            yield return new WaitForSeconds(0.1f);
            reloadSlider.value = (i*0.1f)/weapon.reloadTime;
            
        }
        reloadSlider.gameObject.SetActive(false);
        
        reloadSlider.value = 0;
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
