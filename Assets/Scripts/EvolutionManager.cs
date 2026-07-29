using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EvolutionManager : MonoBehaviour
{

 
    [SerializeField] Animator animator;
    public int EvolutionCount;
    [SerializeField] Camera POVCamera;
    [SerializeField] PlayerMovement Player;

    
    public void Evolve()
    {
        Debug.Log("Evolving...");
        EvolutionCount++;
        POVCamera.fieldOfView += 20f;
        Player.walkSpeed++;
        Player.sprintSpeed++;
        Player.crouchSpeed++;
        Player.jumpForce++;
        //change hand sprite

    }

}
