using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb2D;
    private Animator playerAnim;
    [SerializeField] private float jumpingSpeed = 600f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb2D.AddForce(Vector2.up * jumpingSpeed);
            playerAnim.SetBool("player_jumping", true);
        }
        if (playerRb2D.velocity.y < 0f)
        {
            playerAnim.SetBool("player_jumping", false);
        }
    }
}
