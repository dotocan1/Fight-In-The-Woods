using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    private AudioSource SoundPlayer;
    public AudioClip[] footstep;


    private void Awake()
    {
        SoundPlayer = GetComponent<AudioSource>();
    }

    void Start()
    {
      
        SoundPlayer.clip = footstep[Random.Range(0, footstep.Length)];
        SoundPlayer.PlayOneShot(SoundPlayer.clip);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
