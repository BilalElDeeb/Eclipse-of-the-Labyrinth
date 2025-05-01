using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviourSO : ScriptableObject
{
    public abstract void Attack(BulletItem bulletItem, Vector3 direction, Vector3 bulletSpawnLocation, bool playerBullet, GameObject bulletPrefab);
}
