using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D _rb;
    public Animator _animator;
    public PlayerInputActions playerControls;
    public SpriteRenderer _spriteRenderer;

    [Header("InputActions")]
    private InputAction moveAction;


    [Header("Movement Variables")]
    private Vector2 moveDirection;
    private float moveSpeed = 5f;
    public float moveX;
    public float moveY;
    public float movementSpeed;
    private Vector2 lastMoveDirection;




    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        SetAnimator();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void SetMoveInput(Vector2 input)
    {
        moveDirection = input;
    }



    void SetAnimator()
    {
        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection;
        }
        _animator.SetFloat("moveX", lastMoveDirection.x);
        _animator.SetFloat("moveY", lastMoveDirection.y);
        _animator.SetFloat("movementSpeed", moveDirection.sqrMagnitude);
    }


    void MovePlayer()
    {
        _rb.velocity = moveDirection * moveSpeed;
        FlipPlayer();
    }

    void FlipPlayer()
    {
        if (moveDirection.x > 0)
            _spriteRenderer.flipX = false;
        else if (moveDirection.x < 0)
            _spriteRenderer.flipX = true;
    }
}
