using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class PeakEvent : UnityEvent<float> { }

public class AudioPeakDetector : MonoBehaviour
{
    public AudioClip audioClip; // The AudioClip to analyze
    public float sensitivity = 0.2f; // Sensitivity for detecting peaks
    public float minTimeBetweenPeaks = 0.1f; // Minimum time interval between peaks
    public PeakEvent onPeakDetected; // Event to trigger when a peak is detected

    private void Start()
    {
        DetectPeaks();
    }

    public void DetectPeaks()
    {
        if (audioClip == null) return;

        float[] audioData = new float[audioClip.samples * audioClip.channels];
        audioClip.GetData(audioData, 0);

        float lastPeakTime = 0f;
        for (int i = 1; i < audioData.Length - 1; i++)
        {
            if (audioData[i] > audioData[i - 1] && audioData[i] > audioData[i + 1] && audioData[i] > sensitivity)
            {
                float time = (float)i / audioClip.frequency;
                if (time - lastPeakTime >= minTimeBetweenPeaks)
                {
                    onPeakDetected.Invoke(time);
                    lastPeakTime = time;
                }
            }
        }
    }
}