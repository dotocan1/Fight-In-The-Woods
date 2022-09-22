using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Timer : MonoBehaviour
{
    public Text gameTimerText;
    float gametimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            gametimer += Time.deltaTime;
            int seconds = (int)(gametimer % 60);
            int minutes = (int)(gametimer / 60);

            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

            gameTimerText.text = timerString;
        }
    }
}
