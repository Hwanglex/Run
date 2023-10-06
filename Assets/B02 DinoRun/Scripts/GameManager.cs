using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 3;
    //상수로표현할때는 앞에 const를 붙임
    private static float globalSpeed = 0f;
    private static float score = 0f;
    private static bool isLive = false;
 

    //public static float GlobalSpeed => _GlobalSpeed;

    

    public static float GlobalSpeed
    {
        get { return globalSpeed; }
    }

    public static bool IsLive
    {
        
        get { return isLive; }
    }

    
    void Start()
    {
        isLive = true;
    }


    void Update()
    {
        if (!isLive)
            return;

        score += Time.deltaTime * 2;
        globalSpeed = ORIGIN_SPEED + score * 0.01f;
        Debug.Log("Scroe" + score);
        
    }

    public static void GameOver()
    {
        isLive = false;
    }
}
