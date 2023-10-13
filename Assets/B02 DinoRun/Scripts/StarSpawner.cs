using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    


    void Start()
    {
        InvokeRepeating("SpawnStar", Constants.ZERO, Constants.SPAWNLATE);
    }

    void SpawnStar()
    {
        float randomYPosition = Random.Range(Constants.ONE, Constants.THREE); // Y 위치를 랜덤하게 선택
        Vector2 spawnPosition = new Vector2( Constants.SPAWNPOSITION , randomYPosition);

        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
       
    }
    void Update()
    {
        //float Speed = 3 * Constants.SPEEDRATE * Time.deltaTime * Constants.MSPEEDRATE;
        //transform.Translate(Speed, Constants.ZERO, Constants.ZERO);
        //if (transform.position.x > Constants.POSITION)
        //    return;
        //transform.Translate(Constants.REPOSITION, Constants.ZERO, Constants.ZERO, Space.Self);
    }

}
