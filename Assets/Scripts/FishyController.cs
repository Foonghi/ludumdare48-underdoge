using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyController : MonoBehaviour
{

    [SerializeField] Transform[] Waypoints;
    
    bool triggerWaypoint = false;
    int wPointsCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wPointsCounter);
        if(triggerWaypoint)
        {
            MoveToPosition();
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            triggerWaypoint = true;
        }
    }

    void MoveToPosition()
    {
        if (transform.position == Waypoints[wPointsCounter].position)
        {
            triggerWaypoint = false;
            wPointsCounter++;
            return;
        }
        else 
        {
            var movementThisFrame = 7f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[wPointsCounter].position, movementThisFrame);
        }
    }

    
}
