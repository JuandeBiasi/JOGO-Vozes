using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CSE_Wander : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float leftPatrolLX, rightPatrolX;

    [SerializeField] private float minPauseTime, maxPauseTime;
    [SerializeField] private float minWalkTime, maxWalkTime;

     private int facingDirection = 1;

    private float randomTime, timer;
    private bool isWalking = true;
    private bool isFlipping;


    private void Awake()
    {
       
            facingDirection = 1;
        

    }
    private void Start()
    {
        randomTime = Random.Range(minWalkTime, maxWalkTime);
        anim.SetBool("isWalking", isWalking ? true : false);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= randomTime)
            stateChange();


        if (!isFlipping && (transform.position.x > rightPatrolX || transform.position.x < leftPatrolLX)) { 
            Debug.Log ("Tentou flipar");
           StartCoroutine(Flip());
             }
            
       if(isWalking) 
        rb.velocity = Vector2.right * facingDirection * speed;
    }

    IEnumerator Flip()
    {
        isFlipping = true;
        transform.Rotate(0, 180, 0);
        facingDirection *= -1;
        yield return new WaitForSeconds(0.5f);
        isFlipping = false;
    }
        void stateChange()
    {
        isWalking = !isWalking;
        anim.SetBool("isWalking", isWalking? true:false);
        randomTime = isWalking ? Random.Range(minWalkTime,maxWalkTime) : Random.Range(minPauseTime, maxPauseTime);
        timer = 0;
    }
}
