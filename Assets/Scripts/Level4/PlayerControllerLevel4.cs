using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLevel4 : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    Animator myAnimator;
    Rigidbody2D pRigidbody;
    bool playerHasHorizontalSpeed;
    bool playerHasVerticalSpeed;
    float startingXScale;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        pRigidbody = GetComponent<Rigidbody2D>();
        startingXScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        KeepPlayerOnFloor();
        PlayerMoveVertical();
        PlayerMoveHorizontal();
        myAnimator.SetBool("isMoving", (playerHasHorizontalSpeed || playerHasVerticalSpeed));
        FlipSpriteInDirection();
    }

    void PlayerMoveHorizontal()
    {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //Flip könnte man noch machen
        //transform.localScale = new Vector2( -1, 1);
        //transform.localRotation = Quaternion.identity;
        //transform.Rotate(0, 0, rotateSpeed);
        //transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * playerSpeed, pRigidbody.velocity.x);
        pRigidbody.velocity = playerVelocity;
        playerHasHorizontalSpeed = Mathf.Abs(pRigidbody.velocity.x) > Mathf.Epsilon;
        
    }
    /*else if (Input.GetKey(KeyCode.RightArrow))
    {
        //Flip könnte man noch machen
        //transform.localScale = new Vector2( 1, 1);
        //transform.localRotation = Quaternion.identity;
        //transform.Rotate(0, 0, -rotateSpeed);
        transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
        bool playerHasHorizontalSpeed = Mathf.Abs(pRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isMoving", true);
    }
    else { myAnimator.SetBool("isMoving", false); }
}*/

    void PlayerMoveVertical() // TODO evtl. ändern zu GetAxis?
    /*{
        
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
    }*/
    {
        float controlThrow = Input.GetAxis("Vertical");
        Vector2 playerVelocity = new Vector2(controlThrow * playerSpeed, pRigidbody.velocity.y);
        pRigidbody.velocity = playerVelocity;
        playerHasVerticalSpeed = Mathf.Abs(pRigidbody.velocity.y) > Mathf.Epsilon;
        }

    void KeepPlayerOnFloor()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -24f, 24f), Mathf.Clamp(transform.position.y, -8f, 3f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Debug.Log("Player lose.");
            StartCoroutine(DelayedGameOver());
        }
    }

    IEnumerator DelayedGameOver()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        FindObjectOfType<WinLoseConditionHandler>().PlayerLoseReloadScene();
    }

    void FlipSpriteInDirection()
    {
        Vector2 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -startingXScale;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = startingXScale;
        }
        transform.localScale = characterScale;
    }
}
