 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    Rigidbody2D rigid;
    public Transform ground;
    public LayerMask whatIsGround;
    public bool isGround;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        GroundCheck();
    }


    public void Move()
    {
        if (Input.GetKey(KeyCode.A)) // a�� ������ ������
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // �������� �̵��Ѵ�
        }
        // �ؿ� �ڵ带 �����غ��ô�.
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); 
        }


    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rigid.AddForce(Vector2.up * jumpPower*100);
            isGround = false;
        }   
    }

    private void GroundCheck()
    {
        if (rigid.velocity.y < 0)
        {
            isGround = Physics2D.OverlapCircle(ground.position, 0.2f, whatIsGround); // �������� 0.2�� ���� ground�� ������ isGround�� true�� �ٲ��ִ°�
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Trap" && col.gameObject.tag == "DieCol") // trap, DieCol �±׸� ���� ������Ʈ�� ������
        {
            speed = 0;
            jumpPower = 0;
            //anim.Play("Die");
            //�÷��̾ ������ ����� �ִϸ��̼�, �������� ���ϰ� ���ǵ�� �������� 0����
        }
    }
}
