using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GarappaAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        Vector3[] path = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 20),
            new Vector3(10, 0, 20),
            new Vector3(10, 0, 0),
        };
        */
        Vector3 a = transform.position;
        Vector3[] path = new Vector3[] {
            
            new Vector3(a.x, a.y, a.z + 2),
            new Vector3(a.x + 5, a.y, a.z + 2),
            new Vector3(a.x + 5, a.y, a.z),
        };

        // アニメーションの持続時間
        float duration = 30f;

        // ループの設定
        int loopCount = -1; // -1は無限ループ

        // 移動パスを設定し、ループさせる
        var doPath = transform.DOPath(path, duration, PathType.CatmullRom)
            .SetOptions(true)
            .SetLookAt(0.0f, Vector3.forward, Vector3.up)
            .SetLoops(loopCount, LoopType.Restart); 

        // ループが終了したときのコールバックを設定
        doPath.OnKill(() => {
            doPath.Restart(); // アニメーションを即座に再生
        });
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
