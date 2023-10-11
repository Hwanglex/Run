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
    private bool isGround = false; //지면에 있는지 여부
    private bool isJumpKey = false; // 점프키 눌렀는지 여부
   

    Rigidbody2D rigid; // 물리 컴포넌트
    Animator anim; //애니메이터 컴포넌트
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // 리지드 바디 컴포넌트 초기화
        anim = GetComponent<Animator>(); //애니메이터 컴포넌트 초기화

        isGround = true;
        ChangeAnim(State.Run); //초기 애니메이션 설정

    }


    void Update()
    {
        if (!GameManager.Instance.IsLive) //게임 진행 X 반환
            return;
        //점프 입력처리
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigid.AddForce(Vector2.up * Constants.STARTJUMPPOWER, ForceMode2D.Impulse); //점프 힘 적용
            ChangeAnim(State.Jump); //점프 애니메이션 변경
        }
        if (Input.GetButton("Jump")) //점프키 누름 여부
            isJumpKey = true;
        else
            isJumpKey = false;

    }
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsLive)
            return;
        if (isJumpKey && !isGround)
        {
            jumpPower = Mathf.Lerp(jumpPower, Constants.ZERO, Constants.LERPPOWER);//점프 파워 감소
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);//감소된 점프 파워 적용
        }
    }

    // 2. 착지 (물리 충돌 이벤트) 다른 물리 오브젝트와 계속해서 접촉하는 동안 호출

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)//지면에 닿지 않을때 실행
        {
            ChangeAnim(State.Run); //애니메이션 Run 변경
            jumpPower = Constants.ONE; //점프 파워 초기화
        }
        isGround = true; //지면에 닿았음
    }

    //다른 오브젝트와 접촉을 끝냈을때 호출
    void OnCollisionExit2D(Collision2D collision)
    {

        ChangeAnim(State.Jump); //애니메이션 Jump 변경
        isGround = false;//지면에 떨어짐
    }

    // 3. 장애물 터치 다른 콜리더에 닿았을 경우
    void OnTriggerEnter2D(Collider2D collision)
    {
        rigid.simulated = false; //물리 적용 중지
        ChangeAnim(State.Hit); // 애니메이션 Hit 변경
        GameManager.Instance.GameOver(); // 게임 오버 호출
        GameUIManager.Instance.ShowGameOver(); //게임 오버 UI 호출

    }

    //애니메이션 상태 변경 메서드
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);//애니메이션 상태를 주어진 State로 변경
    }

}
