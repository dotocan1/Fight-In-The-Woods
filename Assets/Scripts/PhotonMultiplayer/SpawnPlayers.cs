using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviour
{
    PhotonView view;
    public GameObject PlayerPrefab;
    Player[] allPlayers;
    int myNumberInRoom;
    int degrees;

    public Transform[] spawnPoints;
    public float SpawnTime = 1;
    float timer;
    bool HasPlayerSpawned = false;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        allPlayers = PhotonNetwork.PlayerList;
        foreach(Player player in allPlayers) // figure out my player number in the room
        {
            if(player != PhotonNetwork.LocalPlayer)
            {
                myNumberInRoom++;
            }
        }
    }

    void Update()
    {
        if (spawnPoints[myNumberInRoom].name == "Point_A_1" || spawnPoints[myNumberInRoom].name == "Point_A_2") degrees = 90;
        else degrees = -90;

        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            if (!HasPlayerSpawned)
            {
                PhotonNetwork.Instantiate("Characters/" + PlayerPrefab.name, spawnPoints[myNumberInRoom].position, Quaternion.Euler(0,degrees,0)); 
                HasPlayerSpawned = true;
            }

            timer = 0;
        }
    }


}


