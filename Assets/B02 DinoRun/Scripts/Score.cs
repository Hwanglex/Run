using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Score 
{
   
    private float score; // ���� ����
    private static Score _instance; //�̱��� �ν��Ͻ�

    //�̱��� ���� ����

    public static Score Instance
    {
        get
        {
            if (_instance == null) //�ν��Ͻ� �������� �ʾҴٸ�
            {
                _instance = new Score(); // �� �ν��Ͻ� ����

            }
            return _instance;
        }
    }
    
    public void UpdateScore()
    {
        //������ ��Ȱ�� ����
        if (!GameManager.Instance.IsLive)
            return;
        score += Time.deltaTime * Constants.SSPEED;//�ð��� ���� ���� ����
       
    }

    
    public void AddStarScore()
    {
        score += Constants.STARSCORE;
    }
    public float GetScore() { return score; }


}
