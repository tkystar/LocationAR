using UnityEngine;

public class TimeTrigger : MonoBehaviour
{
    public int targetHour = 0;   // 発火したい時刻の時
    public int targetMinute = 0; // 発火したい時刻の分
    public int annouceMinute;
    private bool eventTriggered = false;

    private void Start()
    {
        // イベントが発火済みかどうかをリセット
        eventTriggered = false;
    }

    private void Update()
    {
        if (!eventTriggered)
        {
            // 現在の時刻を取得
            int currentHour = System.DateTime.Now.Hour;
            int currentMinute = System.DateTime.Now.Minute;

            // 指定した時刻と分に達したかどうかをチェック
            if (currentHour == targetHour && currentMinute == targetMinute)
            {
                // イベントを発火
                Invoke();
                eventTriggered = true;
            }
        }
    }


    private void Invoke()
    {
        Debug.Log("time");
    }
}