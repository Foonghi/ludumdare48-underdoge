using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWordSpawner : MonoBehaviour
{
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


    public IEnumerator SpawnNewWave()
    {
        // TODO Sound "Inhale" left speaker

        for (int i = 0; i < 5; i++)
        {
            delayForSpawnNewWave = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(delayForSpawnNewWave);
            GameObject newWaveObject = Instantiate(waveObject, transform.position, Quaternion.identity) as GameObject;
        }
    }

    public void NextWave()
    {
        StartCoroutine(SpawnNewWave());
    }
}
