using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : Player

{
    [SerializeField]
    private float moveEnemyForce = 2;
   
    private Rigidbody2D EnemyBody;
    private SpriteRenderer srEnemy;
    private Animator animEnemy;
    private string ATTACK_ANIMATION = "Attack";
    private string RUN_ANIMATION = "Run";

    private SpriteRenderer sre;



    private void Awake()
     {
         EnemyBody = GetComponent<Rigidbody2D>();
         animEnemy = GetComponent<Animator>();
         srEnemy = GetComponent<SpriteRenderer>();
     }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyMovement());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyJump();
    }

    private void LateUpdate()
    {
        MoveEnemy();
    }


    // The Enemy is moving towards the player direction
    void MoveEnemy()
    {

       // EnemyBody = moveEnemyForce;
       if (Mathf.Abs(myBody.transform.position.x - EnemyBody.transform.position.x)> 8)
        {
            transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * moveEnemyForce;
            animEnemy.SetBool(RUN_ANIMATION, true);
        }
        else if ( myBody.transform.position.x < 0) 
        {

            transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveEnemyForce;
            animEnemy.SetBool(RUN_ANIMATION, true);
        }
        else
        {
            animEnemy.SetBool(RUN_ANIMATION, false);
        }

    }

    // wORKING ON NEW FEATURES HERE (Enemy Jump Feature) 
   void EnemyJump()
    {
        //When Player1 Jump Enemy JUMP
        if (myBody.transform.position.y> 0.50 ) {
     
            transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * moveEnemyForce ;
        }
        // 
        else if ( myBody.transform.position.y >0  && EnemyBody.transform.position.x== 0)
        {
            transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * moveEnemyForce;
            animEnemy.SetBool(RUN_ANIMATION, true);
        }
/*        else if ( myBody.transform.position.x > 0.50 && EnemyBody.transform.position.x > 0)
        {
          
            transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveEnemyForce;
            animEnemy.SetBool(RUN_ANIMATION, true);
            sre.flipX = false;
          
      
        }*/
    }

    IEnumerator EnemyMovement()
    {
     while(true) {

            

            if (Mathf.Abs(myBody.transform.position.x - EnemyBody.transform.position.x)< 2)
            {
                animEnemy.SetBool(ATTACK_ANIMATION, true);
            } else
            {
                animEnemy.SetBool(ATTACK_ANIMATION, false);
            }
            
            yield return new WaitForSeconds(.1f);

        }


    }



   



}
