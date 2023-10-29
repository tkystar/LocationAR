using UnityEngine;

public class FireworkLauncher : MonoBehaviour
{
    public ParticleSystem[] fireworks; // Inspectorで花火のパーティクルシステムをアサイン
    private int currentFirework = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 例: スペースキーで連射
        {
            fireworks[currentFirework].Stop();
            fireworks[currentFirework].Play();
            currentFirework = (currentFirework + 1) % fireworks.Length;
        }
    }
}