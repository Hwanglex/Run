using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
   
    private float globalSpeed;
    private float score;
    private bool isLive = false;
    public bool IsLive { get { return isLive; } set { isLive = value; } }
    public float GlobalSpeed => globalSpeed;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject singletonObj = new GameObject("GameManager");
                    _instance = singletonObj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
    }

    void Start()
    {
        isLive = true;
    }


    void Update()
    {
        if (!isLive)
            return;

        score += Time.deltaTime * Constants.SSPEED;
        globalSpeed = Constants.ORIGINSPEED + score * Constants.GSPEED;
        Debug.Log("Scroe" + score);

    }


    public void GameOver()
    {
        IsLive = false;
    }

    // 기타 게임 매니저 코드 (게임 상태 관리, UI 업데이트, 이벤트 처리 등)
}

//usi