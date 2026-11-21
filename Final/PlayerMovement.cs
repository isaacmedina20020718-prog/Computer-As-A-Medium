using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed;
    public SpriteRenderer spriteRenderer;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    public float sprintSpeed = 10f;
    public float sprintDuration = 2f;
    public float sprintCooldown = 3f;

    private float sprintTimer;
    private float cooldownTimer;

    public Slider sprintBar;
    // Start is called once before the first execution of Update after the
    // MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (sprintTimer > 0)
        {
            sprintTimer -= Time.deltaTime;
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Keyboard.current.leftShiftKey.wasPressedThisFrame &&
            cooldownTimer <= 0)
        {
            sprintTimer = sprintDuration;
            cooldownTimer = sprintCooldown;
        }
        if (sprintBar != null)
        {
            sprintBar.value =
                    1f - Mathf.Clamp01(cooldownTimer / sprintCooldown);
            if (sprintTimer > 0)
            {
                sprintBar.value = 0;
            }
            else
            {
                
            }
        }

        Movement();

        animator.SetBool("walk", speedX != 0);
        animator.SetBool("movingUp", speedY > 0);
        animator.SetBool("movingDown", speedY < 0);
    }
    void Movement()
    {
        float currentSpeed = moveSpeed;

        if (sprintTimer > 0)
        {
            currentSpeed = sprintSpeed;
        }
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
            speedX = -currentSpeed;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = currentSpeed;
        }
        else
        {
            speedX = 0;
        }
        // Vertical Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -currentSpeed;
            spriteRenderer.flipX = true;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = currentSpeed;
            spriteRenderer.flipX = false;
        }
        else
        {
            speedX = 0;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = currentSpeed;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -currentSpeed;
        }
        else
        {
            speedY = 0;
        }
        rb.linearVelocity = new Vector2(speedX, speedY);

    }
}
