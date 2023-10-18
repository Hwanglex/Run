using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score
{

    private float score; // 현재 점수
    private static Score _instance; //싱글턴 인스턴스

    //싱글턴 패턴 구현

    public static Score Instance//2싱글톤이 허접하다
    {
        get
        {
            if (_instance == null) //인스턴스 생성되지 않았다면
            {
                _instance = new Score(); // 새 인스턴스 생성

            }
            return _instance;
        }
    }

    public void UpdateScore(float score)
    {
        //게임이 비활성 리턴
        if (!GameManager.Instance.IsLive)
            return;
        this.score += score;
       

    }


    public float GetScore() { return score; }


}
