using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager
{
    private static GameManager _instance; //싱글턴 인스턴스
   
    private float globalSpeed; //전역 게임 속도
    public float GlobalSpeed => globalSpeed; // 전역 게임 속도 프로퍼티
    private float score; // 현재 점수
    private bool isLive = true; // 게임 진행 상태
    public bool IsLive { get { return isLive; } set { isLive = value; } } //게임 진행 상태 프로퍼티

    //싱글턴 패턴 구현
    public static GameManager Instance
    {
        get
        {
            if (_instance == null) //인스턴스 생성되지 않았다면
            {
                _instance = new GameManager(); // 새 인스턴스 생성
               
            }
            return _instance;
        }
    }

    private GameManager() //게임 매니저 생성자 
    {
       
    }

    public void UpdateGame(float deltaTime)
    {
        if (!isLive) 
            return;

        score += deltaTime * Constants.SSPEED;//시간에 따라 점수 증가
        globalSpeed = Constants.ORIGINSPEED + score * Constants.GSPEED; //게임 속도 업데이트
        Debug.Log("Scroe" + score); 
    }
    

    public void GameOver() //게임 종료
    {
        IsLive = false;
    }

}

