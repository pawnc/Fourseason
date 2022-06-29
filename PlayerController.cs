using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float doulbJumpSpeed;
    public float jumpSpeed;
    public float climbSpeed;

    [Header("���CD UI")]
    public Image cdImage;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;

    private bool isGround;

    private bool canDoubleJump;

    private bool isLadder;
    private bool isClimbing;

    private bool isJumping;
    private bool isFalling;
    private bool isDoubleJumping;
    private bool isDoubleFalling;
    public bool isDashing;

    private float playerGravity;

    private int jumpTimes;

    [Header("Dash����")]
    public float dashTime;
    private float dashTimeLeft;
    private float lastDash=-10f;
    public float dashCoolDown;
    public float dashSpeed;











    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        playerGravity = myRigidbody.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        cdImage = GameObject.FindGameObjectWithTag("RushUI").GetComponent<Image>();
        cdImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;

        Run();
        //Flip();
        //Jump();
        NewJump();
        Climb();


        CheckGrounded();
        PretendDeath();
        SwitchAnnimation();
        CheckAirStatus();
        CheckLadder();
        ResetJumpTimes();



        if (Input.GetButtonDown("Dash"))
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                ReadyToDash();
            }
        }



    }
    private void FixedUpdate()
    {
        Dash();

        if (isDashing)
            return;

    }
    //void Flip()//������ת.
    //{
    //    bool playerHasAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    //    if (playerHasAxisSpeed)
    //    {
    //        if (myRigidbody.velocity.x > 0.1f)
    //        {
    //            transform.localRotation = Quaternion.Euler(0, 0, 0);

    //        }
    //        if (myRigidbody.velocity.x < -0.1f)
    //        {
    //            transform.localRotation = Quaternion.Euler(0, 180, 0);

    //        }
    //    }
    //}
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        bool playerHasAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;//abs���ؾ���ֵ
        //mathf.epsilon Ϊ��Сֵ��x���ٶȴ��ڼ�Сֵʱ bool�ж����ٶ�
        myAnim.SetBool("Run", playerHasAxisSpeed);

    }
    //void Jump()
    //{
    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        if (isGround)
    //        {
    //            myAnim.SetBool("Jump", true);
    //            Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
    //            myRigidbody.velocity = Vector2.up * jumpVel;
    //            canDoubleJump = true;
    //        }
    //        else
    //        {
    //            if(canDoubleJump)
    //            {
    //                myAnim.SetBool("DoubleJump", true);
    //                Vector2 doubleJumpVel = new Vector2(0.0f,doubleJumpSpeed);
    //                myRigidbody.velocity = Vector2.up * doubleJumpVel;
    //                canDoubleJump = false;
    //            }
    //        }

    //    }
    //}
    void NewJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpTimes > 0)
            {
                jumpTimes--;
                myAnim.SetBool("Jump", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;

            }
        }
    }
    void CheckGrounded() //�鿴�Ƿ��ڵ��� 
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));

    }
    void SwitchAnnimation()  //�����л�
    {
        myAnim.SetBool("Idle", true);
        if (myAnim.GetBool("Jump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);

            }
        }
        else if (isGround)
        {
            myAnim.SetBool("Fall", false);
            myAnim.SetBool("Idle", true);
        }
        if (myAnim.GetBool("DoubleJump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("DoubleFall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("DoubleFall", false);
            myAnim.SetBool("Idle", true);
        }
    }
    void PretendDeath()
    {
        if (Input.GetButtonDown("PretendDeath"))
        {
            myAnim.SetTrigger("die");


        }

    }
    void CheckLadder() //����Ƿ���������
    {
        isLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }
    void ResetJumpTimes()
    {
        if (isGround)
        { jumpTimes = 1; }
    }
    void Climb()  //������
    {
        float moveY = Input.GetAxis("Vertical");

        if (isClimbing)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);
            canDoubleJump = false;
        }

        if (isLadder)
        {
            if (moveY > 0.5f || moveY < -0.5f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("Climbing", true);
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);
                myRigidbody.gravityScale = 0.0f;
            }
            else
            {
                if (isJumping || isFalling || isDoubleJumping || isDoubleFalling)
                {
                    myAnim.SetBool("Climbing", false);
                }
                else
                {
                    myAnim.SetBool("Climbing", false);
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);

                }
            }
        }
        else
        {
            myAnim.SetBool("Climbing", false);
            myRigidbody.gravityScale = playerGravity;
        }

        if (isLadder && isGround)
        {
            myRigidbody.gravityScale = playerGravity;
        }

    }
    void CheckAirStatus()
    {
        isJumping = myAnim.GetBool("Jump");
        isFalling = myAnim.GetBool("Fall");
        isDoubleJumping = myAnim.GetBool("DoubleJump");
        isDoubleFalling = myAnim.GetBool("DoubleFall");
        isClimbing = myAnim.GetBool("Climbing");
        //Debug.Log("isJumping:" + isJumping);
        //Debug.Log("isFalling:" + isFalling);
        //Debug.Log("isDoubleJumping:" + isDoubleJumping);
        //Debug.Log("isDoubleFalling:" + isDoubleFalling);
        //Debug.Log("isClimbing:" + isClimbing);
    }
    void Dash()
    {
        float moveDir = Input.GetAxisRaw("Horizontal");
        if(moveDir!=0)
        {
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                myRigidbody.velocity = new Vector2(dashSpeed * gameObject.transform.localScale.x, myRigidbody.velocity.y);

                dashTimeLeft -= Time.deltaTime; 

                ShadowPool.instance.GetFromPool();
            }
        }
        if(dashTimeLeft<=0)
        {
            isDashing = false;
        }
    }
    void ReadyToDash()
    {
        isDashing = true;

        dashTimeLeft = dashTime;

        lastDash = Time.time;

        cdImage.fillAmount = 1;
    }

}
