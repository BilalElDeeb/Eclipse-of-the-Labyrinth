using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Basic Ranged Enemy Attack Behaviour", menuName = "Eclipse of the Labyrinth/Behaviours/Enemies/Attack Behaviour/Basic Ranged Enemy Attack Behaviour")]

public class BasicRangedEnemyAttackBehaviour : EnemyAttackBehaviourSO
{
    public override void EnemyAttack(BulletItem bulletItem, Vector3 direction, Vector3 bulletSpawnLocation,
        bool playerBullet, GameObject bulletPrefab)
    {
        GameObject BulletEntity = Instantiate(bulletPrefab, bulletSpawnLocation, Quaternion.identity);

        BulletEntity.GetComponent<BulletController>().initializeBullet(bulletItem, direction, playerBullet);
    }

}
