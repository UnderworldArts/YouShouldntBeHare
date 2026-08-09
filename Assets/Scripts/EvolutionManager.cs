using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EvolutionManager : MonoBehaviour
{

 
    [SerializeField] Animator animator;
    public int EvolutionCount;
    [SerializeField] Camera POVCamera;
    [SerializeField] PlayerMovement Player;
    [SerializeField] PlayerHealth hp;

    public float currentFOV;

    public void Start()
    {
        currentFOV = POVCamera.fieldOfView;
    }



    public void Evolve()
    {
        Debug.Log("Evolving...");
        EvolutionCount++;

        StartCoroutine(ChangeFOV(currentFOV, currentFOV + 20f, 1f));

        hp.RestoreHealth(20); // Restore 20 health points upon evolution

        //Change player stats
        Player.walkSpeed++;
        Player.sprintSpeed++;
        Player.crouchSpeed++;
        Player.jumpForce++;
        //change hand sprite

    }

    //A coroutine to smoothly change the camera's field of view over a specified duration
    IEnumerator ChangeFOV(float startFOV, float targetFOV, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            POVCamera.fieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }
        POVCamera.fieldOfView = targetFOV;
    }


}
