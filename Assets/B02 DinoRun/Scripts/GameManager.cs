using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class GameManager
{
   
    private static GameManager _instance; //�̱��� �ν��Ͻ�
    private bool isLive = true; // ���� ���� ����
    public UnityEvent OnGameOver;
    public bool IsLive { get { return isLive; } set { isLive = value; } } //���� ���� ���� ������Ƽ

    //�̱��� ���� ����
    public static GameManager Instance
    {
        get
        {
            if (_instance == null) //�ν��Ͻ� �������� �ʾҴٸ�
            {
                _instance = new GameManager(); // �� �ν��Ͻ� ����

            }
            return _instance;
        }
    }
   
    private GameManager() //���� �Ŵ��� ������ 
    {
        OnGameOver = new UnityEvent();
    }

    public void GameOver() //���� ����
    {
        OnGameOver.Invoke();
        GameUIManager.Instance.ShowGameOver(); //���� ���� UI ȣ��
        
    }

}

