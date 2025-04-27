using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chase Enemy Movement Behaviour", menuName = "Eclipse of the Labyrinth/Behaviours/Enemies/Movement Behaviours/Chase Enemy Movement Behaviour")]

public class ChaseEnemyMovementBehaviour : EnemyMovementBehaviourSO
{
    public override void EnemyMove(EnemyAI enemyAI, Vector3 playerPosition)
    {
        Vector3 direction = playerPosition - enemyAI.transform.position;

        enemyAI.enemyRigidbody.velocity = direction.normalized * enemyAI.speed;
    }
}