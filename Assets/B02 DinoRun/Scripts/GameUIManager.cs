
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //싱글톤 인스턴스
    private static GameUIManager _instance;
    //게임 오버 텍스트
    public TextMeshProUGUI gameOverText;
    public static GameUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameUIManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<GameUIManager>();
                }
            }
            return _instance;
        }
    }

    //인스턴스 중복 체크
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
    void Start()
    {
        //게임 오버 텍스트 숨기기
        gameOverText.enabled = false;
    }
    //게임 오버 텍스트 표시 메서드
    public void ShowGameOver()
    {
        gameOverText.enabled = true;
    }

}




