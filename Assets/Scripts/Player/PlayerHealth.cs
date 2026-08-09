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
    [SerializeField] private Rigidbody rb;

    [SerializeField] private EnemyAI enemyAI; // Reference to the EnemyAI script for managing enemy behavior

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Change this to start at low health, to demonstrate heal mechanic
        health = maxHealth; 
        rb = GetComponent<Rigidbody>();
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Health cannot exceed these values
        health = Mathf.Clamp(health, 0, maxHealth);

        //Update Healthbar
        UpdateHealthUI();

        if (enemyAI.playerInAttackRange == true)
        {
            TakeDamage(10f);
        }

    }

    public void UpdateHealthUI()
    {
        
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
        Debug.Log(health);
        health -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        Debug.Log(health);
        health += healAmount;
        lerpTimer = 0;
    }


}
