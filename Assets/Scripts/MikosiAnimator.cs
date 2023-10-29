using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikosiAnimator : MonoBehaviour
{
    // 神輿
    [SerializeField] private Animator mainAni;
    // 人
    [SerializeField] private Animator LFAni;
    [SerializeField] private Animator LBAni;
    [SerializeField] private Animator RFAni;
    [SerializeField] private Animator RBAni;
    [SerializeField] private Animator tateAni;

    private bool isPause;

    private AudioSource audioSource;

    //[SerializeField] private AudioClip ohayasi;

    [SerializeField] private AudioClip bgm;
    
    [SerializeField] private AudioClip ohayasi;
    // Start is called before the first frame update
    void Start()
    {
        //PlayAnimation();
        audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.anyKeyDown) PlayAnimation();

        if (isPause)
        {
            float volume = 1 - (Time.deltaTime / 5.0f);
            gameObject.GetComponent<AudioSource>().volume -= Time.deltaTime / 5.0f;
        }
    }

    public IEnumerator PlayAnimation()
    {
        audioSource.clip = ohayasi;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(10);
        mainAni.SetBool("PlayAnimation", true);
        LFAni.SetBool("PlayAnimation", true);
        LBAni.SetBool("PlayAnimation", true);
        RFAni.SetBool("PlayAnimation", true);
        RBAni.SetBool("PlayAnimation", true);
        tateAni.SetBool("PlayAnimation", true);
        yield return new WaitForSeconds(40);
        isPause = true;
        yield return new WaitForSeconds(5);
        mainAni.enabled = false;
        LFAni.enabled = false;
        LBAni.enabled = false;
        RFAni.enabled = false;
        RBAni.enabled = false;
        tateAni.enabled = false;
        yield return new WaitForSeconds(6);
        audioSource.clip = bgm;
        audioSource.volume = 0.2f;
        audioSource.Play();
    }
}
