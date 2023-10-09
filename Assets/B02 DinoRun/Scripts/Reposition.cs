using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private const float POSITION = -12;
    private const float REPOSITION = 24;
    private const float ZERO = 0;
    void LateUpdate()
    {
        if (transform.position.x > POSITION)
            return;

        transform.Translate(REPOSITION, ZERO, ZERO, Space.Self);
        //Àý´ëÁÂÇ¥
    }
}
