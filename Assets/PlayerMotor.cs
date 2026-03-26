using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float jumpForce = 5;
    public float speed = 5;
    private Rigidbody2D rb;
    private bool _canJump = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (_canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _canJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _canJump = true;
    }
}
