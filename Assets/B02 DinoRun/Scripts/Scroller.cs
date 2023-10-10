using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
       void Start()
    {

    }


    void Update()
    {
        if (!GameManager.Instance.IsLive)
            return;

        float totalSpeed = GameManager.Instance.GlobalSpeed * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        transform.Translate(totalSpeed, 0, 0);
        Debug.Log("totalspeed:" + totalSpeed);

    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Scroller : MonoBehaviour
//{
//    private float speedRate=1;


//    void Start()
//    {

//    }


//    void Update()
//    {
//        if (!GameManager.IsLive)
//            return;

//            float totalSpeed = GameManager.GlobalSpeed * speedRate * Time.deltaTime * -1f;
//            transform.Translate(totalSpeed, 0, 0);
//        Debug.Log("totalspeed:" + totalSpeed);

//    }
//}
