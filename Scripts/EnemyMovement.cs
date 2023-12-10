using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 8f;
    public float minJumpInterval = 2f;
    public float maxJumpInterval = 5f;

    private Animator animator;
    private Rigidbody myRigidbody; // Rename the variable
    private bool isGrounded;
    private float nextJumpTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        SetNextJumpTime();
    }

    void Update()
    {
        // Check if the enemy is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Move the character forward automatically
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Handle jumping at random intervals
        if (Time.time >= nextJumpTime && isGrounded)
        {
            Jump();
            SetNextJumpTime();
        }
    }

    void Jump()
    {
        // Set animator parameter for jumping
        animator.SetTrigger("Jump");

        // Apply jump force
        myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void SetNextJumpTime()
    {
        // Calculate the next random jump time within the specified interval
        nextJumpTime = Time.time + Random.Range(minJumpInterval, maxJumpInterval);
    }
}
