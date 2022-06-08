using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviour
{
    PhotonView view;
    public GameObject PlayerPrefab;
    Player[] allPlayers;
    int myNumberInRoom;

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
        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            if (!HasPlayerSpawned)
            {
                PhotonNetwork.Instantiate("Characters/" + PlayerPrefab.name, spawnPoints[myNumberInRoom].position, Quaternion.identity); 
                HasPlayerSpawned = true;
            }

            timer = 0;
        }
    }


}


