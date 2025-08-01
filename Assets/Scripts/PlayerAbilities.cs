using UnityEngine;
using static TagesphasenWechsler;

public class PlayerAbilities : MonoBehaviour
{
    public TeleportF‰higkeit Morgen;
    public WindstoﬂF‰higkeit Mittag;
    public InvisibilityAbility Abend;
    public TimeSlowDown Nacht;

    private void OnEnable()
    {
        PhasenManager.OnPhaseChanged += HandlePhaseChange;
    }

    private void OnDisable()
    {
        PhasenManager.OnPhaseChanged -= HandlePhaseChange;
    }

    private void HandlePhaseChange(DayPhase newPhase)
    {
        // Alle F‰higkeiten deaktivieren
        Morgen.enabled = false;
        Mittag.enabled = false;
        Abend.enabled = false;
        Nacht.enabled = false;

        // Passende F‰higkeit aktivieren
        switch (newPhase)
        {
            case DayPhase.Morning:
                Morgen.enabled = true;
                break;
            case DayPhase.Noon:
                Mittag.enabled = true;
                break;
            case DayPhase.Evening:
                Abend.enabled = true;
                break;
            case DayPhase.Night:
                Nacht.enabled = true;
                break;
        }
    }

}
