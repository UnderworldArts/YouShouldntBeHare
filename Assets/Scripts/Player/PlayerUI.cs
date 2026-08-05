using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI interactionPrompt; // Reference to the TextMeshProUGUI component for displaying interaction prompts

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        interactionPrompt.text = promptMessage;
    }
}
