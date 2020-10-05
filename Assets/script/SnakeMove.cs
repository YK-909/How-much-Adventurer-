using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour
{
    //アニメーションのため
    private Animator animtor;
    //ターゲットオブジェクトのTrnsformコンポーネントを格納する変数
    public Transform target;
    //オブジェクトの移動速度を格納
    public float moveSpeed;
    //オブジェクトの攻撃速度を格納
    public float attackMove;
    //オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    //オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;
    //キャラの体力
    private float HP;
    //討伐数の確認
    public static int snakeHunt;

    void Start()
    {
        //体力の設定
        HP = 70;
        animtor = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        //被ダメ時にノックバック
        if (other.gameObject.CompareTag("SwordAttack"))
        {
            animtor.SetBool("snake damaging", true);
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 15f, ForceMode.VelocityChange);
            HP -= 30;
            if (HP <= 0)
            {
                snakeHunt += 1;
            }
        }
        else
        {
            animtor.SetBool("snake damaging", false);
        }

        if (other.gameObject.CompareTag("AxeAttack"))
        {
            animtor.SetBool("snake damaging", true);
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 15f, ForceMode.VelocityChange);
            HP -= 50;
            if (HP <= 0)
            {
                snakeHunt += 1;
            }
        }
        else
        {
            animtor.SetBool("snake damaging", false);
        }

        if (other.gameObject.CompareTag("LanceAttack"))
        {
            animtor.SetBool("snake damaging", true);
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 15f, ForceMode.VelocityChange);
            HP -= 20;
            if (HP <= 0)
            {
                snakeHunt += 1;
            }
        }
        else
        {
            animtor.SetBool("snake damaging", false);
        }
    }
    public static int getsalamanderHunt()
    {
        return snakeHunt;
    }

    // Update is called once per frame
    void Update()
    {
        //変数distanceを作成してオブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, target.position);

        //オブジェクトとターゲットオブジェクトの距離判定
        //変数distance(ターゲットオブジェクトの距離)が変数moveDistanceの値より小さければ
        //さらに変数distanceが変数stopDistanceの値よりも大きい場合
        if (distance < moveDistance && distance > stopDistance)
        {
            //オブジェクトを変数targetの座標方向に向かせる
            transform.LookAt(target);
            //変数moveSpeedを乗算した速度でオブジェクトを前方向に移動する
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            animtor.SetBool("snake running", true);
        }
        else {
            animtor.SetBool("snake running", false);
        }

        if ( distance <= stopDistance)
        {
            transform.LookAt(target);
            //攻撃
            transform.position += transform.forward*attackMove*Time.deltaTime;
            animtor.SetBool("snake attacking",true);
        }
        else{
            animtor.SetBool("snake attacking",false);
        }

        if(HP<=0)
        {
            // すぐに自分を削除
            Destroy(this.gameObject);
        }
    }
}