using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public PhotonView view;
    public GameObject PlayerPrefab;
    int degrees;
    public int myTeam;


    private void Start()
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine) view.TransferOwnership(PhotonNetwork.LocalPlayer);
        if (view.IsMine) view.RPC("RPC_GetTeam", RpcTarget.MasterClient);
        Debug.Log("VIEW IS MINE " + view.IsMine);
        Debug.Log("MOJ NOVI TEAM: " + myTeam);
    }

    void Update()
    {
        Debug.Log("AAAAAAAAA");
        Debug.Log("MY TEAM: " + myTeam);
        Debug.Log(PlayerPrefab == null);
        if (PlayerPrefab == null && myTeam != 0)
        {
            Debug.Log("EVOOOO");
            if (myTeam == 1)
            {
                degrees = 90;
                int spawnPicker = Random.Range(0, GameManager.GM.spawnPointsTeamOne.Length);
                if (view.IsMine)
                {
                    PlayerPrefab = PhotonNetwork.Instantiate("Characters/WarriorCharacter", GameManager.GM.spawnPointsTeamOne[spawnPicker].position, Quaternion.Euler(0, degrees, 0));
                    Debug.Log("SPAWNAM PRVOG");
                }
            }
            else
            {
                degrees = -90;
                int spawnPicker = Random.Range(0, GameManager.GM.spawnPointsTeamTwo.Length);
                if (view.IsMine)
                {
                    PlayerPrefab = PhotonNetwork.Instantiate("Characters/BadMageCharacter", GameManager.GM.spawnPointsTeamTwo[spawnPicker].position, Quaternion.Euler(0, degrees, 0));
                    Debug.Log("SPAWNAM DRUGOG LIKA");
                }
            }
        }

    }

    [PunRPC]
    void RPC_GetTeam() // sent to the master client and executed there
    {
        myTeam = GameManager.GM.nextPlayersTeam;
        GameManager.GM.UpdateTeam();
        Debug.Log("GET TEAM " + myTeam);
        view.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam); // broadcast value myTeam to all clients
    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)  
    {
        myTeam = whichTeam;
    }
     
    /*PhotonView view;
    public GameObject PlayerPrefab;
    Player[] allPlayers;
    int myNumberInRoom;
    int degrees;

    public int myTeam;
    public Transform[] spawnPoints;

    public float SpawnTime = 1;
    float timer;
    bool HasPlayerSpawned = false;


    private void Start()
    {
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
        if(spawnPoints[myNumberInRoom].name == "Point_A_1" || spawnPoints[myNumberInRoom].name == "Point_A_2") degrees = 90;
        else degrees = -90;

        timer += Time.deltaTime;
        if (timer >= SpawnTime)
        {
            if (!HasPlayerSpawned)
            {
                PhotonNetwork.Instantiate("Characters/WarriorCharacter", spawnPoints[myNumberInRoom].position, Quaternion.Euler(0,degrees,0)); 
                HasPlayerSpawned = true;
            }

            timer = 0;
        }
    }*/

}


