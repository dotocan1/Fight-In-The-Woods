using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioSettings : MonoBehaviour
{
    private bool isMoving;
    

    private AudioSource SoundPlayer;
    //public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        SoundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.R) || !Input.GetKeyDown(KeyCode.R))
        {
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.S)))
            {
                PlayerFootstep();
                isMoving = true;
            }
            else
            {
                isMoving = false;
                SoundPlayer.Stop();
            }
        }

    }

    private void PlayerFootstep()
    {
        if (isMoving = true && !SoundPlayer.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                SoundPlayer.pitch = Random.Range(0.95f, 1.05f);
                SoundPlayer.volume = 0.03f;
                SoundPlayer.PlayDelayed(0.18f);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                SoundPlayer.pitch = Random.Range(0.95f, 1.05f);
                SoundPlayer.volume = 0.03f;
                SoundPlayer.Play();
            }
        }
    }

}

