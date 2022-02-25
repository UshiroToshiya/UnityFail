using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private float circle;
    private float cross;
    public static string titleSceneName;
    // Start is called before the first frame update
    void Start()
    {
        //今のシーンを変数に代入
        titleSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        circle = Input.GetAxis("Circle");
        cross = Input.GetAxis("Cross");
        
        StartButton();
        CreditButton();
    }
    //今のSceneを取得
    public static string getSceneName()
    {
        return titleSceneName;
    }
    //Startボタン又は〇を押した時
    public void StartButton()
    {
        
        
        if(circle == 1 || Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Loading");
        }
        
    }

    //×を押した時
    public void CreditButton()
    {
      
        if (cross == 1 || Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene("CreditScene");
        }
        
    }

}
