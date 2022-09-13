using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Collections;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    // lobby info
    public static CreateAndJoinRooms lobby;
    private PhotonView PV;

    public int currentScene;
    public int multiplayerScene;

    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    private void Awake()
    {
        if(CreateAndJoinRooms.lobby == null)
        {
            CreateAndJoinRooms.lobby = this;
        } else
        {
            if(CreateAndJoinRooms.lobby != this)
            {
                Destroy(CreateAndJoinRooms.lobby.gameObject);
                CreateAndJoinRooms.lobby = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
        PV = GetComponent<PhotonView>();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new Photon.Realtime.RoomOptions { MaxPlayers = 4});
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Has joined room");
        if (!PhotonNetwork.IsMasterClient) return;
        StartGame();
    }

    void StartGame()
    {
        Debug.Log("Loading main scene");
        PhotonNetwork.LoadLevel(multiplayerScene);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log(message);
    }

}
