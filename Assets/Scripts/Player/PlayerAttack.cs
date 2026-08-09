using UnityEngine;
using UnityEngine.UI;   
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 4f;

    public LayerMask enemyMask;
    private PlayerUI playerUI;

    public Image crosshair;
    public Sprite defaultSprite;
    public Sprite hoverSprite;

    public bool needsTutorial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        crosshair.sprite = defaultSprite;
        needsTutorial = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, enemyMask))
        {
            Debug.Log("Hit: " + hitInfo.collider.name);

            if (needsTutorial)
            {
                playerUI.UpdateText("Press Left Mouse Button to Defend yourself!");
            }

            if (hitInfo.collider.GetComponent<EnemyAI>() != null)
            {

                

                EnemyAI enemyAI = hitInfo.collider.GetComponent<EnemyAI>();

                crosshair.sprite = hoverSprite;
                crosshair.color = Color.red;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    enemyAI.TakeDamage(1);
                }
            }
            

        }
  
    }
}
