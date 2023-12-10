using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public ShieldBubble shieldBubble; // Reference to the ShieldBubble script

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    bool isShieldActive = false;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking && !m_AudioSource.isPlaying)
        {
            m_AudioSource.Play();
        }
        else if (!isWalking)
        {
            m_AudioSource.Stop();
        }

        // Shield activation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleShield();
        }

        // Movement and rotation
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    // Method to toggle shield activation/deactivation
    void ToggleShield()
    {
        if (isShieldActive)
        {
            DeactivateShield();
        }
        else
        {
            ActivateShield();
        }
    }

    // Method to activate the shield
    public void ActivateShield()
    {
        Debug.Log("Shield Activated");
        // Implement shield activation logic here

        // Activate the shield bubble
        if (shieldBubble != null)
        {
            shieldBubble.ActivateBubble();
        }

        isShieldActive = true;
    }

    // Method to deactivate the shield
    void DeactivateShield()
    {
        Debug.Log("Shield Deactivated");
        // Implement shield deactivation logic here

        // Deactivate the shield bubble
        if (shieldBubble != null)
        {
            shieldBubble.DeactivateBubble();
        }

        isShieldActive = false;
    }
}
