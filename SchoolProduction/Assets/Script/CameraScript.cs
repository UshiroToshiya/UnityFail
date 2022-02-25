using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public UIManager uIManager;
    public float rotationSpeed = 3;

    private PlayerController playerScript;
    

    Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
       // startPosition = Camera.main.transform.localRotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (uIManager.timeUpCheck != true)
        {
            AroundCamera();
        }
        
       
    }

    //右スティックでカメラを回すメソッド
    void AroundCamera()
    {
        float horizontalAngle = playerScript.rightStick.x * rotationSpeed * Time.deltaTime;

        transform.position += player.transform.position - playerPosition;
        playerPosition = player.transform.position;


        if(horizontalAngle != 0)
        {
            //右スティック左右でカメラ移動
            Camera.main.transform.RotateAround(playerPosition, Vector3.up, horizontalAngle);
        }
        
    }



}
