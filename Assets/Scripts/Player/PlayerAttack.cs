using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 4f;

    public LayerMask enemyMask;
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
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, enemyMask))
        {
            if (hitInfo.collider.GetComponent<EnemyAI>() != null)
            {
                EnemyAI enemyAI = hitInfo.collider.GetComponent<EnemyAI>();

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    enemyAI.TakeDamage(1);
                }
            }
        }
    }
}
