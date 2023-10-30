
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameUIManager : MonoBehaviour
{
    
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI ScoreText;
    public Score score;
   
    //인스턴스 중복 체크
    private void Awake()
    {
      
    }
    void Start()
    {
        //게임 오버 텍스트 숨기기
        gameOverText.enabled = false;
        ScoreText.enabled = true;

    }

    void Update()
    {
        ScoreText.text = "Score: " +score.GetScore().ToString("0");
    }
    //게임 오버 텍스트 표시 메서드
    public void ShowGameOver()
    {
        gameOverText.enabled = true;
    }

}



