using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public bool PlayerBullet = true;
    public BulletItem bulletItem;
    public Rigidbody2D bulletRigidbody;
    public SpriteRenderer bulletSpriteRenderer;
    private Vector3 bulletDirection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletItem.bulletMovementBehaviour.BulletMove(this, this.bulletDirection);
    }

    public void initializeBullet(BulletItem bulletItem, Vector3 bulletDirection, bool playerBullet)
    {
        this.bulletItem = bulletItem;
        bulletSpriteRenderer.sprite = bulletItem.itemImage;
        this.bulletDirection = bulletDirection;
        this.PlayerBullet = playerBullet;
        
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
        
        bulletSpriteRenderer.gameObject.transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (PlayerBullet && collider.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (!PlayerBullet && collider.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        bulletItem.bulletImpactBehaviour.BulletOnImpact(this, collider);
    }
}
