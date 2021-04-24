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
        Debug.Log(Waypoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
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
        /*else if(collision.gameObject.CompareTag("Door"))
        {
            Object.Destroy(gameObject, 0.2f);
        }*/
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
            if(transform.position == Waypoints[Waypoints.Length - 1].position)
            {
                Debug.Log("Destroy Fishy!");
                Destroy(gameObject, 0.2f);
            }
        }
    }

    
}
