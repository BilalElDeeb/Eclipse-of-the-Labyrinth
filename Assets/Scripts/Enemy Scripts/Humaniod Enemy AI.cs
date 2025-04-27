using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumaniodEnemyAI : EnemyAI
{
    public EnemyAttackBehaviourSO enemyAttackBehaviour;
    public EnemyMovementBehaviourSO enemyMovementBehaviour;
    public GameObject bulletPrefab;
    public BulletItem bulletItem;
    public float fireRate;
    protected float attackCoolDown;
    public AnimationClip attackAnimationClip;
    public AnimationClip dyingAnimationClip;
    public AnimationClip hurtAnimationClip;
    public AnimationClip idleAnimationClip;
    public AnimationClip runningAttackAnimationClip;
    public AnimationClip runningAnimationClip;
    public AnimationClip walkingAnimationClip;
    protected Vector3 lastPosition;
    
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetAnimations();
        attackCoolDown = fireRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lastPosition != null)
        {
            animator.SetFloat("Speed", Vector3.Distance(transform.position, lastPosition) / Time.fixedDeltaTime);
        }
        lastPosition = transform.position;
        attackCoolDown = attackCoolDown - Time.fixedDeltaTime;
        
        enemyMovementBehaviour.EnemyMove(this, player.transform.position);

        

        if (attackCoolDown <= 0)
        {
            enemyAttackBehaviour.EnemyAttack(bulletItem, (player.transform.position - transform.position).normalized, bulletSpawnLocation.position, false, bulletPrefab);
            attackCoolDown = fireRate;
            animator.SetTrigger("Attack");
        }
        
        Vector3 Direction = (player.transform.position - transform.position).normalized;

        if (Direction.x >= 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }
        
    }

    void SetAnimations()
    {
        AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        
        Debug.Log("HAI");
        
        animatorOverrideController ["Idle Placeholder"] = idleAnimationClip;
        animatorOverrideController ["Walking Placeholder"] = walkingAnimationClip;
        animatorOverrideController ["Running Placeholder"] = runningAnimationClip;
        animatorOverrideController["Attack Placeholder"] = attackAnimationClip;
        animatorOverrideController["Dying Placeholder"] = dyingAnimationClip;
        animatorOverrideController["Hurt Placeholder"] = hurtAnimationClip;
        animatorOverrideController["Running Attack Placeholder"] = runningAttackAnimationClip;
        
        animator.runtimeAnimatorController = animatorOverrideController;
    }
}
