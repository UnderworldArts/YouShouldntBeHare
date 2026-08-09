using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI interactionPrompt; // Reference to the TextMeshProUGUI component for displaying interaction prompts

    void Start()
    {

    }

    void Update()
    {
        
    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        interactionPrompt.text = promptMessage;
    }
}
