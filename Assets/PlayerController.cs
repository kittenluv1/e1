using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float movementX;
    private float movementZ;
    private Rigidbody rb;

    [SerializeField] private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementZ) * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z); // maintain gravity
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        movementX = input.x;
        movementZ = input.y;
    }

    void OnJump() {
        Debug.Log("jump");
        rb.AddForce(Vector3.up * speed, ForceMode.Impulse); // Add an upward force for jumping
    }

}