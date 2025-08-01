using UnityEngine;

/// <summary>
/// Verlangsamt die Zeit während der Nachtphase.
/// </summary>
public class TimeSlowDown : MonoBehaviour
{
    [Header("Zeitverlangsamung")]
    [Tooltip("Faktor, um den die Zeit verlangsamt wird (z. B. 0.5 = halb so schnell)")]
    public float slowFactor = 0.5f;

    private void OnEnable()
    {
        PhasenManager.OnPhaseChanged += HandlePhaseChange;
    }

    private void OnDisable()
    {
        PhasenManager.OnPhaseChanged -= HandlePhaseChange;
    }

    /// <summary>
    /// Wird aufgerufen, wenn sich die Tagesphase ändert.
    /// </summary>
    /// <param name="phase">Die neue Phase.</param>
    private void HandlePhaseChange(DayPhase phase)
    {
        if (phase == DayPhase.Noon)
        {
            ActivateTimeSlow();
        }
        else
        {
            ResetTimeScale();
        }
    }

    private void ActivateTimeSlow()
    {
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Debug.Log("Zeitslow aktiviert (Abend)");
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        Debug.Log("Zeitslow deaktiviert (Nicht mehr Nacht)");
    }
}
