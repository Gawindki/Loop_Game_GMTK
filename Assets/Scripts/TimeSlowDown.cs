using UnityEngine;

public class TimeSlowDown : MonoBehaviour
{
    public float slowAmount = 0.3f;
    public float duration = 5f;
    public float cooldown = 5f;
    private bool canUse = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Activate()
    {
        Debug.Log("Verlangsamung~");
    }

    public void Deactivate()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canUse) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = slowAmount;
            Debug.Log("Zeit ist slow");
            canUse = false;

            Invoke(nameof(ResetTime), duration);
            Invoke(nameof(ResetCooldown), cooldown);
        }
    }

    private void ResetTime()
    {
        Time.timeScale = 1f;
    }

    private void ResetCooldown()
    {
        canUse = false;
    }
}
