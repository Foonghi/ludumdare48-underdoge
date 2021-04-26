using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSpawners : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SelectNextSpawnside", 3f, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectNextSpawnside()
    {
        int randomSide = Random.Range(0, 2);
        Debug.Log(randomSide);
        ContactSpawnSide(randomSide);
    }

    void ContactSpawnSide(int contactThisSide)
    {
        if(contactThisSide <= 0)
        {
            // Left side
            FindObjectOfType<LeftWordSpawner>().NextWave();
        }
        else
        {
            // right side
            FindObjectOfType<RightWordSpawner>().NextWave();
        }
    }
}
