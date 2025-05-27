using UnityEngine;

public class PlayerJumpAttack : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;

    [Header("Jumping")]
    public Transform jumpTarget;
    public float jumpSpeed = 20f;
    public float returnSpeed = 25f;
    public float airAttackDelay = 0.1f;
    public float returnDelay = 0.1f;

    [Header("Air Combo Settings")]
    public float comboTimeout = 0.25f;

    private Vector3 originalPosition;
    private bool isJumping = false;
    private bool isReturning = false;
    private bool aerialSequence = false;

    private int airComboIndex = 0;
    private float comboTimer = 0f;
    private bool waitingForComboInput = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Ground attack input (random)
        if (Input.GetKeyDown(KeyCode.F) && !isJumping && !isReturning && !aerialSequence)
        {
            int randAttack = Random.Range(1, 4); // 1 to 3
            animator.SetTrigger("attack" + randAttack);
        }

        // Start aerial attack sequence
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isReturning && !aerialSequence)
        {
            isJumping = true;
            aerialSequence = true;
            animator.SetTrigger("jump");
        }

        // Jumping toward target
        if (isJumping)
        {
            transform.position = Vector3.MoveTowards(transform.position, jumpTarget.position, jumpSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, jumpTarget.position) < 0.01f)
            {
                isJumping = false;
                airComboIndex = 0;
                PlayNextComboAttack(); // Start with attack1
            }
        }

        // Aerial combo logic (waits for player input while airborne)
        if (waitingForComboInput)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayNextComboAttack();
            }
            else
            {
                comboTimer += Time.deltaTime;
                if (comboTimer >= comboTimeout)
                {
                    TriggerFallFromAir(); // No input → fall
                }
            }
        }

        // Returning to original position
        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, returnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
            {
                isReturning = false;
                animator.SetTrigger("fall");
                ResetCombo(); // End the sequence
            }
        }
    }

    void PlayNextComboAttack()
    {
        if (airComboIndex >= 3)
        {
            TriggerFallFromAir(); // End combo
            return;
        }

        airComboIndex++;
        animator.SetTrigger("attack" + airComboIndex);

        // Allow chaining or delay fall
        waitingForComboInput = true;
        comboTimer = 0f;
    }

    void TriggerFallFromAir()
    {
        waitingForComboInput = false;
        animator.SetTrigger("fall");
        Invoke(nameof(StartReturn), returnDelay);
    }

    void StartReturn()
    {
        isReturning = true;
    }

    void ResetCombo()
    {
        airComboIndex = 0;
        isJumping = false;
        isReturning = false;
        aerialSequence = false;
        waitingForComboInput = false;
    }
}