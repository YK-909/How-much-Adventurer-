using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //ターゲットオブジェクトのTrnsformコンポーネントを格納する変数
    public Transform target;
    // 弾丸発射点
    public Transform mouth2;
    //速度
    public float speed = 1000.0f;
    private int waittime;
    public SalamanderMove SalamanderMove;

    float firetime;

    // Start is called before the first frame update
    void Start()
    {
        waittime = 0 ;
    }

    // Update is called once per frame
    void Update()
    {
        firetime = SalamanderMove.firetime;
        if (firetime >= 1)
        {
            // GameObject FireBalls = Instantiate(Fire) as GameObject;
            //FireBalls.transform.position = transform.position + transform.forward * speed * Time.deltaTime;
            if (firetime == 1)
            {
                this.transform.position= mouth2.position;
                //firetime += 1;
                transform.LookAt(target);
            }

            //Vector3 force;
            //force = this.gameObject.transform.forward * speed ;

            // Rigidbodyに力を加えて発射
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 force = this.gameObject.transform.forward * speed;
            rb.AddForce(force);  // 力を加える
        }
    }
}
