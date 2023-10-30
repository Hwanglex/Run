using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class GameManager : MonoBehaviour
{
    private bool isLive = true; // 게임 진행 상태
    public UnityEvent OnGameOver;
    public bool IsLive { get { return isLive; } set { isLive = value; } } //게임 진행 상태 프로퍼티

    private void Awake()
    {
        OnGameOver = new UnityEvent();
    }

    public void GameOver() //게임 종료
    {
        OnGameOver.Invoke();
        FindObjectOfType<GameUIManager>().ShowGameOver();
        //GameUIManager.Instance.ShowGameOver(); //게임 오버 UI 호출
        
    }

}

