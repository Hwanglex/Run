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
        if (rigid == null)
        {
            Debug.LogWarning("Rigidbody2D 컴포넌트가 연결되어 있지 않습니다.");
            rigid = gameObject.AddComponent<Rigidbody2D>();
            rigid.gravityScale = Constants.GRAVITISCALE;
        }
        anim = GetComponent<Animator>(); //애니메이터 컴포넌트 초기화
        if (anim == null)
        {
            Debug.LogWarning("Animator 컴포넌트가 연결되어 있지 않습니다.");         
        }
        isGround = true;
        GameManager.Instance.OnGameOver.AddListener(HandleGameOver);

        ChangeAnim(State.Run); //초기 애니메이션 설정

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
        ObjectType objectType = collision.gameObject.GetComponent<ObjectType>();

        if (objectType != null && objectType.isCloud())
        {
            Score.Instance.UpdateScore(Constants.STARSCORE);
            collision.gameObject.SetActive(false);

            return;
        }

        GameManager.Instance.GameOver();
        
    }

    //애니메이션 상태 변경 메서드
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);//애니메이션 상태를 주어진 State로 변경
    }
    private void HandleGameOver()
    {
        gameObject.SetActive(false);
        ChangeAnim(State.Hit);
    }
}
