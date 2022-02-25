using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Result : MonoBehaviour
{
    
    public GameObject aquireChan;
    public GameObject retryButton;
    public GameObject titleButton;
    public GameObject explotion;
    public GameObject hearts;
    public GameObject hexagon;
    public AudioClip resultGoodVoice;
    public AudioClip resultBadVoice;
    public AudioClip resultShowVoice;
    public AudioClip resultNoVoice;
    public AudioClip retryVoice;
    public AudioClip retryYes;
    public AudioClip retryNo;
    public static int resultScore;
    public Text resultScoreText;
    public string returnTitleName;
    public string returnRetryName;
    private AudioSource audioSource;
    private Animator animator;
    private bool buttonActive = false;
    private bool numCheck = false;
    private int random;
    private float cross;
    private float circle;
    private bool buttonClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = aquireChan.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(resultShowVoice);
        resultScore = GameController.resultScore;
        Invoke("ResultScore", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!numCheck)
        {
            random = Random.Range(0, 9999);
        }
        
        resultScoreText.text = "" + random;

        if (buttonActive)
        {
            ButtonActive();
            TitleButton();
            RetryButton();
        }
    }
    //最終スコアを表示
    int ResultScore()
    {
        random = GameController.resultScore;
        numCheck = true;
        Invoke("ResultVoice", 1f);
        return random;
    }
    //スコアによりAquireChanの行動が変化
    void ResultVoice()
    {
        if(random > 1000 && random < 2500)
        {
            audioSource.PlayOneShot(resultBadVoice);
            animator.Play("Happy");
            hexagon.gameObject.SetActive(true);

        }
        else if(random <= 1000)
        {
            audioSource.PlayOneShot(resultNoVoice);
            explotion.gameObject.SetActive(true);
            animator.Play("Angry");
        }
        else if(random >= 2500)
        {
            audioSource.PlayOneShot(resultGoodVoice);
            animator.Play("VeryHappy");
            hearts.gameObject.SetActive(true);
        }

        Invoke("Retry", 4f);
    }
    //retryVoiceを流すメソッド
    void Retry()
    {
        audioSource.PlayOneShot(retryVoice);
        buttonActive = true;
    }
    //Titleボタンを押した時のメソッド
    public void TitleButton()
    {
        
        returnTitleName = Title.getSceneName();
        cross = Input.GetAxis("Cross");

        if (cross == 1)
        {
            if (buttonClicked)
            {

                return;
            }
            buttonClicked = true;
            audioSource.PlayOneShot(retryNo);
            Invoke("TitleTrandision", 3f);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Invoke("TitleTrandision", 3f);
        }
    }

    //Retryボタンを押した時のメソッド
    public void RetryButton()
    {
        
        returnRetryName = GameController.getSceneName();
        circle = Input.GetAxis("Circle");

        if (circle == 1)
        {
            if (buttonClicked)
            {

                return;
            }
            buttonClicked = true;
            audioSource.PlayOneShot(retryYes);
            Invoke("GameTrandision", 3f);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Invoke("GameTrandision", 3f);
        }
    }

    
    //ボタンをActiveにするメソッド
    void ButtonActive()
    {
        retryButton.SetActive(true);
        titleButton.SetActive(true);
    }
    //タイトルに移動するメソッド
    void TitleTrandision()
    {
        SceneManager.LoadScene(returnTitleName);
    }

    //ゲームシーンに移動するメソッド
    void GameTrandision()
    {
        SceneManager.LoadScene(returnRetryName);
    }
   
}
