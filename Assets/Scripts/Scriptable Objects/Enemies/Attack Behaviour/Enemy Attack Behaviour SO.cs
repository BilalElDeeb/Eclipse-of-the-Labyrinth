using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackBehaviourSO : ScriptableObject
{
    public abstract void EnemyAttack(BulletItem bulletItem, Vector3 direction, Vector3 bulletSpawnLocation, bool playerBullet, GameObject bulletPrefab);
}
