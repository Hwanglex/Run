using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scroller : MonoBehaviour
{
    private float globalSpeed; //전역 게임 속도
   
    private float score; // 현재 점수

    void Update()
    {
        //게임이 비활성 리턴
        if (!GameManager.Instance.IsLive)
            return;
        score += Time.deltaTime * Constants.SSPEED;//시간에 따라 점수 증가
        globalSpeed = Constants.ORIGINSPEED + score * Constants.GSPEED; //게임 속도 업데이트
        //Debug.Log("Scroe" + score);
        // 오브젝트 이동 로직
        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);
        //Debug.Log("totalspeed:" + totalSpeed);

    }
}
