using System;
using UnityEngine;
using static TagesphasenWechsler;
using static PlayerAbilities;

public class PhasenManager : MonoBehaviour
{
    public static PhasenManager Instance;

    [Header("Cycle Settings")]
    public DayPhase currentPhase = DayPhase.Morning;
    public float phaseDuration = 10f; // Dauer jeder Phase in Sekunden

    private float timer;

    public static event Action<DayPhase> OnPhaseChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
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

    private void AdvancePhase()
    {
        currentPhase = (DayPhase)(((int)currentPhase + 1) % Enum.GetValues(typeof(DayPhase)).Length);
        TriggerPhaseChanged();
    }

    private void TriggerPhaseChanged()
    {
        Debug.Log("Current Phase: " + currentPhase);
        OnPhaseChanged?.Invoke(currentPhase);
    }

    // Optional: manueller Wechsel
    /*public void NextPhaseManually()
    {
        AdvancePhase();
        timer = 0f;
    }*/

    
}
