using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New No Enemy Movement Behaviour", menuName = "Eclipse of the Labyrinth/Behaviours/Enemies/Movement Behaviours/No Enemy Movement Behaviour")]


public class NoEnemyMovementBehaviour : EnemyMovementBehaviourSO
{
    public override void EnemyMove(EnemyAI enemyAI, Vector3 playerPosition)
    {
        enemyAI.enemyRigidbody.velocity = Vector3.zero;
        return;
    }
}
