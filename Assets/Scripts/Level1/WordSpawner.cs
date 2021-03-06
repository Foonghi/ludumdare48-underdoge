using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    float delayForSpawnNewWave;
    [SerializeField] GameObject waveObject;
    [SerializeField] float delayNextWaveTimer = 6f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFirstWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFirstWave()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnNewWave());
    }

    IEnumerator SpawnNewWave()
    {
        delayForSpawnNewWave = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(delayForSpawnNewWave);
        GameObject newWaveObject = Instantiate(waveObject, transform.position, Quaternion.identity) as GameObject;
        StartCoroutine(DelayNextWave());
    }

    IEnumerator DelayNextWave()
    {
        yield return new WaitForSeconds(delayNextWaveTimer);
        StartCoroutine(SpawnNewWave());
    }
}
