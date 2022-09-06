using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject PlayerPrefab;
    Player[] allPlayers;
    int myNumberInRoom;
    int degrees;

    //public int nextPlayersTeam; 
    public int myTeam;
    //public Transform[] spawnPointsTeamOne;
    //public Transform[] spawnPointsTeamTwo;
    public Transform[] spawnPoints;

    public float SpawnTime = 1;
    float timer;
    bool HasPlayerSpawned = false;


    private void Start()
    {
        //view = GetComponent<PhotonView>();

        //if (view.IsMine) view.RPC("RPC_GetTeam", RpcTarget.MasterClient); // if obj belongs to the local player send the RPC fun to the obj on the master client

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
        /*if (PlayerPrefab == null && myTeam != 0) 
        {
            if (myTeam == 1)
            {
                int spawnPicker = Random.Range(0, spawnPointsTeamOne.Length);
                degrees = 90;
                
                if (view.IsMine)
                {
                    PlayerPrefab =  PhotonNetwork.Instantiate(Path.Combine("Characters", "GoodMageCharacter") , spawnPointsTeamOne[spawnPicker].position, Quaternion.Euler(0, degrees, 0));
                } 
            }
            else
            {
                int spawnPicker = Random.Range(0, spawnPointsTeamTwo.Length);
                degrees = -90;

                if (view.IsMine)
                {
                    PlayerPrefab = PhotonNetwork.Instantiate("TeamTwo/" + PlayerPrefab.name, spawnPointsTeamTwo[spawnPicker].position, Quaternion.Euler(0, degrees, 0));
                }
            }
        }*/

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
    }

    /*[PunRPC]  // only executed on the master cliend when it receives the function
    void RPC_GetTeam() 
    {
        Debug.Log("RPC_GetTeam");
        Debug.Log(GameManager.GM.nextPlayersTeam);
        myTeam = GameManager.GM.nextPlayersTeam;
        GameManager.GM.UpdateTeam();
        Debug.Log(GameManager.GM.nextPlayersTeam);
        view.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam);
    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        myTeam = whichTeam;
    }*/

}


