﻿using UnityEngine;

public class OS_SpawnPlatforms : MonoBehaviour
{
    public GameObject platformTemplate;
    public GameObject cameraChk;
    private bool spawnChk;

    private void Start()
    {
        platformTemplate = GameObject.Find("InitPlatform");
        cameraChk = GameObject.Find("Main Camera");
        spawnChk = true;
    }//end Start()

    private void Update()
    {
        if (cameraChk.transform.position.x % 6 < 2 && cameraChk.transform.position.x % 6 > -2 && cameraChk.transform.position.x > 10)
        {
            if (spawnChk)
            {
                CallSpawnPlatforms();
                spawnChk = false;
            }//end if
        }//end if
        else
        {
            spawnChk = true;
        }//end else
    }//end Update()

    private void CallSpawnPlatforms()
    {
        SpawnPlatform(new Vector3(cameraChk.transform.position.x + (10 + Random.Range(0.0f, 8.0f)), Random.Range(-4.5f, 4.5f), platformTemplate.transform.position.z), new Vector3(0.5f, Random.Range(2, 4), 1), 90 * (int)(Random.Range(0, 2)));
        SpawnPlatform(new Vector3(cameraChk.transform.position.x + (10 + Random.Range(0.0f, 8.0f)), Random.Range(-4.5f, 4.5f), platformTemplate.transform.position.z), new Vector3(0.5f, Random.Range(1, 3), 1), 90 * (int)(Random.Range(0, 2)));
        SpawnPlatform(new Vector3(cameraChk.transform.position.x + (10 + Random.Range(0.0f, 8.0f)), Random.Range(-4.5f, 4.5f), platformTemplate.transform.position.z), new Vector3(0.5f, Random.Range(1, 3), 1), 90 * (int)(Random.Range(0, 2)));
    }//end CallSpawnHealth()

    private void SpawnPlatform(Vector3 spawnPos, Vector3 spawnScale, int rotation)
    {
        GameObject newPlatform = Object.Instantiate(platformTemplate, spawnPos, Quaternion.Euler(0, 0, rotation));
        newPlatform.transform.localScale = spawnScale;
        newPlatform.transform.parent = gameObject.transform;
        this.gameObject.SetActive(true);
    }//end SpawnHealth()
}//end class OS_SpawnPlatforms
