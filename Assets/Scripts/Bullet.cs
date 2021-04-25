using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float waveSpeed;
    Vector3 targetPos;
 

    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.Find("Player").transform.position; // Targets the players position at the moment of each prefabs instantiation
    }

    // Update is called once per frame
    void Update()
    {
        //targetPos = GameObject.Find("Player").transform.position; // Follows target everywhere
        
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
        if(collision.CompareTag("Bullet")) { return; }
        else
        {
            Debug.Log("Destroyed hit Target");
            Destroy(gameObject);
        }
    }
}
