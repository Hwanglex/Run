using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    private float score; // 현재 점수
    public GameManager gameManager;
   
    private void Awake()
    {
     
        FindObjectOfType<GameManager>().OnGameOver.AddListener(StopUpdatingScore);
    }
   
    private void Update()
    {
        score += Time.deltaTime * Constants.SSPEED;
    }


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
