using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportFähigkeit : MonoBehaviour
{
    public float cooldown = 1f;
    public float teleportDistance = 5f;
    private bool canUse = true;

    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = transform;
    }

    public void Activate()
    {
        Debug.Log("Teleport ready");
    }

    public void Deactivate()
    {
        //Falls Zeit übrig bleibt
    }
    // Update is called once per frame
    void Update()
    {
        if (!canUse) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (direction != Vector2.zero)
            {
                Vector2 targetPosition = (Vector2)playerTransform.position + direction * teleportDistance;

                // Optional: Raycast für Hindernisse hier einbauen
                playerTransform.position = targetPosition;
                Debug.Log("Teleportiert nach: " + targetPosition);

                canUse = false;
                Invoke(nameof(ResetCooldown), cooldown);
            }
        }
    }

    private void ResetCooldown()
    {
        canUse = true;
    }
}
        