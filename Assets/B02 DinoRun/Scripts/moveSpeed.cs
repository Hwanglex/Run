using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarMovement : MonoBehaviour
{
    //public float Threshold = -10f;
      // ���� ������ �ӵ�. ������ �������� �����Դϴ�.

    void Update()
    {
        transform.Translate(Constants.MOVESPEED * Time.deltaTime, Constants.ZERO, Constants.ZERO); // X������ �����Դϴ�.

        //if (transform.position.x < someThreshold)  // someThreshold ���� �����Ͽ� ���� ��𿡼� ������� �����մϴ�.
        //{
        //    Destroy(gameObject);
        //}
    }
}
