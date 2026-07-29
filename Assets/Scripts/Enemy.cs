using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EvolutionManager EvolutionManager;
    private bool Consumable;
    [SerializeField] TextMeshProUGUI ConsumeText; // press e to consume
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Consumable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Consumable) //and in hitbox
        {
            ConsumeText.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                EvolutionManager.Evolve();
            }
        }
        else
        {
            ConsumeText.gameObject.SetActive(false);
        }
    }

    public void Dead()
    {
        Consumable = true;
        //change to dead sprite
    }
}
