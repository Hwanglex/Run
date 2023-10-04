using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dino : MonoBehaviour
{
    public enum State
    {
        Stand,
        Jump,
        Run,
        Hit
    }

    public float startJumpPower;
    public float JumpPower;
    public bool isGround;
    public bool isJumpKey;
    public UnityEvent onHit;
    Rigidbody2D rigid;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }


    void Update()
    {    // 1. 기본 점프
        if (!GameManager.isLive)
            return;
        if (Input.GetButtonDown("Jump")&&isGround) //기본점프(=숏 점프)
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
            ChangeAnim(State.Jump);
        }
      if(Input.GetButton("Jump"))
            isJumpKey = true;
      else
            isJumpKey= false;

    }
    // 1.롱 점프
    void FixedUpdate()
    {
        if (!GameManager.isLive)
            return;
        if (isJumpKey&& !isGround)
        {
            JumpPower = Mathf.Lerp(JumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }

    // 2. 착지 (물리 충돌 이벤트)

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangeAnim(State.Run);
            JumpPower = 1;
        }
        isGround = true;
    }

   void OnCollisionExit2D(Collision2D collision)
    {
        ChangeAnim(State.Jump);
        isGround = false;


    }

    // 3. 장애물 터치 (트리거 충돌 이벤트)
    void OnTriggerEnter2D(Collider2D collision)
    {
        rigid.simulated = false;
        ChangeAnim(State.Hit);
        onHit.Invoke();
        
    }
    
    
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }

    // 1. 점프 (점프파워)
    // 2. 착지 (물리 충돌 이벤트)
    // 3. 장애물 터치 (트리거 충돌 이벤트)
    // 4. 애니메이션
    // 5. 사운드

}
