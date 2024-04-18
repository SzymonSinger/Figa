using System;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Intervals[] _intervals;
    private float[] _intervalFactors;

    public float BPM
    {
        get => _bpm;
        set
        {
            _bpm = value;
            UpdateIntervalFactors(); // Update factors when BPM changes
        }
    }

    private void Start()
    {
        UpdateIntervalFactors();
    }

    private void Update()
    {
        for (int i = 0; i < _intervals.Length; i++)
        {
            if (!_intervals[i].IsActive) continue; // Skip muted intervals

            float sampledTime = _audioSource.timeSamples / _intervalFactors[i];
            _intervals[i].CheckForNewInterval(sampledTime, i); // Pass interval index
        }
    }

    private void UpdateIntervalFactors()
    {
        _intervalFactors = new float[_intervals.Length];
        for (int i = 0; i < _intervals.Length; i++)
        {
            _intervalFactors[i] = _audioSource.clip.frequency * _intervals[i].GetIntervalLength(_bpm);
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent<int, int> _trigger; // Updated to include arguments
    [SerializeField] private bool _isActive = true; // Control active state of interval
    private int _lastInterval;

    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }

    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * _steps);
    }

    public void CheckForNewInterval(float interval, int index)
    {
        if (!_isActive) return; // Check if the interval is active

        int currentInterval = Mathf.FloorToInt(interval);
        if (currentInterval != _lastInterval)
        {
            _lastInterval = currentInterval;
            _trigger?.Invoke(index, currentInterval); // Pass interval index and current interval count
        }
    }
}
