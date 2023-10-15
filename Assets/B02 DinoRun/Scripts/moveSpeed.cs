using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarMovement : MonoBehaviour
{
    private float starTimeElapsed = Constants.TIMELAPSED;
    private float starGlobalSpeed = Constants.ONE;
    //public float Threshold = -10f;
    // ���� ������ �ӵ�. ������ �������� �����Դϴ�.

    void Update()
    {
        if (!GameManager.Instance.IsLive)
            return;
        starTimeElapsed  += Time.deltaTime;
        if (starTimeElapsed > Constants.SCROLLERTEN)
        {
            starGlobalSpeed += Constants.SPEEDINCREMENT;  // ���ϴ� �������� SPEED_INCREMENT�� ����
            starTimeElapsed = Constants.ZERO;  // �ð� �ʱ�ȭ
        }
        //Debug.Log("Scroe" + score);
        // ������Ʈ �̵� ����


        float starTotalSpeed = starGlobalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;

        transform.Translate(starTotalSpeed, Constants.ZERO, Constants.ZERO); // X������ �����Դϴ�.

        //if (transform.position.x < someThreshold)  // someThreshold ���� �����Ͽ� ���� ��𿡼� ������� �����մϴ�.
        //{
        //    Destroy(gameObject);
        //}
    }
}
