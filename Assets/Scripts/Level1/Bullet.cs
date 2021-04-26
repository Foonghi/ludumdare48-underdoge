using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float waveSpeed;
    Vector3 targetPos;
    [SerializeField] bool autoFollowTargetOn;
 

    // Start is called before the first frame update
    void Start()
    {
        if(!autoFollowTargetOn)
        {
            targetPos = GameObject.Find("Player").transform.position; // Targets the players position at the moment of each prefabs instantiation
            transform.right = targetPos - transform.position;
        }
        else { return; }
    }

    // Update is called once per frame
    void Update()
    {
        if(autoFollowTargetOn)
        {
            targetPos = GameObject.Find("Player").transform.position; // Follows target everywhere
            transform.right = targetPos - transform.position;
        }
        

        var movementThisFrame = waveSpeed * Time.deltaTime; // fetch speed to move fishy each frame
        transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame); // moves fishy
        if(transform.position == targetPos)
        {
            Debug.Log("Destroyed missing Target");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        
    {
        if(collision.CompareTag("Bullet") ||collision.CompareTag("Background")) { return; }
        else
        {
            Debug.Log("Triggered by " + collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
