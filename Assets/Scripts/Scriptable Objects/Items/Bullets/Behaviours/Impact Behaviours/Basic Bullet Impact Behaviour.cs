using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Basic Bullet Impact Behaviour", menuName = "Eclipse of the Labyrinth/Behaviours/Bullets/Impact Behaviours/Basic Bullet Impact Behaviour")]

public class BasicBulletImpactBehaviour : BulletImpactBehaviourSO
{
    public override void BulletOnImpact(BulletController bulletController, Collider2D bulletTarget)
    {
        if (!bulletController.PlayerBullet && bulletTarget.tag == "Player")
        {
            bulletTarget.GetComponent<PlayerHealth>().takeDamage(bulletController.bulletItem.damage);
        }
        else if (bulletController.PlayerBullet && bulletTarget.tag == "Enemy")
        {
            bulletTarget.GetComponent<EnemyAI>().takeDamage(bulletController.bulletItem.damage);
        }
        Destroy(bulletController.gameObject);
    }
}
