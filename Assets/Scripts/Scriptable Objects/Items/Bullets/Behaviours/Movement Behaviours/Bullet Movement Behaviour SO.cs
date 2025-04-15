using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  BulletMovementBehaviourSO : ScriptableObject
{
    public abstract void BulletMove(BulletController bulletController, Vector3 direction);
}
