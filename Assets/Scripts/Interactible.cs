using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Interactible : MonoBehaviour
{
    public string interactionPrompt; // The prompt to display when the player can interact with this object

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // This method will be overridden by subclasses to define specific interaction behavior
        Debug.Log("Interacting with " + gameObject.name);
    }


}
