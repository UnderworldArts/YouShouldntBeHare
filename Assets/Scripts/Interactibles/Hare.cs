using UnityEngine;

public class Hare : Interactible
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        base.Interact();
        // Add specific interaction behavior for the Hare here
        Debug.Log("You interacted with the Hare!");

    }

}
