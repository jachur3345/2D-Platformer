using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMotor : MonoBehaviour
{//////Vector2 direction;

    public float dashForce = 10;

    public float dashtime = 0.2f;

    public float acceleration = 10;

    private Rigidbody2D rigidbody2D;

    private Animator animator;

    private bool canJump = true;

    public float maxSpeed = 10;

    public float stoppingForce = 10;

    public float speed = 10;

    public float jumpForce = 10;

    private bool isDashing = false;


    private int jumpCount = 0;

    public int maxJumpCount = 2;


    private float initXScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is createdprivate void Start(){        rigidbody2D = GetComponent<Rigidbody2D>();

    animator = GetComponent<Animator>();

        initXScale = transform.localScale.x;

    }// Update is called once per frameprivate void FixedUpdate(){        

rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));


if (isDashing)
{
    return;

}//Limit max speedif (rigidbody2D.linearVelocityX >= maxSpeed){            rigidbody2D.linearVelocityX = maxSpeed;

        }else if (rigidbody2D.linearVelocityX <= -maxSpeed)
{
    rigidbody2D.linearVelocityX = -maxSpeed;

}
if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
{
    rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));

}
if (direction.x != 0)
{
    animator.SetBool("IsMoving", true);

}
else
{
    animator.SetBool("IsMoving", false);

}
if (direction.x > 0)
{
    transform.localScale = new Vector3(initXScale, transform.localScale.y, transform.localScale.z);

}
else if (direction.x < 0)
{
    transform.localScale = new Vector3(-initXScale, transform.localScale.y, transform.localScale.z);

}}private void OnMove(InputValue value)
{
    direction = value.Get<Vector2>();

}
private void OnJump()
{
    if (canJump)
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        jumpCount++;

        if (jumpCount >= maxJumpCount) canJump = false;

    }
}
private void OnCollisionEnter2D(Collision2D collision)
{
    canJump = true;

    jumpCount = 0;

}
private void OnDash()
{

    isDashing = true;

    //Debug.Log("Dashing");        rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);

    StartCoroutine(ResetDash(dashtime));




}
IEnumerator ResetDash(float timeToRest)
{
    yield return new WaitForSeconds(timeToRest);

    isDashing = false;

}}