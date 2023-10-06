using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{

    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    public void ShowGameOver()
    {
        gameOverText.enabled = true;
    }
}
