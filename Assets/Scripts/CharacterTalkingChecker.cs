using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTalkingChecker : MonoBehaviour
{
    // カメラへの参照
    private Camera mainCamera;

    [SerializeField] private Animator animator;
    
    // オブジェクトがカメラに映っているかどうかを示すフラグ
    private bool isVisible = false;

    private AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        if (mainCamera == null)
        {
            // シーン内のメインカメラを取得
            mainCamera = Camera.main;

            if (mainCamera == null)
            {
                Debug.LogError("Main camera not found in the scene.");
                return;
            }
        }
    }

    private void Update()
    {
        // オブジェクトがカメラのビューポート内に表示されるかどうかをチェック
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
            viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
            viewportPosition.z >= 0)
        {
            // カメラからの距離を計算
            float distanceToCamera = Vector3.Distance(mainCamera.transform.position, transform.position);

            Debug.Log("distance" + distanceToCamera);
            // オブジェクトがカメラ内に入り、カメラからの距離が3メートル以内の場合
            if (!isVisible && distanceToCamera <= 2.5f)
            {
                animator.SetBool("talking", true);
                
                // カメラの位置を取得し、オブジェクトの親オブジェクトを向かせる
                //Vector3 cameraPosition = mainCamera.transform.position;
                //transform.parent.LookAt(cameraPosition);
                // カメラの位置を取得
                Vector3 cameraPosition = mainCamera.transform.position;

                // カメラの位置を親オブジェクトの位置から差分ベクトルとして計算
                Vector3 lookDirection = cameraPosition - transform.parent.position;

                // Y軸の回転を計算
                float angle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;

                // 親オブジェクトをY軸で回転させる
                transform.parent.rotation = Quaternion.Euler(0f, angle, 0f);
                audio.Play();
                
                Debug.Log("Object is now visible in the camera's viewport and within 5 meters.");
                isVisible = true;
            }
        }
        else
        {
            // オブジェクトがカメラのビューポート外に出た場合、フラグをリセットする
            animator.SetBool("talking", false);
            audio.Pause();
            isVisible = false;
        }
    }
}
