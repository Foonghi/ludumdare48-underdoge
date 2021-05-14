using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWordSpawner : MonoBehaviour
{
    [SerializeField] AudioClip motherSound;
    float delayForSpawnNewWave;
    [SerializeField] GameObject waveObject;
    //[SerializeField] float delayNextWaveTimer = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnNewWave()
    {
        // TODO Sound "Inhale" right speaker
        for(int i = 0;i<5;i++)
        {
            delayForSpawnNewWave = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(delayForSpawnNewWave);
            GameObject newWaveObject = Instantiate(waveObject, transform.position, Quaternion.identity) as GameObject;
            newWaveObject.AddComponent<AudioSource>();
            newWaveObject.GetComponent<AudioSource>().panStereo = 1;
            newWaveObject.GetComponent<AudioSource>().PlayOneShot(motherSound, 0.1f);
            // play clip
        }
       
        
    }

    public void NextWave()
    {
        StartCoroutine(SpawnNewWave());
    }
}
