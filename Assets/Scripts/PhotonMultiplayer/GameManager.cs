 using Photon.Pun;
using System.Collections;
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

     private void Start()
     {
        StartCoroutine(CreatePlayer());
         //CreatePlayer();
     }

     private IEnumerator CreatePlayer()
     {
        yield return new WaitForSeconds(2); // wait for the game object to be instantiated
         // creates player network controller but not player character
        PhotonNetwork.Instantiate("PhotonPrefabs/PhotonNetworkPlayer", transform.position, Quaternion.identity, 0);

     }

    public void TogglePause() 
    {
        if (disconnecting) return; 

        paused = !paused;
        //Debug.Log(paused);

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
        if (nextPlayersTeam == 1) nextPlayersTeam = 2;
        else nextPlayersTeam = 1;
        /*Debug.Log("PLAYER COUNT: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount % 2 == 0) nextPlayersTeam = 2;
        else nextPlayersTeam = 1;*/
    }
}
