 using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject pauseMenu;
    public static bool paused = false;
    private bool disconnecting = false;

    public int nextPlayersTeam;
    public Transform[] spawnPointsTeamOne;
    public Transform[] spawnPointsTeamTwo;

    public int currentScene;

    private void OnEnable()
    {

        if (GameManager.GM == null)
        {
            GameManager.GM = this;
         
        }
        
    }
    /*public override void OnEnable()
    {
        Debug.Log("ON ENABLE");
        base.OnEnable();
        
        if (GameManager.GM == null)
        {
            GameManager.GM = this;
        }
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        // called when multiplayer scene is loaded
        currentScene = scene.buildIndex;
        Debug.Log("CURRENT SCENE: " + currentScene);
        if (currentScene == 2)
        {
            Debug.Log("CREATE PLAYEEEEER");
            CreatePlayer();
        }
    }*/

    /* private void Start()
     {
         CreatePlayer();
     }

     private void CreatePlayer()
     {
         // creates player network controller but not player character
         PhotonNetwork.Instantiate("Photon/PhotonNetworkPlayer", transform.position, Quaternion.identity, 0);
     }*/


    public void TogglePause() 
    {
        if (disconnecting) return; 

        paused = !paused;
        Debug.Log(paused);

        pauseMenu.SetActive(paused);
        Cursor.lockState = (paused) ? CursorLockMode.None : CursorLockMode.Confined;
        Cursor.visible = paused;
    }

    public void Quit()
    {
        disconnecting = true;
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Main_Menu");
    }

    public void UpdateTeam()
    {
        Debug.Log("UPDATE TEAM " + nextPlayersTeam);
        if (nextPlayersTeam == 1) nextPlayersTeam = 2;
        else nextPlayersTeam = 1;
        /*Debug.Log("PLAYER COUNT: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount % 2 == 0) nextPlayersTeam = 2;
        else nextPlayersTeam = 1;*/
    }

    /*#region Photon Callbacks

    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    #endregion Photon Callbacks


    #region Public Methods

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    #endregion Public Methods*/
}
