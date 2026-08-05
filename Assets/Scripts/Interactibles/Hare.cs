using System;
using UnityEngine;

public class Hare : Interactible
{
    [SerializeField] private GameObject player;
    private PlayerXP xpSystem; // Reference to the PlayerXP system for managing experience points

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpSystem = player.GetComponent<PlayerXP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        base.Interact();
        
        xpSystem.GainXP(1); // Award 1 XP to the player when interacting with the hare
        gameObject.SetActive(false);

    }

}
