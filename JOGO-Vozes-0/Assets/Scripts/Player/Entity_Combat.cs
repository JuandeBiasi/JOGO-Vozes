using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    public Collider2D[] targetColliders;


    [Header("Target Detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius;
    [SerializeField] private LayerMask whatIsTarget;


    public void PerformAttack()
    {
        GetDetectedCollliders();
    }

    private void GetDetectedCollliders () 
        {
        targetColliders = Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, whatIsTarget);

        }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position,targetCheckRadius);
    }
}
