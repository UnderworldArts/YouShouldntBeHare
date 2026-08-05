using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerXP : MonoBehaviour
{
    private float xp;
    private float xpRequired = 1f; // Amount of XP required to level up
    private float level;
    private float lerpTimer;
    public Image frontXPbar;
    public Image backXPbar;
    public TextMeshProUGUI levelText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xp = 0f;
        xpRequired = 1f;
        lerpTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        xp = Mathf.Clamp(xp, 0f, xpRequired); 

        UpdateXPUI();

        if (Input.GetKeyDown(KeyCode.X))
        {
            GainXP(1);
        }

        if (xp >= xpRequired)
        {
            LevelUp();
        }

        levelText.text = "Evolution <br> Stage: " + level.ToString();
    }
    
    public void UpdateXPUI()
    {
        float fillFront = frontXPbar.fillAmount;
        float fillBack = backXPbar.fillAmount;
        float xpFraction = xp / xpRequired; 
        if (fillBack > xpFraction)
        {
            frontXPbar.fillAmount = xpFraction;
            backXPbar.color = Color.yellow;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 1f; // Adjust the speed of the lerp as needed
            percentComplete = percentComplete * percentComplete;
            backXPbar.fillAmount = Mathf.Lerp(fillBack, xpFraction, percentComplete);
        }
        if (fillFront < xpFraction)
        {
            backXPbar.fillAmount = xpFraction;
            backXPbar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 1f; // Adjust the speed of the lerp as needed
            percentComplete = percentComplete * percentComplete;
            frontXPbar.fillAmount = Mathf.Lerp(fillFront, xpFraction, percentComplete);
        }
    }


    public void GainXP(float XPAmount)
    {
        xp += XPAmount;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        xp = 0f; // Reset XP after leveling up
        lerpTimer = 0f;
        // You can add additional logic here for what happens when the player levels up
        Debug.Log("Level Up! New Level: " + level);
        xpRequired += 1f; // Increase the XP required for the next level (you can adjust this formula as needed)
    }
}
