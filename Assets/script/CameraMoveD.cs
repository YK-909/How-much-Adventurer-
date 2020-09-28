using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveD : MonoBehaviour
{
    private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用

    // Use this for initialization
    void Start()
    {

        //()内にオブジェクト名をいれてPlayerの情報を取得
        this.player = GameObject.Find("Player");

        // MainCamera(自分自身)とPlayerとの相対距離を求める
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;

    }
}
