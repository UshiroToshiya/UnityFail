using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject particle;
    public AudioClip exprosionSound;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }*/
    //接触した時のメソッド
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlusScore")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(exprosionSound, this.transform.position);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        

        Invoke("ThisDestory", 5f);
        
    }

    void ThisDestory()
    {
        Destroy(this.gameObject);
    }

    

}
