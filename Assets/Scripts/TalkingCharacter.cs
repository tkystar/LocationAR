using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingCharacter : MonoBehaviour
{
    [SerializeField] private ApproachDetector detector;

    private Animator animator;

    [SerializeField] private AudioSource audio;

    private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
        animator = GetComponent<Animator>();
        //audio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detector.IsApproach)
        {
            PlayAnimation();
            Rotate();
            return;
        }

        PauseAnimation();
    }

    private void PlayAnimation()
    {
        if(!isOn) return;

        isOn = false;
        // 声を再生
        audio.Play();
        // アニメーションを再生
        animator.SetBool("isApproach", true);
    }
    
    private void PauseAnimation()
    {
        isOn = true;
        // 声を停止
        audio.Pause();
        // アニメーションを停止
        animator.SetBool("isApproach", false);
    }

    private void Rotate()
    {
        // カメラが目標オブジェクトを向くように設定
        Vector3 lookDirection = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
