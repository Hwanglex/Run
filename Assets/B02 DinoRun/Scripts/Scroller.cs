using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scroller : MonoBehaviour
{
    private float timeElapsed = 0;
    private float SPEED_INCREMENT = 1;
    private float globalSpeed; //���� ���� �ӵ�
   

    void Update()
    {
        //������ ��Ȱ�� ����
        if (!GameManager.Instance.IsLive)
            return;
       
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 10)
        {
            globalSpeed += SPEED_INCREMENT;  // ���ϴ� �������� SPEED_INCREMENT�� ����
            timeElapsed = 0;  // �ð� �ʱ�ȭ
        }
        //Debug.Log("Scroe" + score);
        // ������Ʈ �̵� ����


        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);
        //Debug.Log("totalspeed:" + totalSpeed);

    }
}
