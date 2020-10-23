using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject Bot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Bot)
            Bot.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Bot)
            Bot.transform.parent = null;
    }
}
