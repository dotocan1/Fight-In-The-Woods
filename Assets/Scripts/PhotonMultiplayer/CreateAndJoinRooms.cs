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

    public override void OnEnable()
    {
        Debug.Log("ON ENABLE");
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Debug.Log("ON DISABLE");
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
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
        //PhotonNetwork.LoadLevel("Fight_In_The_Woods");
        //myAvatar = PhotonNetwork.Instantiate("PhotonNetworkPlayer", transform.position, Quaternion.identity, 0);
        //DontDestroyOnLoad(myAvatar);
    }

    void StartGame()
    {
        GameObject player;
        Debug.Log("Loading main scene");
        PhotonNetwork.LoadLevel(multiplayerScene);
        //CreatePlayer();
       //player = PhotonNetwork.Instantiate("Photon/PhotonNetworkPlayer", transform.position, Quaternion.identity, 0);
        //DontDestroyOnLoad(player);
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
        // called when multiplayer scene is loaded
        currentScene = scene.buildIndex;
        Debug.Log("CURRENT SCENE: " + currentScene);
        if(currentScene == multiplayerScene)
        {
            Debug.Log("CREATE PLAYEEEEER");
            CreatePlayer();
        }
    }

    //[PunRPC]
    private void CreatePlayer()
    {
        // creates player network controller but not player character
        PhotonNetwork.Instantiate("Photon/PhotonNetworkPlayer", transform.position, Quaternion.identity, 0);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log(message);
    }

}
