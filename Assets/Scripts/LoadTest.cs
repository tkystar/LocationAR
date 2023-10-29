using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadTest : MonoBehaviour
{
    private Image circleImage;

    private bool isOn;

    private float time;

    [SerializeField] private GameObject startButton;

    [SerializeField] private GameObject loadObj;

    private AudioSource audio;
    
    [SerializeField] private AudioClip popUp;
    
    [SerializeField] private AudioClip popUpClose;

    public bool IsLocalizing = false;

    [SerializeField] private Image background;

    [SerializeField] private Sprite complete;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startButton.SetActive(false);
        isOn = false;
        StartCoroutine(Loading());
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            time += Time.deltaTime;
        }

        //circleImage.fillAmount = time / 7;

        if (time > 7)
        {
            if (IsLocalizing)
            {
                Complete();
                
                time = 0;
                isOn = false;
            }
            
        }
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.0f);
        isOn = true;
    }

    private void Complete()
    {
        audio.clip = popUp;
        audio.Play();
        background.sprite = complete;
        startButton.SetActive(true);
        loadObj.SetActive(false);
    }
}
