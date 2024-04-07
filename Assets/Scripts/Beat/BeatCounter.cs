using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class BeatCounter : MonoBehaviour
{
    private TextMeshProUGUI counter;

    public int hited = 0;

    public int missed = 0;
    public int combo = 0;
    public int perfect = 0;
    public int good = 0;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        counter.text = $"Hited:{hited.ToString()} " +
                       $"Missed:{missed.ToString()} " +
                       $"Combo:{combo.ToString()} " +
                       $"Perfec:{perfect.ToString()} " +
                       $"Good:{good.ToString()}";
    }
}
