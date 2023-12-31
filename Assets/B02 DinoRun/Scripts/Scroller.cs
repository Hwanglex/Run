using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scroller : MonoBehaviour
{

    private float globalSpeed = Constants.ONE; //전역 게임 속도
    private float timeElapsed = Constants.TIMELAPSED;
    private void Awake()
    {
        GameManager.Instance.OnGameOver.AddListener(StopScrolling);
    }
    void Update()
    {
        //게임이 비활성 리턴
        Score.Instance.UpdateScore(Time.deltaTime * Constants.SSPEED);
        timeElapsed += Time.deltaTime;
        if (timeElapsed > Constants.SCROLLERTEN)
        {
            globalSpeed += Constants.SPEEDINCREMENT;  // 원하는 증가량을 SPEED_INCREMENT에 정의
            timeElapsed = Constants.ZERO;  // 시간 초기화
        }
        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);
    }
    void StopScrolling()
    {
        gameObject.SetActive(false);
    }
}
