using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpImpulse = 2f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;

#region Properties
    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving)
            {
                if (IsRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return walkSpeed;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving 
    {
        get { return _isMoving; }
        private set 
        {
            _isMoving = value;
            //animator.SetBool("isMoving", value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning
    {
        get { return _isRunning; }
        private set
        {
            _isRunning = value;
            //animator.SetBool("isMoving", value);
        }
    }
    #endregion

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    #region Movement

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
    }

    public void OnRun(InputAction.CallbackContext context) 
    {
        if (context.started)
        {
            IsRunning = true;
        } else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context) 
    { 
        if(context.started && touchingDirections.IsGrounded) 
        {
            //animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    #endregion
}
