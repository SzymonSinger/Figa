using System;
using System.Collections;
using UnityEngine;

public class BackgroundPulse : MonoBehaviour
{
    [SerializeField] private bool _useTestBeat;
    [SerializeField] private float _pulseSize = 1.15f;
    [SerializeField] private float _returnSpeed = 5f;
    private Vector3 _startSize;

    // Define an event with PulseToTheBeat parameter
    public static event Action<BackgroundPulse> OnPulse;

    private void Start()
    {
        _startSize = transform.localScale;
        if (_useTestBeat)
        {
            StartCoroutine(TestBeat());
        }
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, Time.deltaTime * _returnSpeed);
    }

    public void Pulse()
    {
        transform.localScale = _startSize * _pulseSize;

        // Invoke the event, passing 'this' as the PulseToTheBeat reference
        OnPulse?.Invoke(this);
    }

    IEnumerator TestBeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Pulse();
        }
    }
}