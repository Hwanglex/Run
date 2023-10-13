using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarMovement : MonoBehaviour
{
    //public float Threshold = -10f;
      // 별이 움직일 속도. 음수면 왼쪽으로 움직입니다.

    void Update()
    {
        transform.Translate(Constants.MOVESPEED * Time.deltaTime, Constants.ZERO, Constants.ZERO); // X축으로 움직입니다.

        //if (transform.position.x < someThreshold)  // someThreshold 값을 조절하여 별이 어디에서 사라질지 결정합니다.
        //{
        //    Destroy(gameObject);
        //}
    }
}
