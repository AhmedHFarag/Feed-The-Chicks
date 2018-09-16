using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class StanderedController : MonoBehaviour
{
    Rigidbody2D Player;
    SpriteRenderer spRenderer;
    //TrailRenderer trailRenderer;
    bool grounded = false;
    public bool constantMovement = false;
    public float originalMoveSpeed = 10;
    public float originalJumpForce = 200;

    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentJumpForce;

    public LayerMask GroundLayers;
    public Transform GroundChecker;
    public float overLappedCircleRadius = 0.3f;

    public void Awake()
    {
        Player = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        //trailRenderer = GetComponent<TrailRenderer>();
        currentMoveSpeed = originalMoveSpeed;
        currentJumpForce = originalJumpForce;
    }
    public void Move(float Axis)
    {
        if (Mathf.Abs(Axis) < 0.2f && constantMovement) return;
        Player.velocity = new Vector2(Axis * currentMoveSpeed, Player.velocity.y);
        if (Axis < -0.2 && !spRenderer.flipX) spRenderer.flipX = true;
        if (Axis > 0.2 && spRenderer.flipX) spRenderer.flipX = false;
        grounded = IsGrounded();
    }

    public void Jump()
    {
        //   Player.AddForce(new Vector2(0, 2000) * Time.deltaTime, ForceMode2D.Force);
        Player.AddForce(new Vector2(0, currentJumpForce), ForceMode2D.Force);
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundChecker.position, overLappedCircleRadius, GroundLayers);
    }
}
