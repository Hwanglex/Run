
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //�̱��� �ν��Ͻ�
    private static GameUIManager _instance;
    //���� ���� �ؽ�Ʈ
    public TextMeshProUGUI gameOverText;
    public static GameUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameUIManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<GameUIManager>();
                }
            }
            return _instance;
        }
    }

    //�ν��Ͻ� �ߺ� üũ
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //���� ���� �ؽ�Ʈ �����
        gameOverText.enabled = false;
    }
    //���� ���� �ؽ�Ʈ ǥ�� �޼���
    public void ShowGameOver()
    {
        gameOverText.enabled = true;
    }

}




