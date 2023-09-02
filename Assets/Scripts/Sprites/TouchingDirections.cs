using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    public ContactFilter2D contactFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    #region Properties
    [SerializeField]
    private bool _isGrounded = true;
    public bool IsGrounded { get { return _isGrounded; } private set { _isGrounded = value; } }

    [SerializeField]
    private bool _isOnWall = true;
    public bool IsOnWall { get { return _isOnWall; } private set { _isOnWall = value; } }

    [SerializeField]
    private bool _isOnCeiling = true;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    public bool IsOnCeiling { get { return _isOnCeiling; } private set { _isOnCeiling = value; } }
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = rb.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = capsuleCollider.Cast(Vector2.down, contactFilter, groundHits, groundDistance) > 0;
        IsOnWall = capsuleCollider.Cast(wallCheckDirection, contactFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = capsuleCollider.Cast(Vector2.up, contactFilter, ceilingHits, ceilingDistance) > 0;
    }
}
