 using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    PhotonView view;

    public GameObject winnerPanel;
    public GameObject pauseMenu;
    public GameObject timer;
    public GameObject text;
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
        view = GetComponent<PhotonView>();
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

    public void MatchEnd(string tag)
    {
        paused = true;
        view.RPC("RPC_End_Match_For_Everyone", RpcTarget.All, tag);
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
    }

    [PunRPC]
    void RPC_End_Match_For_Everyone(string tag)
    {
        string winnerTeam = tag == "Fountain_A" ? "2" : "1";

        winnerPanel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "TEAM " + winnerTeam + " VICTORY";
        timer.SetActive(false);
        text.SetActive(false);
        winnerPanel.SetActive(true);
        Cursor.lockState = (paused) ? CursorLockMode.None : CursorLockMode.Confined;
        Cursor.visible = paused;

        StartCoroutine(GoToMainMenu());
    }

    private IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(10);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Main_Menu");
        

    }
}
