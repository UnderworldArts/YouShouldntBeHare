using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    public LayerMask interactibleMask;

    private PlayerUI playerUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, interactibleMask))
        {
            if (hitInfo.collider.GetComponent<Interactible>() != null)
            {
                Interactible interactible = hitInfo.collider.GetComponent<Interactible>();
                playerUI.UpdateText(interactible.interactionPrompt);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactible.BaseInteract();
                }
            }
        }


    }
}
