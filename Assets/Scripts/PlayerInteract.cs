using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    private LayerMask mask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactible>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactible>().interactionPrompt);
            }
        }
    }
}
