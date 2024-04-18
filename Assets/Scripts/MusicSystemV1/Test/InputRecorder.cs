// InputRecorder.cs

using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public InputTimingData timingData;
    private float startTime;

    void Start()
    {
        if (timingData != null)
        {
            timingData.inputTimes.Clear();
        }
        startTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            float inputTime = Time.time - startTime;
            Debug.Log($"Input recorded at time: {inputTime}");
            if (timingData != null)
            {
                timingData.inputTimes.Add(inputTime);
            }
        }
    }

    // Call this method to save the recorded data when the test run ends
    public void SaveInputTimes()
    {
        // You might want to implement saving logic here, like writing to a file or saving the ScriptableObject
        Debug.Log("Input times saved!");
    }
}