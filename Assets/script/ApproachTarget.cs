using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    //ターゲットオブジェクトのTrnsformコンポーネントを格納する変数
    public Transform target;
    //オブジェクトの移動速度を格納
    public float moveSpeed;
    //オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    //オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;

    // Update is called once per frame
    void Update()
    {
        //変数tragetPosを作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;
        //自分自身のY座標を変数targetのY座標に格納
        //(ターゲットオブジェクトのX,Z座標のみ参照)
        targetPos.y = transform.position.y;
        //オブジェクトを変数targetの座標方向に向かせる
        transform.LookAt(target);

        //変数distanceを作成してオブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, target.position);

        //オブジェクトとターゲットオブジェクトの距離判定
        //変数distance(ターゲットオブジェクトの距離)が変数moveDistanceの値より小さければ
        //さらに変数distanceが変数stopDistanceの値よりも大きい場合
        if (distance < moveDistance && distance > stopDistance)
        {
            //変数moveSpeedを乗算した速度でオブジェクトを前方向に移動する
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}