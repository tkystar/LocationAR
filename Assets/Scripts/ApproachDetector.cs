using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ApproachDetector : MonoBehaviour
{
    public bool IsApproach;
    // Start is called before the first frame update
    void Start()
    {
        IsApproach = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("MainCamera")) return;

        IsApproach = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("MainCamera")) return;

        IsApproach = false;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("MainCamera")) return;

        IsApproach = true;
    }
}
