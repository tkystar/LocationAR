using System.Collections;
using System.Collections.Generic;
using Google.XR.ARCoreExtensions;
using UnityEngine;
using UnityEngine.UI;

public class LocationDebugger : MonoBehaviour
{
    public Text locationLog;

    // Update is called once per frame
    void Update()
    {
        // その場での最新の配列（緯度、経度）を返す。
        var location = Input.location.lastData;

        //var vpsAvailabilityPromise = AREarthManager.CheckVpsAvailabilityAsync(location.latitude, location.longitude);
        
        locationLog.text = location.ToString();
    }
}
