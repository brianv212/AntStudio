using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 10;
    private float moveX;
    private bool facingRight = true;

    // Update is called once per frame
    void Update() {
        PlayerMove();
    }

    void PlayerMove() {
        // Controls
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        // Animations
        // Player Direction

        if (moveX > 0.0f && facingRight == false) {
            FlipPlayer();
        }
        else if (moveX < 0.0f && facingRight == true) {
            FlipPlayer();
        }

        // Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        // Vector2 localScale = gameObject.transform.localScale;
        // localScale.x *= -1;
        // transform.localScale = localScale;
        transform.Rotate(0f, 180f, 0f);
    }


}
