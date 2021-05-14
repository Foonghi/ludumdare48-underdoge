using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFader : MonoBehaviour
{
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadingVolume()
    {
        StartCoroutine(ControlFading());
    }

    IEnumerator ControlFading()
    {
        float initialVolume = myAudioSource.volume;
        while(initialVolume >= 0)
        {
            initialVolume -= 0.01f;
            myAudioSource.volume = initialVolume;
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    
}
