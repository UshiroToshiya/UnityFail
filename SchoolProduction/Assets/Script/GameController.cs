using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIManager uIManager;
    public GameObject player;
    public AudioClip timeUpSound;
    public int Score { get; set; }
    public int BombCount { get ; set ; }
    public int maxBombCount = 5;
    public static int resultScore;
    public static string nowSceneName;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        //今のシーンを変数に代入
        nowSceneName = SceneManager.GetActiveScene().name;
        audioSource = GetComponent<AudioSource>();
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUp();
      
    }

    //今のSceneを取得
    public static string getSceneName()
    {
        return nowSceneName;
    }

    //制限時間に達したとき
    public void TimeUp()
    {
        if (uIManager.timeUpCheck == true)
        {
            player.SetActive(false);
            audioSource.PlayOneShot(timeUpSound);
            //最終スコアを代入
            resultScore = Score;
            //2秒後にResult画面へ
            Invoke("ResultTransition", 3f);
        }
    }

    //Score加算メソッド
    public void AddScore()
    {
        Score += 100;
    }
    //Resultシーンに移動
    void ResultTransition()
    {
        SceneManager.LoadScene("Result");
    }

}
