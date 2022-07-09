using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    [Range(0, 1)]
    private float deceleration = 0.97f;

    [SerializeField]
    [Range(0, 5)]
    private float acceleration = 3f;

    [SerializeField]
    [Range(0, 20)]
    private float maxSpeed = 10f;

    public Vector2 inputMoveValue;
    public float speed;

    public void OnMove(InputValue value)
    {
        inputMoveValue = value.Get<Vector2>();
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce(inputMoveValue * acceleration * 100f * Time.fixedDeltaTime);
        }
        if (inputMoveValue.sqrMagnitude < 0.001f)
        {
            rb.velocity *= deceleration;
        }
    }
}
