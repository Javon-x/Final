using System.Collections;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public float shieldDuration = 10f;
    public GameObject player; // Assign the player GameObject in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateShield();
            Destroy(gameObject); // Destroy the power-up object when collected
        }
    }

    private void ActivateShield()
    {
        player.GetComponent<PlayerMovement>()?.ActivateShield();
        StartCoroutine(ShieldTimer());
    }

    private IEnumerator ShieldTimer()
    {

        yield return new WaitForSeconds(shieldDuration);

        // Deactivate shield logic here
    }
}
