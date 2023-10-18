using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;



    void Start()
    {
        InvokeRepeating("SpawnCloud", Constants.ZERO, Constants.SPAWNLATE);
    }

    void SpawnCloud()
    {
        if (!GameManager.Instance.IsLive)
            return;
        float randomYPosition = Random.Range(Constants.ONE, Constants.THREE); // Y 위치를 랜덤하게 선택
        Vector2 spawnPosition = new Vector2(Constants.SPAWNPOSITION, randomYPosition);

        Instantiate(starPrefab, spawnPosition, Quaternion.identity);

    }
    void Update()
    {
    }

}
