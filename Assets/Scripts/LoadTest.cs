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

    [SerializeField] private Text contentText;
    
    [SerializeField] private Text titleText;


    [SerializeField] private GameObject loadObj;

    private AudioSource audio;
    
    [SerializeField] private AudioClip popUp;
    
    [SerializeField] private AudioClip popUpClose;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startButton.SetActive(false);
        circleImage = loadObj.GetComponent<Image>();
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

        circleImage.fillAmount = time / 7;

        if (circleImage.fillAmount >= 1)
        {
            time = 0;
            isOn = false;
            Complete();
        }
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.0f);
        isOn = true;
    }

    private void Complete()
    {
        startButton.SetActive(true);
        loadObj.SetActive(false);
        audio.clip = popUp;
        audio.Play();
        titleText.text = "体験を始める";
        contentText.text = "現実世界とバーチャルが組み合わさった世界を見てみよう";
    }
}
