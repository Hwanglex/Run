using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private const float ORIGIN_SPEED = 3;
    private const float SSPEED = 1f;
    private const float GSPEED = 0.01f;
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
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isLive = true;
    }


    void Update()
    {
        if (!isLive)
            return;

        score += Time.deltaTime * SSPEED;
        globalSpeed = ORIGIN_SPEED + score * GSPEED;
        Debug.Log("Scroe" + score);

    }
    
  
    public void GameOver()
    {
        IsLive = false;
    }

    // 기타 게임 매니저 코드 (게임 상태 관리, UI 업데이트, 이벤트 처리 등)
}

//public class GameManager : MonoBehaviour
//{





//    public static void GameOver()
//    {
//        isLive = false;
//    }
//}
