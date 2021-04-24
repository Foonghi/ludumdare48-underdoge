using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float rotateSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveForward();
        PlayerRotate();
    }

    void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotateSpeed);
            //transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotateSpeed);
            //transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
        }
    }

    void PlayerMoveForward() // TODO evtl. �ndern zu GetAxis?
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
        }
      
    }
}
