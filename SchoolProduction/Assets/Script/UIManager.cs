using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text limitTimeText;
    public Text timeUp;
    public Text timeString;
    public float limitTime = 60.0f;
    public bool timeUpCheck = false;
    public GameController gameController;
    public Slider bombBar;

    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        //スコアを表示
        
        scoreText.text = "Score : " + gameController.Score + "P";

        LimitTime();
        BombBar();
        
    }
    //残り時間を表示するメソッド
    public void LimitTime()
    {

        limitTime -= Time.deltaTime;
        limitTimeText.text = limitTime.ToString("f1");
        if(limitTime < 0)
        {
            limitTimeText.text = "";
            timeUp.gameObject.SetActive(true);
            timeString.gameObject.SetActive(false);
            timeUpCheck = true;
        }
    }

    //BombBarの処理メソッド
    public void BombBar()
    {
        
        bombBar.value = gameController.BombCount;
    }
        
   

}
