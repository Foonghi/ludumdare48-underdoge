using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyController : MonoBehaviour
{
    [SerializeField] Transform wPoint1;
    bool triggerIsTrue = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerIsTrue)
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
            Debug.Log("Player entered Trigger");
            triggerIsTrue = true;
        }
    }

    void MoveToPosition()
    {
        if (transform.position == wPoint1.position)
        {
            triggerIsTrue = false;
            return;
        }
        else
        {
            var movementThisFrame = 2f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, wPoint1.position, movementThisFrame);
        }
    }

    
}
