using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBecameVisibleTest : MonoBehaviour
{
    /// <summary>
    /// Rendererが任意のカメラから見えると呼び出される
    /// </summary>
    
    private void OnBecameVisible()
    {
        Debug.Log("Visible");
    }
    
    /// <summary>
    /// Rendererがカメラから見えなくなると呼び出される
    /// </summary>
    private void OnBecameInvisible()
    {
        Debug.Log("InVisible");
    }
    
   
}
