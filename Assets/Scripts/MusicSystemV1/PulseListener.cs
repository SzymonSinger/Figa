using UnityEngine;

public class PulseSubscriber : MonoBehaviour
{
    private void OnEnable()
    {
        BackgroundPulse.OnPulse += HandlePulse;
    }

    private void OnDisable()
    {
        BackgroundPulse.OnPulse -= HandlePulse;
    }

    private void HandlePulse(BackgroundPulse pulser)
    {
        pulser.Pulse();
    }
}