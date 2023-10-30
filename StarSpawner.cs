using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class StarSpawner : MonoBehaviour
{

    private ObjectPooler objectpooler;


    void Start()
    {
        objectpooler = FindObjectOfType<ObjectPooler>();
        InvokeRepeating("SpawnCloud", Constants.ZERO, Constants.SPAWNLATE);
    }
    private void Awake()
    {
        FindObjectOfType<GameManager>().OnGameOver.AddListener(StopSpawner);
    }
    void SpawnCloud()
    {
        float randomYPosition = Random.Range(Constants.ONE, Constants.THREE); // Y 위치를 랜덤하게 선택
        Vector2 spawnPosition = new Vector2(Constants.SPAWNPOSITION, randomYPosition);

        GameObject Cloud = objectpooler.GetPooledObject();
        if (Cloud != null)
        {
            Cloud.transform.position = spawnPosition;
            Cloud.SetActive(true);
        }
    }

    private void StopSpawner()
    {
        this.enabled = false;
    }

}
