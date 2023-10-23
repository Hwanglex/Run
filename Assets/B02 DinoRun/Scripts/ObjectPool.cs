using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
   
    public GameObject cloudPrefab; // Cloud ������Ʈ�� Prefab

    
    private int poolSize = 50; // Ǯ�� ũ��

    private GameObject[] cloudPool; // Cloud ������Ʈ�� ������ �迭

    private void Start()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
        InitializePool();
       
        

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
   

    }

