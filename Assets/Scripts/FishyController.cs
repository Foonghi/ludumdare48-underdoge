using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyController : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] Transform[] Waypoints; // array to store Waypoints in inspector
    public bool fishEscapeDoor = false;
    [SerializeField] float fishySpeed = 1f; // travelspeed of fishy
    
    bool triggerWaypoint = false; // Checks if player triggered fishys collider and start MoveToPosition() in update
    int wPointsCounter = 0; // Store length of array of Waypoints[] 

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
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
        else
        {
            if(wPointsCounter < Waypoints.Length)
            {
                triggerWaypoint = true; // enables MoveToPosition() in Update
                myAnimator.SetBool("IsMoving", true);
            }
        }
    }

    void MoveToPosition() // Moves Fishy to next Waypoint
    {
        if (transform.position == Waypoints[wPointsCounter].position) // if fishy has arrived at next waypoint
        {
            triggerWaypoint = false; // deactivates MoveToPosition() in Update
            wPointsCounter++; // next waypoint to travel to (0 + 1 = Waypoints[1])
            myAnimator.SetBool("IsMoving", false);
            SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
            if(myRenderer.flipX)
            {
                myRenderer.flipX = false;
            }
            else
            {
                if(wPointsCounter >= 3)
                {
                    return;
                }
                else
                {
                    myRenderer.flipX = true;
                }
                
            }
        }
        else 
        {
            var movementThisFrame = fishySpeed * Time.deltaTime; // fetch speed to move fishy each frame
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[wPointsCounter].position, movementThisFrame); // moves fishy
            if(transform.position == Waypoints[Waypoints.Length - 1].position) // if fishy reaches final waypoint (last in array = 5 - 1 = 4, weil wegen von 0 angefangen zu zählen und so)
            {
                fishEscapeDoor = true; // Tells DoorTransition.cs fishy has reached its final waypoint at the door 
                StartCoroutine(DelayFishyVanishing());
            }
        }
    }

    IEnumerator DelayFishyVanishing() // Wait 1 second, then fishy vanish
    { 
        yield return new WaitForSeconds(1f);
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.enabled = false; // Sets fishy invisible
    }
}
