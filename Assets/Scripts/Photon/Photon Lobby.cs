using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject playButton;

    private void Awake()
    {
        lobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // connect to master photon server
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon server.");
        playButton.SetActive(true); // if connected then you can play
    }

    public void OnPlayButtonClicked()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Main_Menu");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
