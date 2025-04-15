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
        initializeBullet(bulletItem, Vector3.right);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletItem.bulletMovementBehaviour.BulletMove(this, this.bulletDirection);
    }

    public void initializeBullet(BulletItem bulletItem, Vector3 bulletDirection)
    {
        this.bulletItem = bulletItem;
        bulletSpriteRenderer.sprite = bulletItem.itemImage;
        this.bulletDirection = bulletDirection;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        bulletItem.bulletImpactBehaviour.BulletOnImpact(this, collider);
    }
}
