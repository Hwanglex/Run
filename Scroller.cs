using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scroller : MonoBehaviour
{
    public GameManager gameManager;
    private float globalSpeed = Constants.ONE; //���� ���� �ӵ�
    private float timeElapsed = Constants.TIMELAPSED;


    private void Awake()
    {
        FindObjectOfType<GameManager>().OnGameOver.AddListener(StopScrolling);
    }

    void Update()
    {
       
        timeElapsed += Time.deltaTime;
        if (timeElapsed > Constants.SCROLLERTEN)
        {
            globalSpeed += Constants.SPEEDINCREMENT;  // ���ϴ� �������� SPEED_INCREMENT�� ����
            timeElapsed = Constants.ZERO;  // �ð� �ʱ�ȭ
        }
      


        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);


    }

    void StopScrolling()
    {
        this.enabled = false;
    }
}
