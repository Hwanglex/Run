using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
   
    public GameObject cloudPrefab; // Cloud ������Ʈ�� Prefab
    
    private List<GameObject> cloudPool; // Cloud ������Ʈ�� ������ �迭
    private int zero = Constants.INTZERO;
    private int iZero = Constants.INTZERO;
    private float poolSize = Constants.POOLSIZE;
    private void Start()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
        InitializePool();
       
    }
    private void InitializePool()
    {
        cloudPool = new List<GameObject>();

        if (cloudPrefab == null)
        {
            Debug.LogWarning("Prefab ������ ����� �Ǿ� ���� �ʽ��ϴ�.");
            GameManager.Instance.GameOver();

        }
        for (int i = zero; i < poolSize; i++)
        {
            GameObject obj = Instantiate(cloudPrefab, transform);//���� ó��
            obj.SetActive(false);
            cloudPool.Add(obj);
        }
    }
    // Ǯ���� ��� ������ ������Ʈ�� �������� �Լ�
    public GameObject GetPooledObject()
    {
        for (int i = iZero; i < cloudPool.Count; i++)
        {
            if (!cloudPool[i].activeInHierarchy)
            {
                return cloudPool[i];
            }
        }
        // ��� ������ ������Ʈ�� ���� ���, Ǯ�� ũ�⸦ Ȯ���ϰ� ���ο� ������Ʈ ��ȯ
        GameObject newObj = Instantiate(cloudPrefab, transform);
        newObj.SetActive(false);
        cloudPool.Add(newObj);
        return newObj;
    }
    // ������Ʈ�� Ǯ�� ��ȯ�ϴ� �Լ�
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    }

