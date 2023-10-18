using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
   
    public GameObject cloudPrefab; // Cloud ������Ʈ�� Prefab

    
    private int poolSize = 10; // Ǯ�� ũ��

    private GameObject[] cloudPool; // Cloud ������Ʈ�� ������ �迭

    private void Start()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
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

    // Ǯ���� ��� ������ ������Ʈ�� �������� �Լ�
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < cloudPool.Length; i++)
        {
            if (!cloudPool[i].activeInHierarchy)
            {
                return cloudPool[i];
            }
        }
        return null; // ��� ������ ������Ʈ�� ���� ��� null ��ȯ
    }

    // ������Ʈ�� Ǯ�� ��ȯ�ϴ� �Լ�
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    void SpawnCloud()
    {
        if (!GameManager.Instance.IsLive)
            return;
        float randomYPosition = Random.Range(Constants.ONE, Constants.THREE); // Y ��ġ�� �����ϰ� ����
        Vector2 spawnPosition = new Vector2(Constants.SPAWNPOSITION, randomYPosition);

        GameObject Cloud = GetPooledObject();
        if (Cloud != null)
        {
            Cloud.transform.position = spawnPosition;
            Cloud.SetActive(true);
        }

    }
}
