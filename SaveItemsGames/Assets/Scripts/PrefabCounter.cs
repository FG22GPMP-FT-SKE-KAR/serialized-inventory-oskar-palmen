using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrefabCounter : MonoBehaviour
{
    public TextMeshProUGUI countText; // Reference to the TextMeshPro Text component
    private int prefabCount = 0;

    private void Start()
    {
        LoadCount(); // Load the count from PlayerPrefs when the game starts
        UpdateCountText();
    }


    public void IncrementCount()
    {
        prefabCount++;
        UpdateCountText();
        SaveCount(); // Save the updated count to PlayerPrefs
    }

    public void DecrementCount()
    {
        if (prefabCount > 0)
        {
            prefabCount--;
            UpdateCountText();
            SaveCount(); // Save the updated count to PlayerPrefs
        }
    }

    public void DecrementCountButton()
    {
        DecrementCount(); // Call your existing DecrementCount method
    }

    public void ResetCount()
    {
        prefabCount = 0;
        UpdateCountText();
        SaveCount(); // Save the updated count to PlayerPrefs
    }

    private void UpdateCountText()
    {
        countText.text = "Saved Potion Count: " + prefabCount.ToString();
    }

    // Function to save the count to PlayerPrefs
    private void SaveCount()
    {
        PlayerPrefs.SetInt("PrefabCount", prefabCount);
        PlayerPrefs.Save();
    }

    // Function to load the count from PlayerPrefs
    private void LoadCount()
    {
        if (PlayerPrefs.HasKey("PrefabCount"))
        {
            prefabCount = PlayerPrefs.GetInt("PrefabCount");
        }
    }
}