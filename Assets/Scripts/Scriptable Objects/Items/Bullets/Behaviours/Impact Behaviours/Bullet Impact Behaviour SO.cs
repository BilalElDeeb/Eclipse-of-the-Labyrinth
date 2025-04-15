using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletImpactBehaviourSO : ScriptableObject
{
    public abstract void BulletOnImpact(BulletController bulletController, Collider2D bulletTarget);
}
