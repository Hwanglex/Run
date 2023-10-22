using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    private float score; // ���� ����
    private static Score _instance; //�̱��� �ν��Ͻ�

    //�̱��� ���� ����

  
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
    //�ν��Ͻ� �ߺ� üũ
   
    //public static Score Instance//2�̱����� �����ϴ�
    //{
    //    get
    //    {
    //        if (_instance == null) //�ν��Ͻ� �������� �ʾҴٸ�
    //        {
    //            _instance = new Score(); // �� �ν��Ͻ� ����

    //        }
    //        return _instance;
    //    }
    //}

    public void UpdateScore(float score)
    {
        //������ ��Ȱ�� ����
       
        this.score += score;


    }


    public float GetScore() { return score; }

    void StopUpdatingScore()
    {
        this.enabled = false;
    }
}
