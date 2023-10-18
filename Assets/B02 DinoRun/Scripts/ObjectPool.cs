using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
   
    public GameObject cloudPrefab; // Cloud 오브젝트의 Prefab

    
    private int poolSize = 10; // 풀의 크기

    private GameObject[] cloudPool; // Cloud 오브젝트를 저장할 배열

    private void Start()
    {
        // 오브젝트 풀 초기화
        InitializePool();
        InvokeRepeating("SpawnCloud", Constants.ZERO, Constants.SPAWNLATE);
        

    }

    private void InitializePool()
    {
        cloudPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            cloudPool[i] = Instantiate(cloudPrefab, transform);
            cloudPool[i].SetActive(false);
        }
    }

    // 풀에서 사용 가능한 오브젝트를 가져오는 함수
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < cloudPool.Length; i++)
        {
            if (!cloudPool[i].activeInHierarchy)
            {
                return cloudPool[i];
            }
        }
        return null; // 사용 가능한 오브젝트가 없을 경우 null 반환
    }

    // 오브젝트를 풀로 반환하는 함수
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    void SpawnCloud()
    {
        if (!GameManager.Instance.IsLive)
            return;
        float randomYPosition = Random.Range(Constants.ONE, Constants.THREE); // Y 위치를 랜덤하게 선택
        Vector2 spawnPosition = new Vector2(Constants.SPAWNPOSITION, randomYPosition);

        GameObject Cloud = GetPooledObject();
        if (Cloud != null)
        {
            Cloud.transform.position = spawnPosition;
            Cloud.SetActive(true);
        }

    }
}
