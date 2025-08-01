using UnityEngine;
using static TagesphasenWechsler;

public class PlayerAbilities : MonoBehaviour
{
    public TeleportF‰higkeit teleportF‰higkeit;
    public WindstoﬂF‰higkeit windstoﬂF‰higkeit;
    public InvisibilityAbility invisibilityAbility;
    public TimeSlowDown timeSlowDown;

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
        teleportF‰higkeit.enabled = false;
        windstoﬂF‰higkeit.enabled = false;
        invisibilityAbility.enabled = false;
        timeSlowDown.enabled = false;

        // Passende F‰higkeit aktivieren
        switch (newPhase)
        {
            case DayPhase.Morning:
                teleportF‰higkeit.enabled = true;
                break;
            case DayPhase.Noon:
                windstoﬂF‰higkeit.enabled = true;
                break;
            case DayPhase.Evening:
                timeSlowDown.enabled = true;
                break;
            case DayPhase.Night:
                invisibilityAbility.enabled = true;
                break;
        }
    }

}
