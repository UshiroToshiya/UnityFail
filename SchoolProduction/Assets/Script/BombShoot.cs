using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShoot : MonoBehaviour
{
    public GameObject[] bombPrefabs;
    public GameObject player;
    public GameController gameController;
    public float shootForce;
    public int ricoverSeconds = 0;
    public Vector3 shootTorque;
   

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    //キャンディをランダムに生成
    GameObject RandomSelectBomb()
    {
        //PrefabからBombオブジェクトを生成
        int index = Random.Range(0, bombPrefabs.Length);
        return bombPrefabs[index];
    }

    //キャンディを飛ばすメソッド
    public void Shoot()
    {
        //BombCountを1増加
        gameController.BombCount++;
        //任意の時間でBombCountを1回復
        StartCoroutine(RecoverBombCount());

        Vector3 instantiateBombPosition = this.transform.forward + player.transform.position;
        //BombオブジェクトのRigidbodyを取得し力と回転を加える
        GameObject bombInstantiate = (GameObject)Instantiate(RandomSelectBomb(), instantiateBombPosition, Quaternion.identity);


        Rigidbody bombRigidbody = bombInstantiate.GetComponent<Rigidbody>();
        bombRigidbody.AddForce(shootForce * transform.forward);
        bombRigidbody.AddTorque(shootTorque);

        
    }
    //ボムの再充填時間のメソッド
    IEnumerator RecoverBombCount()
    {
        yield return new WaitForSeconds(ricoverSeconds);
        gameController.BombCount--;
    }

}
