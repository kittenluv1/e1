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
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z); // maintain gravity
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        movementX = input.x;
        movementZ = input.y;

        Debug.Log("Input: " + input);
    }
}