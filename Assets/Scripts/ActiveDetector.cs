using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Google.XR.ARCoreExtensions;
using Google.XR.ARCoreExtensions.Samples.Geospatial;
using UnityEngine;

public class ActiveDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("MainCamera")) return;
            
        Debug.Log("すり抜けた！");
        PlayScaleAnim(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("MainCamera")) return;

        Debug.Log("すり抜けた！");
        PlayScaleAnim(false);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("MainCamera")) return;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void PlayScaleAnim(bool scale)
    {
        var sequence = DOTween.Sequence();

       
//Appendで動作を追加していく
        foreach (Transform child in transform)
        {
            // 拡大
            if (scale)
            {
                child.gameObject.SetActive(true);

                /*
                float currentScale = child.gameObject.transform.localScale.x;
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 0f, 0f));
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 1.3f * currentScale, 0.4f)).SetEase(Ease.OutCubic);
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 0.7f * currentScale, 0.4f)).SetEase(Ease.OutCubic);
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 1.0f * currentScale, 0.4f)).SetEase(Ease.OutCubic);
            */
            }
            else
            {
                /*
                sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 1.2f, 0.2f)).SetEase(Ease.OutCubic);
                 sequence.Append(child.gameObject.transform.DOScale(new Vector3(1, 1, 1) * 0f, 0.3f)).SetEase(Ease.OutCubic);
                 */
                 StartCoroutine(UnActivate());
            }
            
           
        }

//Playで実行
        sequence.Play();
        
    }


    private IEnumerator UnActivate()
    {
        yield return new WaitForSeconds(1.0f);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
