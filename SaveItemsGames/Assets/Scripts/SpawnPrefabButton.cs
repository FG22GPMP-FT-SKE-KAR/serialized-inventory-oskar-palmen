using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class SpawnPrefabButton : MonoBehaviour
{
    public GameObject prefabToSpawn; // Reference to the prefab you want to spawn
    public PrefabCounter prefabCounter; // Reference to the PrefabCounter script

    private DateTime lastClickTime;
    private float clickCooldown = 20f; // Cooldown period in seconds

    private List<GameObject> spawnedPrefabs = new List<GameObject>(); // List to store spawned prefabs

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);

        // Load the lastClickTime from PlayerPrefs and convert it to DateTime
        string lastClickTimeString = PlayerPrefs.GetString("LastClickTime", "");
        if (!string.IsNullOrEmpty(lastClickTimeString))
        {
            lastClickTime = DateTime.Parse(lastClickTimeString);
        }

    }

    private void OnClickButton()
    {
        // Calculate the time elapsed since the last click
        TimeSpan timeSinceLastClick = DateTime.Now - lastClickTime;

        // Check if enough time has passed since the last click
        if (timeSinceLastClick.TotalSeconds >= clickCooldown)
        {
            // Spawn the prefab
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
            spawnedPrefabs.Add(spawnedPrefab); // Add the spawned prefab to the list

            // Update the last click time to the current time
            lastClickTime = DateTime.Now;

            // Save the lastClickTime to PlayerPrefs as a string
            PlayerPrefs.SetString("LastClickTime", lastClickTime.ToString());
            PlayerPrefs.Save(); // Make sure to save the PlayerPrefs data

            // Increment the count in the PrefabCounter script
            prefabCounter.IncrementCount();
        }
    }

    // Function to destroy one of the spawned prefabs
    public void DestroySpawnedPrefab()
    {
        if (spawnedPrefabs.Count > 0)
        {
            GameObject prefabToDestroy = spawnedPrefabs[0]; // You can change this logic to destroy a specific prefab
            spawnedPrefabs.Remove(prefabToDestroy);
            Destroy(prefabToDestroy);

            // Decrement the count in the PrefabCounter script
            prefabCounter.DecrementCount();
        }
    }

}