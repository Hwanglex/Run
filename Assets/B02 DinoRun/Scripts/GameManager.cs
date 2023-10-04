using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const float ORIGIN_SPEED = 3;
    //상수로표현할때는 앞에 const를 붙임
    public static float globalSpeed;
    public static float score;
    public static bool isLive;
    public GameObject uIOver;
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
        
    
    }
    public void GameOver()
    {
        //uIOver.SetActive(false);
        isLive = false;
    }
}
