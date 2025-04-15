using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Eclipse of the Labyrinth/Items/Bullet")]

public class BulletItem : ItemSO
{
    public float speed;
    public float damage;
    
    public BulletMovementBehaviourSO bulletMovementBehaviour;
    public BulletImpactBehaviourSO bulletImpactBehaviour;
}
