using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class GameManager : MonoBehaviour
{
    private bool isLive = true; // ���� ���� ����
    public UnityEvent OnGameOver;
    public bool IsLive { get { return isLive; } set { isLive = value; } } //���� ���� ���� ������Ƽ

    private void Awake()
    {
        OnGameOver = new UnityEvent();
    }

    public void GameOver() //���� ����
    {
        OnGameOver.Invoke();
        FindObjectOfType<GameUIManager>().ShowGameOver();
        //GameUIManager.Instance.ShowGameOver(); //���� ���� UI ȣ��
        
    }

}

