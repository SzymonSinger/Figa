using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Rendering;

public class BeatHiter : MonoBehaviour
{
    public JumpHandler jump;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Beat"))
        {
            jump.canJump = true;
            other.gameObject.GetComponent<KillMe>().Destroyable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Beat"))
        {
            jump.canJump = false;
            other.gameObject.GetComponent<KillMe>().Destroyable = false;
        }
    }*/
}
