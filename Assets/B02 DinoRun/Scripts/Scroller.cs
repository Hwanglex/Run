using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scroller : MonoBehaviour
{

    private float globalSpeed = Constants.ONE; //���� ���� �ӵ�
    private float timeElapsed = Constants.TIMELAPSED;
    private void Awake()
    {
        GameManager.Instance.OnGameOver.AddListener(StopScrolling);
    }

    void Update()
    {
        //������ ��Ȱ�� ����
        if (!GameManager.Instance.IsLive) //1
            return;
        Score.Instance.UpdateScore(Time.deltaTime * Constants.SSPEED);
        timeElapsed += Time.deltaTime;
        if (timeElapsed > Constants.SCROLLERTEN)
        {
            globalSpeed += Constants.SPEEDINCREMENT;  // ���ϴ� �������� SPEED_INCREMENT�� ����
            timeElapsed = Constants.ZERO;  // �ð� �ʱ�ȭ
        }
        //Debug.Log("Scroe" + score);
        // ������Ʈ �̵� ����


        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);


    }
    void StopScrolling()
    {
        this.enabled = false;
    }
}
