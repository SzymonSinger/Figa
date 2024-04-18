using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputTimingData", menuName = "RhythmGame/InputTimingData", order = 1)]
public class InputTimingData : ScriptableObject
{
    public List<float> inputTimes = new List<float>();
}