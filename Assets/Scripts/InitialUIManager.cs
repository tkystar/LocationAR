using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InitialUIManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;

    [SerializeField] private GameObject loadPanel;

    [SerializeField] private GameObject loadObj;

    public GameObject Panelfade;   //フェードパネルの取得

    Image fadealpha;               //フェードパネルのイメージ取得変数

    private float alpha;           //パネルのalpha値取得変数

    private bool fadeout;          //フェードアウトのフラグ変数

    public int SceneNo;

    [SerializeField] private AudioSource bgm;

    [SerializeField] private Image loadImage;

    [SerializeField] private Sprite load01;

    [SerializeField] private Sprite load02;
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        loadPanel.SetActive(false);
        
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        fadeout = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout)
        {
            FadeOut();
        }
    }

    public void StartClicked()
    {
        startPanel.SetActive(false);
        loadPanel.SetActive(true);
        StartCoroutine(LoadUI());
    }


    private IEnumerator LoadUI()
    {
        loadImage.sprite = load01;
        yield return new WaitForSeconds(3.0f);
        loadImage.sprite = load02;
        yield return new WaitForSeconds(3.0f);
        loadImage.sprite = load01;
        yield return new WaitForSeconds(3.0f);
        loadImage.sprite = load02;
        yield return new WaitForSeconds(2.0f);
        //loadPanel.GetComponent<AudioSource>().Play();
        loadObj.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        fadeout = true;
    }
    
    private void FadeOut()
    {
        alpha += Time.deltaTime / 2;
        fadealpha.color = new Color(0, 0, 0, alpha);
        bgm.volume -= alpha;
        if (alpha >= 1)
        {
            fadeout = false;
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.0f);
        // シーン遷移
        SceneManager.LoadScene("Main");
    }
}
