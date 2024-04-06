using UnityEngine;
using System.Collections.Generic;

public class AudioPeakDetector : MonoBehaviour
{
    public AudioClip audioClip; // The AudioClip to analyze
    public float sensitivity = 0.2f; // Sensitivity for detecting peaks
    public float minTimeBetweenPeaks = 0.1f; // Minimum time interval between peaks to avoid detecting the same peak multiple times

    public List<float> DetectPeaks()
    {
        List<float> peakTimes = new List<float>();
        float[] audioData = new float[audioClip.samples * audioClip.channels];
        audioClip.GetData(audioData, 0);

        float lastPeakTime = 0f;
        for (int i = 1; i < audioData.Length - 1; i++)
        {
            // Check if the current sample is a peak
            if (audioData[i] > audioData[i - 1] && audioData[i] > audioData[i + 1] && audioData[i] > sensitivity)
            {
                float time = (float)i / audioClip.frequency;

                // Ensure this peak is sufficiently far from the last detected peak
                if (time - lastPeakTime >= minTimeBetweenPeaks)
                {
                    peakTimes.Add(time);
                    lastPeakTime = time;
                }
            }
        }

        return peakTimes;
    }

    // Example usage
    void Start()
    {
        List<float> peaks = DetectPeaks();
        foreach (float peak in peaks)
        {
            Debug.Log("Peak at: " + peak + " seconds");
        }
    }
}