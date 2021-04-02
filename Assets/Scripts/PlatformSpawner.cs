﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject basicPlatform;
    [SerializeField] public GameObject parentObj;
    [SerializeField] Transform playerTransform;

    [SerializeField] GameObject[] powerUps;
    [SerializeField] GameObject[] enemyBois;
    [SerializeField] GameObject[] platforms;
    private Vector3[,] platformPositions = new Vector3[25, 10];
    private Vector2 randPos;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            for (int p = 0; p < 10; p++)
            {
                platformPositions[i, p] = new Vector3(i, p, 2);
            }
        }

        for (int i = 0; i < 20; i++)
            SpawnPlatform();
    }
    public void SpawnPlatform()
    {
        GameObject temp;
        int xPos = Random.Range(0, 25);
        int yPos = Random.Range(0, 10);
        if (Mathf.RoundToInt(Random.Range(0, 4)) == 0)
        {
            temp = Instantiate(platforms[1], randPos, Quaternion.identity);
            temp.transform.parent = parentObj.transform;
            temp.transform.localPosition = platformPositions[xPos, yPos];
        }
        else
        {
            temp = Instantiate(platforms[0], randPos, Quaternion.identity);
            
        }
        temp.transform.parent = parentObj.transform;
        temp.transform.localPosition = platformPositions[xPos, yPos];
        if (Mathf.RoundToInt(Random.Range(0,16)) == 0)
        {
            SpawnPowerup();
        }
        if (Mathf.RoundToInt(Random.Range(0, 10)) == 0)
        {
            SpawnEnemy();
        }
    }

    public void SpawnPowerup()
    {
        GameObject temp = Instantiate(powerUps[Mathf.RoundToInt(Random.Range(0,powerUps.Length))], randPos, Quaternion.identity);
        temp.transform.parent = parentObj.transform;
        temp.transform.localPosition = platformPositions[Random.Range(0, 25), Random.Range(0, 10)];
    }
    public void SpawnEnemy()
    {
        GameObject temp = Instantiate(enemyBois[Mathf.RoundToInt(Random.Range(0, enemyBois.Length))], randPos, Quaternion.identity);
        temp.transform.parent = parentObj.transform;
        temp.transform.localPosition = platformPositions[Random.Range(0, 25), Random.Range(0, 10)];
    }
}
