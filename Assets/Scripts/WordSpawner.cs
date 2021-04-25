using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    float delayForSpawnNewWave;
    [SerializeField] GameObject waveObject;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnNewWave()
    {
        delayForSpawnNewWave = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(delayForSpawnNewWave);
        GameObject newWaveObject = Instantiate(waveObject, transform.position, Quaternion.identity) as GameObject;
    }
}
