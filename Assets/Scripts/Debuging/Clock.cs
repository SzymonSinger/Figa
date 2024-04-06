using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeDisplayer;
    private void Update()
    {
        timeDisplayer.text = Time.time.ToString();
    }
}
