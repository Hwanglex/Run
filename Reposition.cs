using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{

    // LateUpdate 오브젝트 위치 재설정
    void LateUpdate()
    {
        // 정의된 위치보다 오른쪽에있으면 다음 코드 실행 하지 않음
        if (transform.position.x > Constants.POSITION)
            return;

        //오브젝트를 다시 시작 위치로
        transform.Translate(Constants.REPOSITION, Constants.ZERO, Constants.ZERO, Space.Self);
        //절대좌표
    }
}

