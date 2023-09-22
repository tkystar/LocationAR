using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject announcePanel;

    private AudioSource audio;

    [SerializeField] private AudioClip popUp;
    
    [SerializeField] private AudioClip popUpClose;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableAnnouncePanel()
    {
        announcePanel.SetActive(false);
        audio.clip = popUpClose;
        audio.Play();
    }
    
    public void EnableAnnouncePanel()
    {
        announcePanel.SetActive(true);
        audio.clip = popUp;
        audio.Play();
    }
}
