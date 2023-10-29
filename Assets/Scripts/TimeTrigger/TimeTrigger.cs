using System;
using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TimeTrigger : MonoBehaviour
{
    private int targetHour = 0;   // 発火したい時刻の時
    private int targetMinute = 0; // 発火したい時刻の分
    
    // アナウンス時間
    private int announceHour = 0;   // 発火したい時刻の時
    private int announceMinute = 0; // 発火したい時刻の分
    public int beforeN;
    private bool eventTriggered = false;
    private bool announceTriggerd;

    [SerializeField] private MikosiAnimator mikosiAni;
    
    // 処理関連の具体インスタンス
    private UIManager uiManager;
    
    private AudioSource BGM;

    [SerializeField] private AudioClip ohayasi;

    private void Start()
    {
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();

        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        // イベントが発火済みかどうかをリセット
        eventTriggered = false;
        
        // 時間成形
        // 本番は修正
        //targetHour = System.DateTime.Now.Hour;
        //targetMinute = System.DateTime.Now.Minute + 1;
        targetHour = 12;
        targetMinute = 20;
        AdjustTime(targetHour, targetMinute, 5);
    }

    private void Update()
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
            ResetTriggerTime();
        }
    
    
        
        // 指定した時刻と分に達したかどうかをチェック
        if (currentHour == announceHour && currentMinute == announceMinute)
        {
            // イベントを発火
            Announce();
            announceTriggerd = true;
            ResetAnnounceTime();
        }
        
    }

    // 時間のN分前に実行したい処理を記述
    private void Announce()
    {
        Debug.Log("announce");
        uiManager.EnableAnnounceMikosiPanel();
        //BGM.clip = ohayasi;
        //BGM.Play();
        //BGM.loop = true;
    }

    
    // 時間になった時に実行したい処理を記述
    private void Invoke()
    {
        Debug.Log("time");
        StartCoroutine(mikosiAni.PlayAnimation());
    }

    private void AdjustTime(int hour, int minute, int N)
    {
        // n時が変わってしまう場合,例)15:05の10分前
        if (minute - N < 0)
        {
            announceHour = hour - 1;
            announceMinute = 60 + minute - N;
            Debug.Log(announceHour + ":" + announceMinute);
            return;
        }

        announceHour = hour;
        announceMinute = minute - N;
        Debug.Log(announceHour + ":" + announceMinute);

    }
    public void SetTime()
    {
        int.TryParse(GameObject.Find("Hour").GetComponent<TMP_InputField>().text, out targetHour);
        int.TryParse(GameObject.Find("Minute").GetComponent<TMP_InputField>().text, out targetMinute);
        int.TryParse(GameObject.Find("N").GetComponent<TMP_InputField>().text, out beforeN);
        AdjustTime(targetHour, targetMinute, beforeN);
    }

    private void ResetTriggerTime()
    {
        targetHour = 0;
        targetMinute = 0;
    }
    private void ResetAnnounceTime()
    {
        announceHour = 0;
        announceMinute = 0;
    }

}