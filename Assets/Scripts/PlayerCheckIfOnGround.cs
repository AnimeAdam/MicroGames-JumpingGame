using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckIfOnGround : MonoBehaviour
{
    public bool isOnGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("You are on the ground");
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("You are off the ground");
            isOnGround = false;
        }
    }
}
