using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    public LayerMask interactibleMask;

    public Image crosshair;
    public Sprite defaultSprite;
    public Sprite hoverSprite;

    private PlayerUI playerUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        crosshair.sprite = defaultSprite;
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
                Debug.Log("Can consume: " + hitInfo.collider.name);

                if (hitInfo.collider.GetComponent<Interactible>() != null)
                {
                    crosshair.sprite = hoverSprite;
                    crosshair.color = Color.yellow;
                    Interactible interactible = hitInfo.collider.GetComponent<Interactible>();
                    playerUI.UpdateText(interactible.interactionPrompt);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactible.BaseInteract();
                    }
                }

            }
            else
            {
                crosshair.sprite = defaultSprite;
                crosshair.color = Color.white;
            }
        
    }
}
