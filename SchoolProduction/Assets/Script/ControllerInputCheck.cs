using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputCheck : MonoBehaviour
{
    public PlayerController playerScript;
    public AudioClip angry;
    public AudioClip thanksVoice;
    public AudioClip bombThrowVoice;
    public AudioClip veryHappy;
    public AudioClip happy;
    public AudioClip jumpVoice;
    public bool bombThrowing = false;
    public bool appealCheck = false;
    public BombShoot bombShoot;
    public CameraScript cameraScript;
    public GameController gameController;

    private Animator animator;
    private AudioSource audioSource;

    private new Rigidbody rigidbody;
    private  bool buttonClicked = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
       
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //左スティックを入力した時
        LeftStickInput();

        //✕ボタンを押したとき
        CrossInput();

        //〇ボタンを押したとき
        
        CircleInput();
        
        
        //△ボタンを押したとき
        TriangleInput();
        

        //R3ボタンを押したとき
        R3Input();

        //L3ボタンを押したとき
        L3Input();

        //Optionボタンを押したとき
        if (playerScript.optionButton == 1)
        {
            enabled = true;
        }
        //Shereボタンを押したとき
        if (playerScript.shereButton == 1)
        {
            Debug.Log("Shere");
        }
        if(playerScript.psButton == 1)
        {
            Debug.Log("psButton");
        }
        //trackpadを押したとき
        TrackpadInput();
       
    }

    //〇を押した時のメソッド
    public void CircleInput()
    {
        if(gameController.BombCount < gameController.maxBombCount)
        {
            if (playerScript.circleButton == 1)
            {
                if (buttonClicked)
                {
                    return;
                }

                buttonClicked = true;
                animator.SetBool("BombThrow", true);
                audioSource.PlayOneShot(bombThrowVoice);
                bombShoot.Shoot();
                StartCoroutine(ClickedButton());

            }
        }
        
      
    }
    //ボタンを押したら1秒後に使用可能にする
    IEnumerator ClickedButton()
    {
        yield return new WaitForSeconds(1f);
        buttonClicked = false;
    }
    //△を押したときのメソッド
    public void TriangleInput()
    {
        if (IsThanksCheck())
        {
            return;
        }

        if (playerScript.triangleButton == 1)
        {
           if (playerScript.jumpping == false)
           {
                animator.Play("Thanks");
                audioSource.PlayOneShot(thanksVoice);
           }
        }
      
    }
    //左スティックを入力した時のメソッド
    public void LeftStickInput()
    {
        //倒した方向にアニメーションを実装
        if (playerScript.playerVector.x != 0 || playerScript.playerVector.z != 0)
        {

            playerScript.transformDirection();

            animator.SetBool("Walking", true);
            if (Mathf.Abs(rigidbody.velocity.x) > 3f || Mathf.Abs(rigidbody.velocity.z) > 3f)
            {
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Running", false);
            }
        }
        else
        {
            
            animator.SetBool("BombThrow", false);
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
        }
    }

    //✕を入力した時のメソッド
    public void CrossInput()
    {
        if (playerScript.crossButtion == 1)
        {
            if (playerScript.jumpping == false)
            {
                playerScript.Jump();
                audioSource.PlayOneShot(jumpVoice);
            }
 
        }
    }
    //トラックパッドを押した時のメソッド
    public void TrackpadInput()
    {
        if (IsHappyAppeal())
        {
            return;
        }
       
        if (playerScript.trackpad == 1)
        {
            animator.Play("Happy");
            audioSource.PlayOneShot(happy);
        }
        
    }
    //R3を押した時のメソッド
    public void R3Input()
    {
        if (IsAngryAppeal())
        {
            return;
        }
        if (playerScript.R3Button == 1)
        {
            animator.Play("Angry");
            audioSource.PlayOneShot(angry);

        }
    }
    //L3を押した時のメソッド
    public void L3Input()
    {
        if (IsVeryHappyAppeal())
        {
            return;
        }
        if (playerScript.L3Button == 1)
        {
            animator.Play("VeryHappy");
            audioSource.PlayOneShot(veryHappy);
        }
    }

    //Happyアニメーション判定
    bool IsHappyAppeal()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Happy");
    }

    //VeryHappyアニメーション判定
    bool IsVeryHappyAppeal()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("VeryHappy");
    }
    //Angtyアニメーション判定
    bool IsAngryAppeal()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Angry");
    }

    //Thanksアニメーション判定

    bool IsThanksCheck()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Thanks");
    }


}
