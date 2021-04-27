using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioClip : MonoBehaviour
{
    AudioSource cameraAudioSource;
    [SerializeField] AudioClip erloesungClip;

    // Start is called before the first frame update
    void Start()
    {
        cameraAudioSource = FindObjectOfType<IchBinDieScheissCamera>().GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cameraAudioSource.clip = erloesungClip;
            cameraAudioSource.Play();
            cameraAudioSource.volume = 0.01f;
        }
        else
        {
            return;
        }
    }
}
