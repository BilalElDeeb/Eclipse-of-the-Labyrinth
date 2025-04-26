using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class HumaniodEnemyAI : EnemyAI
{
    public EnemyAttackBehaviourSO enemyAttackBehaviour;
    public EnemyMovementBehaviourSO enemyMovementBehaviour;
    public GameObject bulletPrefab;
    public BulletItem bulletItem;
    public float fireRate;
    protected float attackCoolDown;
    
    // Start is called before the first frame update
    void Start()
    {
        attackCoolDown = fireRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attackCoolDown = attackCoolDown - Time.fixedDeltaTime;

        if (attackCoolDown < 0)
        {
            enemyAttackBehaviour.EnemyAttack(bulletItem, (player.transform.position - transform.position), bulletSpawnLocation.position, false, bulletPrefab);
            attackCoolDown = fireRate;
        }
        
        enemyMovementBehaviour.EnemyMove(this, player.transform.position);
        
    }
}
