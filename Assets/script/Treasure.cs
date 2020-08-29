using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private int place;
    // Start is called before the first frame update
    void Start()
    {
        place = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Player moveで獲得数を数えられている
        if (place == 0)
        {
            //左上
            transform.position = new Vector3(30, 0, 20);
        }
        if (place == 1)
        {
            //左下
            transform.position = new Vector3(30, 0, -20);
        }
        if (place == 2)
        {
            //右上
            transform.position = new Vector3(-30, 0, 20);
        }
        if (place == 3)
        {
            //右下
            transform.position = new Vector3(-30, 0, -20);
        }
        //Player moveで数を数えられている
        //獲得した時の反応もPlayer move
    }
}
