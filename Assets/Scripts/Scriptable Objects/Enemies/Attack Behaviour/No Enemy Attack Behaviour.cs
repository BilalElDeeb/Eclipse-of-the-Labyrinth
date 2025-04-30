using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New No Enemy Attack Behaviour", menuName = "Eclipse of the Labyrinth/Behaviours/Enemies/Attack Behaviour/No Enemy Attack Behaviour")]


public class NoEnemyAttackBehaviour : EnemyAttackBehaviourSO
{
    public override void EnemyAttack(BulletItem bulletItem, Vector3 direction, Vector3 bulletSpawnLocation,
        bool playerBullet, GameObject bulletPrefab)
    {
        return;
    }

}
