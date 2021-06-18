using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Stat")]
    public float hp;
    
    [Header("Player Move && anim")]
    public Transform groundChkFront;  // 바닥 체크 position 
    public Transform groundChkBack;   // 바닥 체크 position 
    public Transform RightwallChk;
    public Transform LeftwallChk;
    public Transform doublejumppoint;
    public Transform AtkPos;
    public float wallJumpPower = 1f;
    public float movePower = 1f;
    public float jumpPower = 1f;
    public Vector2 boxSize;
    private bool isJumping = false;
    private bool isDoubleJumping = false;
    private bool isWallJump = false;
    private bool isDie = false;
    private float slidingSpeed = 0.7f;
    private float doublepoint;

    public float wallchkDistance;
    public float groundChkDistance;
    public LayerMask WhatIsWall;
    public LayerMask WhatIsGround;
    
    private bool isRightWall;
    private bool isLeftWall;
    private bool isGround;
    private float isRight = 1;

    [Header("Atk")]
    public int damage = 20;
    public int atkNum;
    public int speed;
    public float minPos;
    public float maxPos;
    public Slider slider;
    public RectTransform pass;
    private bool isAtk = false;
    private bool isJumpingAtk = true;
    
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer sprite;
    //RaycastHit hit;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        slider.value = 0;
    }

    void Update()
    {
        bool ground_front = Physics2D.Raycast(groundChkFront.position, Vector2.down, groundChkDistance, WhatIsGround);
        bool ground_back = Physics2D.Raycast(groundChkBack.position, Vector2.down, groundChkDistance, WhatIsGround);
        
        isRightWall = Physics2D.Raycast(RightwallChk.position, Vector2.right * isRight, wallchkDistance, WhatIsWall);
        isLeftWall = Physics2D.Raycast(LeftwallChk.position, Vector2.left * isRight, wallchkDistance, WhatIsWall);

        if (!isGround && (ground_front || ground_back))
            rigid.velocity = new Vector2(rigid.velocity.x, 0);

        // 앞 또는 뒤쪽의 바닥이 감지되면 isGround 변수를 참으로!
        if (ground_front || ground_back)
            isGround = true;
        else
            isGround = false;

        animator.SetBool("isGround", isGround);

        if(isRightWall || isLeftWall){
            animator.SetBool("isSliding", true);
        }
        else{
            animator.SetBool("isSliding", false);
        }


        
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJumping") && !isDie)
        {
            animator.SetBool("isJumping", true);
            animator.SetTrigger("doJumping");
            isJumping = true;
            Jump();
        }
        else if(isDoubleJumping && Input.GetButtonDown("Jump") && doublepoint > 2.8f && !isDie)
        {
            animator.SetBool("isDoubleJumping", true);
            animator.SetTrigger("doDoubleJumping");
            DoubleJump();
        }

        if(animator.GetBool("isJumping") && Input.GetKeyDown(KeyCode.A) && isJumpingAtk && !isDie)
        {
            isJumpingAtk = false;
            animator.SetTrigger("doAtk");
        }
        else if(Input.GetKeyDown(KeyCode.A) && !isAtk && isJumpingAtk && !isDie)
        {   
            isAtk = true;
            SetAtk();
        }

        if(hp <= 0)
        {
            animator.SetTrigger("doDie");
        }

        if(isGround && rigid.velocity.y < 1)
        {
            isJumpingAtk = true;
            animator.SetBool ("isJumping", false);
            animator.SetBool ("isDoubleJumping", false);
        }

        RaycastHit2D hit =  Physics2D.Raycast(doublejumppoint.position, Vector2.down, 3, WhatIsGround);
        if(hit){
            doublepoint = ((Vector2)transform.position - hit.point).magnitude;
            // if(doublepoint > 3f)
            //     Debug.Log(doublepoint);
        }
    }

    void FixedUpdate()
    {
        Move();
        if(isRightWall)
        {
            isWallJump = false;
            Slide();
            // if(Input.GetAxisRaw("Jump") != 0)
            // {
            //     animator.SetTrigger("doWallJump");
            //     isWallJump = true;
            //     Invoke("FreezeX", 0.8f);
            //     rigid.velocity = new Vector2(-isRight * wallJumpPower, 0.9f * wallJumpPower);
            //     isRight = isRight * -1;
            //     sprite.flipX = true;
            // }
        }

        if(isLeftWall)
        {
            isWallJump = false;
            Slide();
            // if(Input.GetAxisRaw("Jump") != 0)
            // {
            //     animator.SetTrigger("doWallJump");
            //     isWallJump = true;
            //     Invoke("FreezeX", 0.8f);
            //     rigid.velocity = new Vector2(-isRight * wallJumpPower, 0.9f * wallJumpPower);
            //     isRight = isRight * -1;
            //     sprite.flipX = false;
            // }
        }
    }

    void FreezeX()
    {
        isWallJump = false;
    }

    void Move()
    {
        Vector3 moveVelcity = Vector3.zero;

        if(Input.GetAxisRaw ("Horizontal") == 0)
        {
            animator.SetBool("isMoveing", false);
        }
        else if(Input.GetAxisRaw ("Horizontal") < 0 && !isWallJump && !isDie)
        {
            moveVelcity = Vector3.left;
            isRight *= -1;
            sprite.flipX = true;
            animator.SetBool("isMoveing", true);
        }
        else if(Input.GetAxisRaw ("Horizontal") > 0 && !isWallJump && !isDie)
        {
            moveVelcity = Vector3.right;
            isRight *= 1;
            sprite.flipX = false;
            animator.SetBool("isMoveing", true);
        }

        transform.position += moveVelcity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        if(!isJumping)
            return;

        rigid.velocity = Vector2.zero;
        Vector2 jumpVelocity = new Vector2 (0, jumpPower);
        rigid.AddForce (jumpVelocity, ForceMode2D.Impulse);
        isJumping = false;
        isDoubleJumping = true;
    }

    void DoubleJump()
    {
        if(!isDoubleJumping)
            return;

        rigid.velocity = Vector2.zero; 
        Vector2 jumpVelocity = new Vector2 (0, jumpPower * 0.6f);
        rigid.AddForce (jumpVelocity, ForceMode2D.Impulse);
        isDoubleJumping = false;
    }

    void PlayAnimation(int atkNum)
    {
        animator.SetFloat("Blend", atkNum);
        animator.SetTrigger("doAtk");
    }

    void SetAtk()
    {
        slider.value = 0;
        minPos = pass.anchoredPosition.x;
        maxPos = pass.sizeDelta.x + minPos;
        StartCoroutine(ComboAtk());
    }

    void Die()
    {
        isDie = true;
        animator.SetTrigger("doDie");
    }

    void Slide()
    {
        rigid.velocity = new Vector2(rigid.velocity.x , rigid.velocity.y * slidingSpeed);
        if(isGround)
        {
            animator.Play("PlayerIdle");
        }
    }

    void Atk()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(AtkPos.position, boxSize, 0);
        foreach(Collider2D collider2D in collider2Ds)
        {
            if(collider2D.CompareTag("ENEMY"))
            {
                collider2D.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    IEnumerator ComboAtk()
    {
        yield return null;
        while(!(Input.GetKeyDown(KeyCode.A) || slider.value == slider.maxValue))
        {
            if(animator.GetBool("isJumping"))
            {
                isAtk = false;
                goto that;
            }
            else
            {
                slider.value += Time.deltaTime * speed;
                yield return null;
            }
        }
        if(slider.value >= minPos && slider.value <= maxPos)
        {
            PlayAnimation(atkNum++);
            if(atkNum < 3)
            {
                SetAtk();
            }
            else
            {
                atkNum = 0;
                SetAtk();
                // isAtk = false;
            }
            if(atkNum > 2)
            {
                atkNum = 0;
            }
        }
        else
        {
            PlayAnimation(0);
            isAtk = false;
            atkNum = 0;
        }

        that:
        slider.value = 0;
        yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundChkFront.position, Vector2.down * groundChkDistance);
        Gizmos.DrawRay(groundChkBack.position, Vector2.down * groundChkDistance);
        Gizmos.DrawRay(RightwallChk.position, Vector2.right * isRight * wallchkDistance);
        Gizmos.DrawRay(LeftwallChk.position, Vector2.left * isRight * wallchkDistance);
        Gizmos.DrawRay(doublejumppoint.position, Vector2.down * 3);
        Gizmos.DrawWireCube(AtkPos.position, boxSize);
    }

// 15점
// 플래 다이아 7점
// 허나 팀장은 무조건 4점
// 팀당 다이아 또는 플레가 한명밖에 없어야하는 구조
// 골드 4점
// 실버 3점
// 브론즈 2점
// 아이언, 언랭 1점
}
