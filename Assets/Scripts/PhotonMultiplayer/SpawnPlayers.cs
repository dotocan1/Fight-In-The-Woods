using UnityEngine;
using Photon.Pun;
using System.Collections;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public PhotonView view;
    public GameObject PlayerPrefab;
    int degrees;
    public int myTeam;


    private void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine) view.RPC("RPC_GetTeam", RpcTarget.MasterClient);
    }

    void Update()
    {
        if (PlayerPrefab == null && myTeam != 0)
        {
            if (myTeam == 1)
            {
                degrees = 90;
                int spawnPicker = PhotonNetwork.LocalPlayer.ActorNumber / 2;
                if (view.IsMine)
                {
                    PlayerPrefab = PhotonNetwork.Instantiate("Characters/BadMageCharacter", GameManager.GM.spawnPointsTeamOne[spawnPicker].position, Quaternion.Euler(0, degrees, 0));
                    PlayerPrefab.tag = "Team_1";
                }
            }
            else
            {
                degrees = -90;
                int spawnPicker = PhotonNetwork.LocalPlayer.ActorNumber / 2;
                if (view.IsMine)
                {
                    PlayerPrefab = PhotonNetwork.Instantiate("Characters/ArcherCharacter", GameManager.GM.spawnPointsTeamTwo[spawnPicker].position, Quaternion.Euler(0, degrees, 0));
                    PlayerPrefab.tag = "Team_2";
                }
            }
        }

    }

    [PunRPC]
    void RPC_GetTeam() // sent to the master client and executed there
    {
        myTeam = GameManager.GM.nextPlayersTeam;
        GameManager.GM.UpdateTeam();
        view.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam); // broadcast value myTeam to all clients
    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        myTeam = whichTeam;
    }
}


