using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
                var sequence = DOTween.Sequence();

                float currentScale = gameObject.transform.localScale.x;
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 0f, 0f));
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 1.3f * currentScale, 0.4f)).SetEase(Ease.OutCubic);
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 0.7f * currentScale, 0.4f)).SetEase(Ease.OutCubic);
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 1.0f * currentScale, 0.4f)).SetEase(Ease.OutCubic);
           
            
        }
    }
}
