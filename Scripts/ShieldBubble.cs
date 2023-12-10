using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBubble : MonoBehaviour
{
    // Add any additional variables or methods for bubble behavior

    public void ActivateBubble()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateBubble()
    {
        gameObject.SetActive(false);
    }
}
