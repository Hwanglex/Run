using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private const float SPEEDRATE = 1;
    private const float MSPEEDRATE = -1f;

    void Start()
    {

    }


    void Update()
    {
        if (!GameManager.Instance.IsLive)
            return;

        float totalSpeed = GameManager.Instance.GlobalSpeed * SPEEDRATE * Time.deltaTime * MSPEEDRATE;
        transform.Translate(totalSpeed, 0, 0);
        Debug.Log("totalspeed:" + totalSpeed);

    }
}
