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
        }
        isGround = true;
        GameManager.Instance.OnGameOver.AddListener(HandleGameOver);

        ChangeAnim(State.Run); //�ʱ� �ִϸ��̼� ����

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGround)
            isJumpKey = true;
        else
            isJumpKey = false;
    }
    void FixedUpdate()
    {
        if (isJumpKey && isGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, Constants.STARTJUMPPOWER);
            ChangeAnim(State.Jump);
        }
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
        ObjectType objectType = collision.gameObject.GetComponent<ObjectType>();

        if (objectType != null && objectType.isCloud())
        {
            Score.Instance.UpdateScore(Constants.STARSCORE);
            collision.gameObject.SetActive(false);

            return;
        }

        GameManager.Instance.GameOver();
        
    }

    //�ִϸ��̼� ���� ���� �޼���
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);//�ִϸ��̼� ���¸� �־��� State�� ����
    }
    private void HandleGameOver()
    {
        gameObject.SetActive(false);
        ChangeAnim(State.Hit);
    }
}
