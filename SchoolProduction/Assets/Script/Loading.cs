using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public AudioClip loadingVoice;
    public Text loading;
    private AudioSource audioSource;
    private float speed = 1f;
    private float time;
    // Start is called before the first frame update
    
    void Start()
    {
        loading = loading.gameObject.GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        Invoke("LoadingVoice", 2f);
        Invoke("SceneTransition", 8f);
    }

    // Update is called once per frame
    void Update()
    {
        loading.color = GetAlphaColor(loading.color);
    }

    void SceneTransition()
    {
        SceneManager.LoadScene("GameScene");
    }

    void LoadingVoice()
    {
        audioSource.PlayOneShot(loadingVoice);
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 3.0f * speed;
        color.a = Mathf.Sin(time);
        return color;
    }
}
