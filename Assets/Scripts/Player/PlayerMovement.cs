using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    }

    private void FixedUpdate()
    {
        body.velocity = input * runSpeed;
    }
}
