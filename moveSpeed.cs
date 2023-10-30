using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudMovement : MonoBehaviour

{
    public GameManager gameManager;
    // 구름의 이동 속도. 기존에 있던 속도 변수
    private Vector2 screenBounds;   // 화면의 경계값
    private void Awake()
    {
        FindObjectOfType<GameManager>().OnGameOver.AddListener(StopMoveSpeed);
    }
    private void Start()
    {
        // 화면의 왼쪽 경계값을 얻습니다.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }

    private void Update()
    {
        // 구름을 왼쪽으로 이동
        transform.Translate(Vector2.left * Constants.SSPEED * Time.deltaTime);

        // 구름의 위치가 화면 왼쪽 경계보다 작으면 오브젝트를 비활성화
        if (transform.position.x < screenBounds.x - 1)  // -1은 구름의 너비
        {
            // 구름을 오브젝트 풀로 반환
            gameObject.SetActive(false);
        }
    }
    public void StopMoveSpeed()
    {
        this.enabled = false;
    }
}


