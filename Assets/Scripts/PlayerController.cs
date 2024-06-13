using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb2D;
    private Animator playerAnim;
    private PlayerCheckIfOnGround checkOnGround;

    [SerializeField] private bool jumpingState = false;
    [SerializeField] private bool fallingState = false;
    [SerializeField] private float jumpingSpeed = 600f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        checkOnGround = GetComponentInChildren<PlayerCheckIfOnGround>();
    }

    // Update is called once per frame
    void Update()
    {
        PressSpaceToJump();
        AnimateFalling();
        StopJumpingAnimation();
    }

    public void StopJumpingAnimation()
    {
        if (fallingState && checkOnGround.isOnGround)
        {
            jumpingState = false;
            fallingState = false;
            playerAnim.SetTrigger("player_stopJumping");
        }
    }

    //Checks if player is falling then animates falling
    private void AnimateFalling()
    {
        if (playerRb2D.velocity.y < 0f && jumpingState)
        {
            playerAnim.SetBool("player_jumping", false);
            fallingState = true;
        }
    }

    //Presses space to jump and animates jumping up.
    private void PressSpaceToJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumpingState && checkOnGround.isOnGround)
        {
            playerRb2D.AddForce(Vector2.up * jumpingSpeed);
            playerAnim.SetBool("player_jumping", true);
            jumpingState = true;
        }
    }
}
