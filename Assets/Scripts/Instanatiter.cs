using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanatiter : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;

    [SerializeField] private GameObject instanceCanvas;

    [SerializeField] private GameObject mainCamera;

    
    public void Instantiate()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            Instantiate(prefab[i]);
        }
        
        instanceCanvas.SetActive(false);
        StartCoroutine(ActivateCollider());
    }

    private IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(10.0f);

        mainCamera.GetComponent<CapsuleCollider>().enabled = true;
    }
}
