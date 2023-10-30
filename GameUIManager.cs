
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
   
    //�ν��Ͻ� �ߺ� üũ
    private void Awake()
    {
      
    }
    void Start()
    {
        //���� ���� �ؽ�Ʈ �����
        gameOverText.enabled = false;
        ScoreText.enabled = true;

    }

    void Update()
    {
        ScoreText.text = "Score: " +score.GetScore().ToString("0");
    }
    //���� ���� �ؽ�Ʈ ǥ�� �޼���
    public void ShowGameOver()
    {
        gameOverText.enabled = true;
    }

}



