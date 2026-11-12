using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed;
    public SpriteRenderer spriteRenderer;
    private float speedX = 0f;
        private float speedY = 0f;
        public Rigidbody2D rb;
        // Start is called once before the first execution of Update after the
       // MonoBehaviour is created
void Start()
        {
        animator = GetComponent<Animator>();
    }
        // Update is called once per frame
        void Update()
        {
        animator.SetBool("walk", speedX != 0 || speedY != 0);
        Movement();
        }
        void Movement()
        {
        if (speedX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (speedX < 0)
        {
            spriteRenderer.flipX = true;
        }
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
            {
                speedX = -moveSpeed;
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                speedX = moveSpeed;
            }
            else
            {
                speedX = 0;
            }
        // Vertical Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.flipX = true;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.flipX = false;
        }
        else
        {
            speedX = 0;
        }
        if (Keyboard.current.wKey.isPressed)
            {
                speedY = moveSpeed;
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                speedY = -moveSpeed;
            }
            else
            {
                speedY = 0;
            }
            rb.linearVelocity = new Vector2(speedX, speedY);
        }
    }
