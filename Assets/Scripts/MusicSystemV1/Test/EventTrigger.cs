using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventTrigger : MonoBehaviour
{
    public InputTimingData timingData;
    public float offset; // New offset variable

    [System.Serializable]
    public class TimedEvent
    {
        public float triggerTime;
        public UnityEvent events;
    }

    public List<TimedEvent> timedEvents = new List<TimedEvent>();

    // Example actions to be triggered
    public UnityEvent[] exampleActions;

    private float startTime;
    private int nextEventIndex = 0;

    void Start()
    {
        startTime = Time.time;
        if (timingData != null && timingData.inputTimes.Count > 0)
        {
            SetupTimedEvents();
        }
    }

    void Update()
    {
        if (nextEventIndex < timedEvents.Count)
        {
            TimedEvent timedEvent = timedEvents[nextEventIndex];
            // Subtract offset from the trigger time
            if (Time.time - startTime >= timedEvent.triggerTime - offset)
            {
                Debug.Log($"Triggering event at time: {timedEvent.triggerTime} with offset: {offset}");
                timedEvent.events.Invoke();
                nextEventIndex++;
            }
        }
    }

    void SetupTimedEvents()
    {
        foreach (float inputTime in timingData.inputTimes)
        {
            TimedEvent newEvent = new TimedEvent { triggerTime = inputTime, events = new UnityEvent() };

            // Attach an example action if available
            if (exampleActions != null && exampleActions.Length > nextEventIndex)
            {
                newEvent.events.AddListener(exampleActions[nextEventIndex].Invoke);
            }

            timedEvents.Add(newEvent);
        }
    }
}