using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{

    // LateUpdate ������Ʈ ��ġ �缳��
    void LateUpdate()
    {
        // ���ǵ� ��ġ���� �����ʿ������� ���� �ڵ� ���� ���� ����
        if (transform.position.x > Constants.POSITION)
            return;

        //������Ʈ�� �ٽ� ���� ��ġ��
        transform.Translate(Constants.REPOSITION, Constants.ZERO, Constants.ZERO, Space.Self);
        //������ǥ
    }
}

