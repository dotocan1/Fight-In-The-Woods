using GLTF.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMinions: MonoBehaviour
{
    [SerializeField] private GameObject minion;
    private float Delay = 1f;

    //float za delay izmedju spawn wave-ova
    [SerializeField] private float SpawnDelay = 5f;

    [SerializeField] GameObject SpawnPosition;
    private int brojac;

    void Start()
    {
        brojac = 1;
        StartCoroutine(spawnMinion(Delay, minion));
    }
    
    private IEnumerator spawnMinion(float interval, GameObject Minion)
    {
        if (brojac < 4)
        {

            yield return new WaitForSeconds(Delay);
            GameObject newMinion = Instantiate(Minion, new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y + 2, SpawnPosition.transform.position.z), transform.rotation);
            StartCoroutine(spawnMinion(Delay, minion));
            brojac++;
        }
        else {

            Debug.Log("New Wave comming in " + SpawnDelay + " Seconds!");
            yield return new WaitForSeconds(SpawnDelay);
            brojac = 1;
            StartCoroutine(spawnMinion(Delay, minion));
            

        }

    }
}
//Kordinate spawn area-e A 31,2,66