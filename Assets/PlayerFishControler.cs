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

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        pRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        KeepFishInPool();
        PlayerMoveVertical();
        PlayerMoveHorizontal();
        myAnimator.SetBool("isMoving", (playerHasHorizontalSpeed || playerHasVerticalSpeed));
        FlipSpriteInDirection();
    }

    public void LetMeGrow()
    {
        transform.localScale = new Vector2(10f, 10f);
        startingXScale = transform.localScale.x;
    }

    void KeepFishInPool()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 10f, 23f), Mathf.Clamp(transform.position.y, -4f, -12f));
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

}
