using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject announceGrappaPanel;
    [SerializeField] private GameObject announceMikosiPanel;
    [SerializeField] private GameObject discoverGrappaPanel;

    private AudioSource audio;

    [SerializeField] private AudioClip popUp;
    
    [SerializeField] private AudioClip popUpClose;

    public bool LocalizeCompleted;

    private bool discoverAnnounce;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        discoverAnnounce = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableAnnounceGrappaPanel()
    {
        announceGrappaPanel.SetActive(false);
        audio.clip = popUpClose;
        audio.Play();
    }
    
    public void EnableAnnounceGarappaPanel()
    {
        if(!LocalizeCompleted) return;
        
        announceGrappaPanel.SetActive(true);
        audio.clip = popUp;
        audio.Play();
    }
    
    public void DisableAnnounceMikosiPanel()
    {
        announceMikosiPanel.SetActive(false);
        audio.clip = popUpClose;
        audio.Play();
    }
    
    public void EnableAnnounceMikosiPanel()
    {
        if(!LocalizeCompleted) return;

        announceMikosiPanel.SetActive(true);
        audio.clip = popUp;
        audio.Play();
    }
    
    public void EnableDiscoverGarappaPanel()
    {
        if(!LocalizeCompleted) return;
        if(!discoverAnnounce) return;

        discoverGrappaPanel.SetActive(true);
        announceGrappaPanel.SetActive(false);
        audio.clip = popUp;
        audio.Play();
        StartCoroutine(DisableAnnounce());
    }

    private IEnumerator DisableAnnounce()
    {
        discoverAnnounce = false;
        yield return new WaitForSeconds(20);
        discoverAnnounce = true;
    }
}
