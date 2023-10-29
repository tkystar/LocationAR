using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationFence : MonoBehaviour
{
    [Header("侵入時に通知ポップアップを表示させたい場合のみ保持。それ以外はオブジェクトごと消す")]
    private UIManager uiManager;

    private bool enableAnnounce;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableAnnounce());
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!enableAnnounce) return;
        
        if (other.gameObject.CompareTag("MainCamera"))
        {
            uiManager.EnableAnnounceGarappaPanel();
            StartCoroutine(DisableAnnounce());
        }
    }

    private IEnumerator DisableAnnounce()
    {
        enableAnnounce = false;
        yield return new WaitForSeconds(10);
        enableAnnounce = true;
    }
}
