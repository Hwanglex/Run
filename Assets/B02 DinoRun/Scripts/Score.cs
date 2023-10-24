using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
                        GameObject obj = new GameObject("Score");
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
            Destroy(gameObject);
            return;
        }
        if (this.gameObject.name != "Score")
        {
            Destroy(this);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        GameManager.Instance.OnGameOver.AddListener(StopUpdatingScore);
    }

    public void UpdateScore(float score)
    {
        this.score += score;
       
    }

    public float GetScore() { return score; }
    void StopUpdatingScore()
    {
        this.enabled = false;
    }

}
