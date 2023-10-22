using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    private float score; // 현재 점수
    private static Score _instance; //싱글턴 인스턴스

    //싱글턴 패턴 구현

  
    public static Score Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Score>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<Score>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        GameManager.Instance.OnGameOver.AddListener(StopUpdatingScore);
    }
    //인스턴스 중복 체크
   
    //public static Score Instance//2싱글톤이 허접하다
    //{
    //    get
    //    {
    //        if (_instance == null) //인스턴스 생성되지 않았다면
    //        {
    //            _instance = new Score(); // 새 인스턴스 생성

    //        }
    //        return _instance;
    //    }
    //}

    public void UpdateScore(float score)
    {
        //게임이 비활성 리턴
       
        this.score += score;


    }


    public float GetScore() { return score; }

    void StopUpdatingScore()
    {
        this.enabled = false;
    }
}
