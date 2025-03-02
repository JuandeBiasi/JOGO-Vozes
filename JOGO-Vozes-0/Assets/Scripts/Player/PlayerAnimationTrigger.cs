using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void animationTrigger()
       
    {
        player.StateMachine.currentState.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
               if (hit.GetComponent<Enemy>() != null) 
               { 

                EnemyStats _target = hit.GetComponent<EnemyStats>();

                player.stats.DoDamage(_target);


                
               
               }
        }
    }

    private void ThrowSword()
    {
        SkillManager.instance.Sword.CreateSword();
    }
}
