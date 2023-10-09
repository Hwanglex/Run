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

    private const float startJumpPower = 7f;
    private const float JUMPPOWER = 1f;
    private const float LERPPOWER = 0.1f;
    private const float ZERO = 0;
    private const float ONE = 1;
    private float jumpPower = JUMPPOWER;
    private bool isGround = false;
    private bool isJumpKey = false;

    Rigidbody2D rigid;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isGround = true;
        ChangeAnim(State.Run);

    }


    void Update()
    {
        if (!GameManager.Instance.IsLive)
            return;
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
            ChangeAnim(State.Jump);
        }
        if (Input.GetButton("Jump"))
            isJumpKey = true;
        else
            isJumpKey = false;

    }
    // 1.�� ����
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsLive)
            return;
        if (isJumpKey && !isGround)
        {
            jumpPower = Mathf.Lerp(jumpPower, ZERO ,LERPPOWER);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    // 2. ���� (���� �浹 �̺�Ʈ)

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangeAnim(State.Run);
            jumpPower = ONE;
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
        GameManager.Instance.GameOver();
        GameUIManager.Instance.ShowGameOver();

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
