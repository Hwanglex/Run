using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
   
    public GameObject cloudPrefab; // Cloud 오브젝트의 Prefab
    
    private List<GameObject> cloudPool; // Cloud 오브젝트를 저장할 배열
    private int zero = Constants.INTZERO;
    private int iZero = Constants.INTZERO;
    private float poolSize = Constants.POOLSIZE;
    private void Start()
    {
        // 오브젝트 풀 초기화
        InitializePool();
       
    }
    private void InitializePool()
    {
        cloudPool = new List<GameObject>();

        if (cloudPrefab == null)
        {
            Debug.LogWarning("Prefab 연결이 제대로 되어 있지 않습니다.");
            GameManager.Instance.GameOver();

        }
        for (int i = zero; i < poolSize; i++)
        {
            GameObject obj = Instantiate(cloudPrefab, transform);//예외 처리
            obj.SetActive(false);
            cloudPool.Add(obj);
        }
    }
    // 풀에서 사용 가능한 오브젝트를 가져오는 함수
    public GameObject GetPooledObject()
    {
        for (int i = iZero; i < cloudPool.Count; i++)
        {
            if (!cloudPool[i].activeInHierarchy)
            {
                return cloudPool[i];
            }
        }
        // 사용 가능한 오브젝트가 없을 경우, 풀의 크기를 확장하고 새로운 오브젝트 반환
        GameObject newObj = Instantiate(cloudPrefab, transform);
        newObj.SetActive(false);
        cloudPool.Add(newObj);
        return newObj;
    }
    // 오브젝트를 풀로 반환하는 함수
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    }

