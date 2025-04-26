using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovementBehaviourSO : ScriptableObject
{
    public abstract void EnemyMove(EnemyAI enemyAI, Vector3 playerPosition);
}
