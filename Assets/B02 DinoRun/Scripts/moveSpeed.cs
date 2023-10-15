using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarMovement : MonoBehaviour
{
    private float starTimeElapsed = Constants.TIMELAPSED;
    private float starGlobalSpeed = Constants.ONE;
    //public float Threshold = -10f;
    // 별이 움직일 속도. 음수면 왼쪽으로 움직입니다.

    void Update()
    {
        if (!GameManager.Instance.IsLive)
            return;
        starTimeElapsed  += Time.deltaTime;
        if (starTimeElapsed > Constants.SCROLLERTEN)
        {
            starGlobalSpeed += Constants.SPEEDINCREMENT;  // 원하는 증가량을 SPEED_INCREMENT에 정의
            starTimeElapsed = Constants.ZERO;  // 시간 초기화
        }
        //Debug.Log("Scroe" + score);
        // 오브젝트 이동 로직


        float starTotalSpeed = starGlobalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;

        transform.Translate(starTotalSpeed, Constants.ZERO, Constants.ZERO); // X축으로 움직입니다.

        //if (transform.position.x < someThreshold)  // someThreshold 값을 조절하여 별이 어디에서 사라질지 결정합니다.
        //{
        //    Destroy(gameObject);
        //}
    }
}
