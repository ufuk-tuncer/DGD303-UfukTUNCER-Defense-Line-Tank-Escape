using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int poolSize = 5;
    [SerializeField] float waitTime = 1;

    GameObject[] pool;

     void Awake()
    {
        CreatePool();   
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    void CreatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);

        }
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            EnablePoolObjects();
            yield return new WaitForSeconds(waitTime);
        }
    }

    void EnablePoolObjects()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy==false)
            {
                pool[i].SetActive (true);
                return;
            }
        }
    }
}
