using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2;
    public Image frontHealthbar;
    public Image backHealthbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Change this to start at low health, to demonstrate heal mechanic
        health = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        //Health cannot exceed these values
        health = Mathf.Clamp(health, 0, maxHealth);

        //Update Healthbar
        UpdateHealthUI();

        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(Random.Range(5, 10));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            RestoreHealth(Random.Range(5, 10));
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillFront = frontHealthbar.fillAmount;
        float fillBack = backHealthbar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillBack > hFraction)
        {
            frontHealthbar.fillAmount = hFraction;
            backHealthbar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthbar.fillAmount = Mathf.Lerp(fillBack, hFraction, percentComplete);
        }

        if (fillFront < hFraction)
        {
            backHealthbar.fillAmount = hFraction;
            backHealthbar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthbar.fillAmount = Mathf.Lerp(fillFront, hFraction, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0;
    }


}
