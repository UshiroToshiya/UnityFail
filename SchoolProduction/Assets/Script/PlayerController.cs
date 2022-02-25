using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    new Rigidbody rigidbody;
    Animator animator;
    
    public float transformSpeed = 10f;
    
    [Range(0, 1000)]
    public float jumpForce = 200f;
    const float maxVelocity = 10f;
    public bool jumpping = false;
    float jumpCount = 0;
    float startTransformSpeed;

    protected internal Vector3 playerVector = new Vector3();
    protected internal Vector3 rightStick = new Vector3();
    protected internal float squareButton;
    protected internal float crossButtion;
    protected internal float circleButton;
    protected internal float triangleButton;
    protected internal float L1button;
    protected internal float L2Button;
    protected internal float R1Button;
    protected internal float R2Button;
    protected internal float L3Button;
    protected internal float R3Button;
    protected internal float shereButton;
    protected internal float optionButton;
    protected internal float psButton;
    protected internal float trackpad;
    protected internal float rightStickHorizontal;
    protected internal float rightStickVertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        //初期TransformSpeedを取得
        startTransformSpeed = transformSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //PS4のコントローラーの入力値取得
        playerVector.x = Input.GetAxis("Horizontal");
        playerVector.z = Input.GetAxis("Vertical");
        squareButton = Input.GetAxis("Square");
        crossButtion = Input.GetAxis("Cross");
        circleButton = Input.GetAxis("Circle");
        triangleButton = Input.GetAxis("Triangle");
        L1button = Input.GetAxis("L1");
        L2Button = Input.GetAxis("L2");
        R1Button = Input.GetAxis("R1");
        R2Button = Input.GetAxis("R2");
        L3Button = Input.GetAxis("L3");
        R3Button = Input.GetAxis("R3");
        shereButton = Input.GetAxis("Share");
        optionButton = Input.GetAxis("Option");
        trackpad = Input.GetAxis("Trackpad");
        psButton = Input.GetAxis("PSButton");
        rightStick.x = Input.GetAxis("RightStickHorizontal");
        rightStick.z = -Input.GetAxis("RightStickVertical");

        Debug.Log("左"+ rigidbody.velocity.magnitude);
        Debug.Log("右" + rightStick);
    }
    //Jumpした時のメソッド
    public void Jump()
    {
       if(jumpCount <= 1)
       {
            jumpping = true;
            jumpCount++;
            transformSpeed = 0;
            rigidbody.AddForce(transform.up * jumpForce);
            animator.Play("JumpStart");

       }

    }
    //コライダー同士が接したとき
    private void OnCollisionEnter(Collision collision)
    {
        //地面と接しているとき
        if(collision.gameObject.tag == "Ground")
        {
            jumpping = false;
            jumpCount = 0;
            transformSpeed = startTransformSpeed;
        }
        
    }

    //左スティックを上下に倒した時のメソッド
    public void transformDirection()
    {
        
        //左スティックを上に倒した時
        if (playerVector.z > 0f)
        {
            rigidbody.AddForce(this.transform.forward * transformSpeed * Time.deltaTime, ForceMode.VelocityChange);
            this.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

            if(rigidbody.velocity.magnitude > maxVelocity)
            {
                rigidbody.velocity *= 0.9f;
            }
        }
        else if (playerVector.z < 0f)
        {
            //左スティックを下に倒した時
            rigidbody.AddForce(this.transform.forward * transformSpeed * Time.deltaTime, ForceMode.VelocityChange);
            this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

            if(rigidbody.velocity.magnitude > maxVelocity)
            {
                rigidbody.velocity *= 0.9f;
            }
        }

 
    }
   
}
