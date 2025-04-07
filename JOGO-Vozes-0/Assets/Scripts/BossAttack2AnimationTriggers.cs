using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BossAttack2AnimationTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy2 => GetComponentInParent<Enemy_Skeleton>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private Vector3 _position;
    [SerializeField] private Player player;

    private void AnimationTrigger2() 
    {
        enemy2.AnimationFinishTrigger();
        animator.Play("BossAttack2Idle");
    }

    private void StartTrigger2()
    {
        _position = player.transform.position;
        var transformPosition = new Vector2(_position.x, spriteRenderer.transform.position.y);
        spriteRenderer.transform.position = transformPosition;
        animator.Play("BossAttack2");
    }

    private void AttackTrigger2()
    {
        var colliders = Physics2D.OverlapCircleAll(_position, enemy2.attackCheckRadius * 0.6f);

        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                PlayerStats target = hit.GetComponent<PlayerStats>();
                enemy2.stats.DoDamage(target);
                
            }
        }
    }

    private void OpenCounterAttack2Window() => enemy2.OpenCounterAttackWindow();
    private void CloseCounterAttack2Window() => enemy2.CloseCounterAttackWindow();
}
