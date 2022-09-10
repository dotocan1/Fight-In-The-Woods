using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    //SpawnPlayers spawnPlayers;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new Photon.Realtime.RoomOptions { MaxPlayers = 4});
        //spawnPlayers = GetComponent<SpawnPlayers>();
        //spawnPlayers.enabled = true;
    }

    public void JoinRoom()
    {
        Debug.Log("JOINAM");
        PhotonNetwork.JoinRoom(joinInput.text);
        Debug.Log("OPET JOINAM");

        //spawnPlayers = GetComponent<SpawnPlayers>();
        //spawnPlayers.enabled = true;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ucitavanje levela");
        PhotonNetwork.LoadLevel("Fight_In_The_Woods");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log(message);
        ;    }

}
