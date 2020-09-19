﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamanderMove : MonoBehaviour
{
    //アニメーションのため
    private Animator animtor;
    //ターゲットオブジェクトのTrnsformコンポーネントを格納する変数
    public Transform target;
    //オブジェクトの移動速度を格納
    public float moveSpeed;
    //オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    //オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;
    //キャラの体力
    private float HP;
    //討伐数の確認
    public float salamanderHunt;
    //火の玉
    public float firetime;
    private int waittime;
    void Start()
    {
        waittime = 0;
        //体力の設定
        HP = 120;
        animtor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //変数tragetPosを作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;
        //自分自身のY座標を変数targetのY座標に格納
        //(ターゲットオブジェクトのX,Z座標のみ参照)
        targetPos.y = transform.position.y;

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
            animtor.SetBool("salamander run", true);
        }
        else
        {
            animtor.SetBool("salamander run", false);
        }

        if (distance <= stopDistance)
        {
            //攻撃とインターバル
            animtor.SetBool("salamander attack", true);
            Invoke("Fire",0.3f);
            var rd = this.GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
            Invoke("wait", 2.0f);
            if (waittime == 1)
            {
                firetime = 0;
                waittime = 0;
            }
        }
        else
        {
            animtor.SetBool("salamander attack", false);
            firetime = 0;
        }

        if (HP < 0)
        {
            salamanderHunt += 1;
            // すぐに自分を削除
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //被ダメ時にノックバック
        if (other.gameObject.CompareTag("SwordAttack"))
        {
            animtor.SetBool("salamander damage", true);
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
            HP -= 30;
        }
        else
        {
            animtor.SetBool("salamander damage", false);
        }

        if (other.gameObject.CompareTag("AxeAttack"))
        {
            animtor.SetBool("salamander damage", true);
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
            HP -= 50;
        }
        else
        {
            animtor.SetBool("salamander damage", false);
        }

        if (other.gameObject.CompareTag("LanceAttack"))
        {
            animtor.SetBool("salamander damage", true);
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
            HP -= 20;
        }
        else
        {
            animtor.SetBool("salamander damage", false);
        }
    }
    void Fire()
    {
        firetime += 1;
    }
    void wait()
    {
        waittime = 1;
    }
}