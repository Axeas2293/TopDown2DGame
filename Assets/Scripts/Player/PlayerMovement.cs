using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
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
        playerControls = new PlayerInputActions();
        moveAction = playerControls.Player.Move;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        ReadMovementInput();
        SetAnimator();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
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

    void ReadMovementInput()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
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
