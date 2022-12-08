using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
   

{
    [SerializeField]
    private float moveForce = 10; 

    [SerializeField]
    private float jumpForce = 11f;

    public bool isGrounded;

    [SerializeField]
    GameObject boomPic;

    private float movePlayerOnX;

    private float attackPlayerOnX;

    public static Rigidbody2D myBody;

    public int PlayerOneHealth = 3;
    public bool IsPlayerOneDead
    {
        get
        {
            return PlayerOneHealth == 0;
        }
    }

    private SpriteRenderer sr;
    private Animator anim;

    private string ATTACK_ANIMATION = "Attack";
    private string RUN_ANIMATION = "Run";
    private string ENEMY_TAG = "Enemy";

    //inheritance;

    public Player() { }

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerFight();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard() {

        movePlayerOnX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movePlayerOnX, 0f, 0f) * Time.deltaTime * moveForce;

    }

   void AnimatePlayer() {
 if (movePlayerOnX > 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
            sr.flipX = false; 
        }
 else if (movePlayerOnX < 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
            sr.flipX = true;
        }
 else
        {
            anim.SetBool(RUN_ANIMATION, false);
        }

    }

   void PlayerFight()
    {
        if  (Input.GetKeyDown(KeyCode.P)) {

            anim.SetBool(ATTACK_ANIMATION, true);

        } else
        {
            anim.SetBool(ATTACK_ANIMATION, false);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

       if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Instantiate(boomPic, new Vector3(transform.position.x + 1f, transform.position.y, 0f), Quaternion.identity);
            anim.SetTrigger("DeadAnimation");
           // Destroy(gameObject, DeadAnimation.length);
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            isGrounded = false; 
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    /*public void PlayerOneIsDamaged(int amount)
    {
        PlayerOneHealth -= amount;
        if (PlayerOneHealth < 0)
            PlayerOneHealth = 0;

        if (IsPlayerOneDead)
        {
            anim.SetTrigger("DeadAnimation");
        }
    }*/
/*
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            anim.SetTrigger("DeadAnimation");
        }
    }*/

   
/*
    IEnumerator TheDeathOfPlayerOne()
    {
        while ()
    }*/
}
