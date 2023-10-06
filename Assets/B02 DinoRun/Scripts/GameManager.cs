using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 3;
    //상수로표현할때는 앞에 const를 붙임
    private static float globalSpeed;
    private static float score;
    private static bool isLive;
 

    //public static float GlobalSpeed => _GlobalSpeed;

    

    public static float GlobalSpeed
    {
        get { return globalSpeed; }
    }

    public static bool IsLive
    {
        
        get { return isLive; }
        set { isLive = value; }
    }

    
    void Start()
    {
        IsLive = true;
    }


    void Update()
    {
        if (!IsLive)
            return;

        score += Time.deltaTime * 2;
        globalSpeed = ORIGIN_SPEED + score * 0.01f;
        Debug.Log("Scroe" + score);
        
    }

    public static void GameOver()
    {
        IsLive = false;
    }
}
