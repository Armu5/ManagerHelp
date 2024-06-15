using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Ensure no gravity affects the character
    }

    void Update()
    {
        // Capture input
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = moveInput * moveSpeed;
    }
}
