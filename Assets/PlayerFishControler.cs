using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishControler : MonoBehaviour
{

    [SerializeField] float playerSpeed = 5f;
    Animator myAnimator;
    Rigidbody2D pRigidbody;
    bool playerHasHorizontalSpeed;
    bool playerHasVerticalSpeed;
    float startingXScale;
    bool autoPilot = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        pRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(autoPilot)
        {
            return;
        }
        else
        {
            KeepFishInPool();
            PlayerMoveVertical();
            PlayerMoveHorizontal();
            myAnimator.SetBool("isMoving", (playerHasHorizontalSpeed || playerHasVerticalSpeed));
        }
    }


    void KeepFishInPool()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -22f, 422f), Mathf.Clamp(transform.position.y, -8f, 8f));
    }

    void PlayerMoveHorizontal()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * playerSpeed, pRigidbody.velocity.x);
        pRigidbody.velocity = playerVelocity;
        playerHasHorizontalSpeed = Mathf.Abs(pRigidbody.velocity.x) > Mathf.Epsilon;
    }

    void PlayerMoveVertical() // TODO evtl. ändern zu GetAxis?
    {
        float controlThrow = Input.GetAxis("Vertical");
        Vector2 playerVelocity = new Vector2(controlThrow * playerSpeed, pRigidbody.velocity.y);
        pRigidbody.velocity = playerVelocity;
        playerHasVerticalSpeed = Mathf.Abs(pRigidbody.velocity.y) > Mathf.Epsilon;
    }

    void FlipSpriteInDirection()
    {
        Vector2 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -startingXScale;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = startingXScale;
        }
        transform.localScale = characterScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MutterTrigger"))
        {
            autoPilot = true;
            FindObjectOfType<MutterfischMove>().setAutoPilot();
        }
    }
}
