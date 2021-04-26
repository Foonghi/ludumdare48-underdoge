using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevel1 : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    Animator myAnimator;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveUpAndDown();
        PlayerRotate();
    }

    void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Flip könnte man noch machen
            //transform.localScale = new Vector2( -1, 1);
            //transform.localRotation = Quaternion.identity;
            //transform.Rotate(0, 0, rotateSpeed);
            transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
            myAnimator.SetBool("isMoving", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //Flip könnte man noch machen
            //transform.localScale = new Vector2( 1, 1);
            //transform.localRotation = Quaternion.identity;
            //transform.Rotate(0, 0, -rotateSpeed);
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            myAnimator.SetBool("isMoving", true);
        }
        else { myAnimator.SetBool("isMoving", false); }
    }

    void PlayerMoveUpAndDown() // TODO evtl. ändern zu GetAxis?
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
            myAnimator.SetBool("isMoving", true);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
            myAnimator.SetBool("isMoving", true);
        }
        else { myAnimator.SetBool("isMoving", false); }
    }
}
