using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFishToLight : MonoBehaviour
{
    Vector2 waypoint;
    bool goFishy = false;
    // Start is called before the first frame update
    void Start()
    {
        waypoint = new Vector2(20f, -10f);
        StartCoroutine(DelayFishGo());
    }

    // Update is called once per frame
    void Update()
    {
        if(!goFishy)
        {
            return;
        }
        else
        {
            var movementThisFrame = 1f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, waypoint, movementThisFrame);
        }
    }

    IEnumerator DelayFishGo()
    {
        yield return new WaitForSeconds(2f);
        goFishy = true;
    }
}


