using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDestroy : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Check if the click was from the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Destroy the GameObject when clicked
            Destroy(gameObject);

            // Decrement the count in the PrefabCounter script
            PrefabCounter prefabCounter = FindObjectOfType<PrefabCounter>();
            if (prefabCounter != null)
            {
                prefabCounter.DecrementCount();
            }
        }
    }
}