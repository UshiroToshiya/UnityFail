using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRogoColisitionCheck : MonoBehaviour
{
    public GameObject startButton;
    public GameObject creditButton;
    public float invokeTime = 3;
    // Start is called before the first frame update
   /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Invoke("ButtonActive", invokeTime);
        }
    }

    void ButtonActive()
    {
        startButton.SetActive(true);
        creditButton.SetActive(true);

    }

}
