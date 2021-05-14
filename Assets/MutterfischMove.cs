using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutterfischMove : MonoBehaviour
{
    bool goMuddi = false;
    Vector2 waypoint;
    // Start is called before the first frame update
    void Start()
    {
        waypoint = new Vector2(260f, 0f);   
    }

    // Update is called once per frame
    void Update()
    {
        if(goMuddi)
        {
            var movementThisFrame = 3f * Time.deltaTime; // fetch speed to move fishy each frame
            transform.position = Vector2.MoveTowards(transform.position, waypoint, movementThisFrame); // moves fishy
        }
        else
        {
            return;
        }
    }

    public void setAutoPilot()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        goMuddi = true;
    }

}
