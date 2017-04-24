﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (cameraChk.transform.position.x % 20 < 5 && cameraChk.transform.position.x % 20 > -5)
        {
            if (spawnChk)
            {
                CallSpawnPlatform();
                spawnChk = false;
            }//end if
        }//end if
        else
        {
            spawnChk = true;
        }//end else
    }//end Update()

    private void CallSpawnPlatform()
    {
        SpawnPlatform(new Vector3(cameraChk.transform.position.x + 10, Random.Range(-4, 4), platformTemplate.transform.position.z), new Vector3(0.5f,2,1));
    }//end CallSpawnHealth()

    private void SpawnPlatform(Vector3 spawnPos, Vector3 spawnScale)
    {
        GameObject newPlatform = Object.Instantiate(platformTemplate, spawnPos, Quaternion.Euler(0, 0, 0));
        newPlatform.transform.localScale = spawnScale;
        newPlatform.transform.parent = gameObject.transform;
        this.gameObject.SetActive(true);
    }//end SpawnHealth()
}//end class OS_SpawnPlatforms
