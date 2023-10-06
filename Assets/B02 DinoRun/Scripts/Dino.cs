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
   
    private  float startJumpPower =7f;
    private  float jumpPower =1f;
    private bool isGround = false;
    private bool isJumpKey = false;
    
    Rigidbody2D rigid;
    Animator anim;

    public GameUIManager gameUIManager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isGround = true;
        ChangeAnim(State.Run);

    }


    void Update()
    {   
        if (!GameManager.IsLive)
            return;
        if (Input.GetButtonDown("Jump")&&isGround) 
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
            ChangeAnim(State.Jump);
        }
      if(Input.GetButton("Jump"))
            isJumpKey = true;
      else
            isJumpKey= false;

    }
    // 1.�� ����
    void FixedUpdate()
    {
        if (!GameManager.IsLive)
            return;
        if (isJumpKey&& !isGround)
        {
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    // 2. ���� (���� �浹 �̺�Ʈ)

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangeAnim(State.Run);
            jumpPower = 1;
        }
        isGround = true;
    }

   void OnCollisionExit2D(Collision2D collision)
    {

        ChangeAnim(State.Jump);
        isGround = false;
    }

    // 3. ��ֹ� ��ġ (Ʈ���� �浹 �̺�Ʈ)
    void OnTriggerEnter2D(Collider2D collision)
    {
        rigid.simulated = false;
        ChangeAnim(State.Hit);

        GameManager.GameOver();
        gameUIManager.ShowGameOver();
    }
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }

    // 1. ���� (�����Ŀ�)
    // 2. ���� (���� �浹 �̺�Ʈ)
    // 3. ��ֹ� ��ġ (Ʈ���� �浹 �̺�Ʈ)
    // 4. �ִϸ��̼�
    // 5. ����

}
