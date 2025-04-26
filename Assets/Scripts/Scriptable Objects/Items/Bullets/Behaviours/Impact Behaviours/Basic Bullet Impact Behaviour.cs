using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Basic Bullet Impact Behaviour", menuName = "Eclipse of the Labyrinth/Behaviours/Impact Behaviours/Basic Bullet Impact Behaviour")]

public class BasicBulletImpactBehaviour : BulletImpactBehaviourSO
{
    public override void BulletOnImpact(BulletController bulletController, Collider2D bulletTarget)
    {
        if (bulletTarget.gameObject.tag != "Player" && bulletController.PlayerBullet)
        {
            // Deal damage to the hp of the target based on the bulletController.bulletItem.damage
            Destroy(bulletController.gameObject);
        }
    }
}
