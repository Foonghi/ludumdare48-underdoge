using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCarCrashSound : MonoBehaviour
{
    [SerializeField] AudioClip crashSound;
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.PlayOneShot(crashSound, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
