using UnityEngine;

public class GarappaDiscoverChecker : MonoBehaviour
{
    // カメラへの参照
    private Camera mainCamera;
    private UIManager uiManager;
    
    // オブジェクトがカメラに映っているかどうかを示すフラグ
    private bool isVisible = false;

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        
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
            if (!isVisible && distanceToCamera <= 3.0f)
            {
                uiManager.EnableDiscoverGarappaPanel();
                Debug.Log("Object is now visible in the camera's viewport and within 3 meters.");
                isVisible = true;
            }
        }
        else
        {
            // オブジェクトがカメラのビューポート外に出た場合、フラグをリセットする
            isVisible = false;
        }
    }
}