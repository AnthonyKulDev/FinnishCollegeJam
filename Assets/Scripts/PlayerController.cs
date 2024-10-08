using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    private float horizontalInput;
    public bool gameIsOver = false;
    private bool isOnGround;
    private Rigidbody2D playerRb;
    public GameObject Player;
    public float jumpForce;
    public bool hasLens;

    

    void Start()
    {
        Player = GetComponent<GameObject>();
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Turning left&right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * horizontalInput);
        //Jumping on spacebar
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("On Ground");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Part")) {
            hasLens = true;
            Destroy(other.gameObject);
        }
    }
}
