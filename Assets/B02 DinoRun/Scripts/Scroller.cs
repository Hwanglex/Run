using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scroller : MonoBehaviour
{
    private float timeElapsed = 0;
    private float SPEED_INCREMENT = 1;
    private float globalSpeed; //전역 게임 속도
   

    void Update()
    {
        //게임이 비활성 리턴
        if (!GameManager.Instance.IsLive)
            return;
       
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 10)
        {
            globalSpeed += SPEED_INCREMENT;  // 원하는 증가량을 SPEED_INCREMENT에 정의
            timeElapsed = 0;  // 시간 초기화
        }
        //Debug.Log("Scroe" + score);
        // 오브젝트 이동 로직


        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);
        //Debug.Log("totalspeed:" + totalSpeed);

    }
}
