using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Dino : MonoBehaviour
{
    public enum State
    {
        Stand,
        Jump,
        Run,
        Hit
    }

    private float jumpPower = Constants.JUMPPOWER;
    private bool isGround = false; //���鿡 �ִ��� ����
    private bool isJumpKey = false; // ����Ű �������� ����
   

    Rigidbody2D rigid; // ���� ������Ʈ
    Animator anim; //�ִϸ����� ������Ʈ
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������ �ٵ� ������Ʈ �ʱ�ȭ
        if (rigid == null)
        {
            Debug.LogWarning("Rigidbody2D ������Ʈ�� ����Ǿ� ���� �ʽ��ϴ�.");
                rigid = gameObject.AddComponent<Rigidbody2D>();
            rigid.gravityScale = Constants.GRAVITISCALE;
        }
        anim = GetComponent<Animator>(); //�ִϸ����� ������Ʈ �ʱ�ȭ
        if (anim == null)
        {
            Debug.LogWarning("Animator ������Ʈ�� ����Ǿ� ���� �ʽ��ϴ�.");
            //    anim = gameObject.AddComponent<Animator>();
         //out
        }

        isGround = true;
        ChangeAnim(State.Run); //�ʱ� �ִϸ��̼� ����

    }


    void Update()
    {
        if (!GameManager.Instance.IsLive) //���� ���� X ��ȯ
            return;
        //���� �Է�ó��
        if (Input.GetButtonDown("Jump") && isGround)
        
        //rigid.AddForce(Vector2.up * Constants.STARTJUMPPOWER, ForceMode2D.Impulse); //���� �� ����
        //ChangeAnim(State.Jump); //���� �ִϸ��̼� ����
        //if (Input.GetButton("Jump")) //����Ű ���� ����
            isJumpKey = true;
        else
            isJumpKey = false;
    
        //if (Input.GetButton("Jump")) //����Ű ���� ����
        //    isJumpKey = true;
        //else
        //    isJumpKey = false;

    }
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsLive)
            return;

        if (isJumpKey && isGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, Constants.STARTJUMPPOWER);
            ChangeAnim(State.Jump);
            //rigid.AddForce(Vector2.up * Constants.STARTJUMPPOWER, ForceMode2D.Impulse);
            //isJumpKey = false;
        }

        //if (isJumpKey && !isGround)
        //{
        //    jumpPower = Mathf.Lerp(jumpPower, Constants.ZERO, Constants.LERPPOWER);
        //    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}

        //if (Input.GetButtonDown("Jump") && isGround)
        //{
        //    rigid.AddForce(Vector2.up * Constants.STARTJUMPPOWER, ForceMode2D.Impulse); //���� �� ����
        //    ChangeAnim(State.Jump); //���� �ִϸ��̼� ����
        //}
        //if (Input.GetButton("Jump")) //����Ű ���� ����
        //    isJumpKey = true;
        //else
        //    isJumpKey = false;
        //if (isJumpKey && !isGround)
        //{
        //    jumpPower = Mathf.Lerp(jumpPower, Constants.ZERO, Constants.LERPPOWER);//���� �Ŀ� ����
        //    rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);//���ҵ� ���� �Ŀ� ����
        //}
    }

    // 2. ���� (���� �浹 �̺�Ʈ) �ٸ� ���� ������Ʈ�� ����ؼ� �����ϴ� ���� ȣ��

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)//���鿡 ���� ������ ����
        {
            ChangeAnim(State.Run); //�ִϸ��̼� Run ����
            jumpPower = Constants.ONE; //���� �Ŀ� �ʱ�ȭ
        }
        isGround = true; //���鿡 �����
    }

    //�ٸ� ������Ʈ�� ������ �������� ȣ��
    void OnCollisionExit2D(Collision2D collision)
    {

        ChangeAnim(State.Jump); //�ִϸ��̼� Jump ����
        isGround = false;//���鿡 ������
    }

    // 3. ��ֹ� ��ġ �ٸ� �ݸ����� ����� ���
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cloud"))
        {
            Destroy(collision.gameObject);

            return;
        }
        rigid.simulated = false; //���� ���� ����
        ChangeAnim(State.Hit); // �ִϸ��̼� Hit ����
        GameManager.Instance.GameOver(); // ���� ���� ȣ��
        GameUIManager.Instance.ShowGameOver(); //���� ���� UI ȣ��

    }

    //�ִϸ��̼� ���� ���� �޼���
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);//�ִϸ��̼� ���¸� �־��� State�� ����
    }

}
