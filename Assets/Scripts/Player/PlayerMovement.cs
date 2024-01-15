using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerCharacter;

    Rigidbody2D body;

    Vector2 input;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        input = new Vector2(inputX, inputY);
        if (input.magnitude > 0.1)
            input.Normalize();

        UpdatePlayerDirection(inputX);
        HandlePlayerAnimation();
    }

    private void FixedUpdate()
    {
        body.velocity = input * runSpeed;
    }

    void UpdatePlayerDirection(float horizontalDirection)
    {
        if (horizontalDirection < 0) playerCharacter.GetComponent<SpriteRenderer>().flipX = true;
        else if (horizontalDirection > 0) playerCharacter.GetComponent<SpriteRenderer>().flipX = false;
    }

    void HandlePlayerAnimation()
    {
        if (input.x != 0 || input.y != 0) playerCharacter.GetComponent<Animator>().SetBool("IsWalking", true);
        else playerCharacter.GetComponent<Animator>().SetBool("IsWalking", false);
    }
}
