using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
   
    void Update()
    {
        //게임이 비활성 리턴
        if (!GameManager.Instance.IsLive)
            return;
        GameManager.Instance.UpdateGame(Time.deltaTime);

        // 오브젝트 이동 로직
        float totalSpeed = GameManager.Instance.GlobalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, Constants.ZERO, Constants.ZERO);
        Debug.Log("totalspeed:" + totalSpeed);

    }
}
