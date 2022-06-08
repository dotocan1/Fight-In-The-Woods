using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{ 
    public GameObject PlayerPrefab;
    public float SpawnTime = 1;
    float timer;
    bool HasPlayerSpawned = false;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY; 
    public float minZ;
    public float maxZ;

    private void Start()
    {
       
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            if (!HasPlayerSpawned)
            {
                Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                PhotonNetwork.Instantiate("Characters/" + PlayerPrefab.name, randomPosition, Quaternion.identity); //Quaternion indentiy - nema rotacije! 
                HasPlayerSpawned = true;
            }

            timer = 0;
        }
    }


}


