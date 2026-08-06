using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EvolutionManager EvolutionManager;
    [SerializeField] bool Consumable; // turns on when enemy dies. turned on in the inspector if the hare starts out dead
    [SerializeField] TextMeshProUGUI ConsumeText; // press e to consume
  
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
