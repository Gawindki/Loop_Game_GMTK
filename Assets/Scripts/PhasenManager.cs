using System;
using UnityEngine;

/// <summary>
/// Die 4 Tagesphasen deines Spiels.
/// </summary>
public enum DayPhase
{
    Morning,
    Noon,
    Evening,
    Night
}

/// <summary>
/// Verwaltet den Wechsel der Tagesphasen.
/// Sendet ein Event bei jeder Änderung.
/// </summary>
public class PhasenManager : MonoBehaviour
{
    public static PhasenManager Instance;

    [Header("Cycle Settings")]
    public DayPhase currentPhase = DayPhase.Morning;
    public float phaseDuration = 10f; // Dauer jeder Phase in Sekunden

    private float timer;

    // Event für den Phasenwechsel
    public static event Action<DayPhase> OnPhaseChanged;

    private void Awake()
    {
        // Singleton-Setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Starte mit der ersten Phase
        TriggerPhaseChanged();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= phaseDuration)
        {
            AdvancePhase();
            timer = 0f;
        }
    }

    /// <summary>
    /// Wechsel zur nächsten Phase im Zyklus.
    /// </summary>
    private void AdvancePhase()
    {
        currentPhase = (DayPhase)(((int)currentPhase + 1) % Enum.GetValues(typeof(DayPhase)).Length);
        TriggerPhaseChanged();
    }

    /// <summary>
    /// Löst das Phasenwechsel-Event aus.
    /// </summary>
    private void TriggerPhaseChanged()
    {
        Debug.Log("Phase gewechselt zu: " + currentPhase);
        OnPhaseChanged?.Invoke(currentPhase);
    }

    /// <summary>
    /// Manueller Wechsel (z. B. über Taste oder Knopf).
    /// </summary>
    public void NextPhaseManually()
    {
        AdvancePhase();
        timer = 0f;
    }
}
