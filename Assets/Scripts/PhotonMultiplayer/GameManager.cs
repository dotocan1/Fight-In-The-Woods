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
    //public Transform[] spawnPointsTeamOne;
    //public Transform[] spawnPointsTeamTwo;

    private void OnEnable()
    {
        if(GameManager.GM == null)
        {
            GameManager.GM = this;
        }
    }

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
        Debug.Log(nextPlayersTeam);
        if (nextPlayersTeam == 1) nextPlayersTeam = 2;
        else nextPlayersTeam = 1;
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
