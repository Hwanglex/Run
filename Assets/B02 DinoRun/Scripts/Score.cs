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

    public static Score Instance
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
    
    public void UpdateScore()
    {
        //게임이 비활성 리턴
        if (!GameManager.Instance.IsLive)
            return;
        score += Time.deltaTime * Constants.SSPEED;//시간에 따라 점수 증가
       
    }

    
    public void AddStarScore()
    {
        score += Constants.STARSCORE;
    }
    public float GetScore() { return score; }


}
