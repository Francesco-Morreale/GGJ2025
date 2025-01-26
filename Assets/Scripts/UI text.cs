using UnityEngine;
using TMPro; // Include this for TextMeshPro components

public class DisplayText : MonoBehaviour
{
    public Transform Player; // Reference to the player's transform
    public TextMeshProUGUI uiText; // Reference to the UI TextMeshPro component

    void Start()
    {
        UpdateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        float height = Player.position.y; // Get current height of player
        uiText.text = $"Height: {height:F2}"; // Display height with 2 decimal places
    }
}
