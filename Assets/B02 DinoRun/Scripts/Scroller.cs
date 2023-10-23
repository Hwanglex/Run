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
        if (!GameManager.Instance.IsLive) //1
            return;
        Score.Instance.UpdateScore(Time.deltaTime * Constants.SSPEED);
        timeElapsed += Time.deltaTime;
        if (timeElapsed > Constants.SCROLLERTEN)
        {
            globalSpeed += Constants.SPEEDINCREMENT;  // 원하는 증가량을 SPEED_INCREMENT에 정의
            timeElapsed = Constants.ZERO;  // 시간 초기화
        }
        //Debug.Log("Scroe" + score);
        // 오브젝트 이동 로직


        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);


    }
    void StopScrolling()
    {
        this.enabled = false;
    }
}
