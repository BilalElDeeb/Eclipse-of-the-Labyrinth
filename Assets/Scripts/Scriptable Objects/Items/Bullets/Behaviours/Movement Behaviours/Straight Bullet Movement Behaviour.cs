using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Straight Bullet Movement Behaviour", menuName = "Eclipse of the Labyrinth/Behaviours/Movement Behaviours/Straight Bullet Movement Behaviour")]

public class StraightBulletMovementBehaviour : BulletMovementBehaviourSO
{
    public override void BulletMove(BulletController bulletController, Vector3 direction)
    {
        bulletController.BulletRigidbody.velocity = bulletController.bulletItem.speed * direction;
    }
}
