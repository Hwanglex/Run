using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    private float globalSpeed; //전역 게임 속도
    public float starScore = 10;
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
    }
    void Update()
    {
        //게임이 비활성 리턴
        if (!GameManager.Instance.IsLive)
            return;
        score += Time.deltaTime * Constants.SSPEED;//시간에 따라 점수 증가
       

    }

    
    public void AddStarScore()
    {
        score += starScore;
    }
    public float GetScore() { return score; }


}
