using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    private float cross;
    
    public string returnSceneName;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        ExitButton();
    }


    //Exitボタンを押した時
    public void ExitButton()
    {
        returnSceneName = Title.getSceneName();
        cross = Input.GetAxis("Cross");
        
        if (cross == 1)
        {
            SceneManager.LoadScene(returnSceneName);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(returnSceneName);
        }
    }

}
