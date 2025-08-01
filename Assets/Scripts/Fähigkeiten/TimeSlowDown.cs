using UnityEngine;
using System.Collections;
using static TagesphasenWechsler;

public class TimeSlowDown : MonoBehaviour
{
    [SerializeField] private float slowFactor = 0.3f;
    [SerializeField] private float slowDuration = 0.5f;
    [SerializeField] private float cooldown = 2f;

    private bool isOnCooldown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOnCooldown)
        {
            StartCoroutine(ActivateTimeSlow());
        }
    }

    IEnumerator ActivateTimeSlow()
    {
        isOnCooldown = true;

        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        yield return new WaitForSecondsRealtime(slowDuration);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        yield return new WaitForSecondsRealtime(cooldown);
        isOnCooldown = false;
    }

    private void OnEnable()
    {
        PhasenManager.OnPhaseChanged += HandlePhaseChange;
    }

    private void OnDisable()
    {
        PhasenManager.OnPhaseChanged -= HandlePhaseChange;
    }

    private void HandlePhaseChange(DayPhase phase)
    {
        if (phase == DayPhase.Night)
        {
            Time.timeScale = slowFactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
