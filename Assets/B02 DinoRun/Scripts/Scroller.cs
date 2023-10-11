using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
   
    void Update()
    {
        //������ ��Ȱ�� ����
        if (!GameManager.Instance.IsLive)
            return;
        GameManager.Instance.UpdateGame(Time.deltaTime);

        // ������Ʈ �̵� ����
        float totalSpeed = GameManager.Instance.GlobalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);
        Debug.Log("totalspeed:" + totalSpeed);

    }
}
