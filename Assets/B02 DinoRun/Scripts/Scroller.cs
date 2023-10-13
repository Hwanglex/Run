using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scroller : MonoBehaviour
{
    private float globalSpeed; //���� ���� �ӵ�
   
    private float score; // ���� ����

    void Update()
    {
        //������ ��Ȱ�� ����
        if (!GameManager.Instance.IsLive)
            return;
        score += Time.deltaTime * Constants.SSPEED;//�ð��� ���� ���� ����
        globalSpeed = Constants.ORIGINSPEED + score * Constants.GSPEED; //���� �ӵ� ������Ʈ
        //Debug.Log("Scroe" + score);
        // ������Ʈ �̵� ����
        float totalSpeed = globalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);
        //Debug.Log("totalspeed:" + totalSpeed);

    }
}
