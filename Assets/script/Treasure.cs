using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private Animator animtor;
    private int place;
    private int once;
    public int leftMin;
    public int leftMax;
    public int rightMin;
    public int rightMax;
    // Start is called before the first frame update
    void Start()
    {
        animtor = GetComponent<Animator>();
        place = Random.Range(0, 3);
        once = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Player moveで獲得数を数えられている
        //if (place == 0)
        //{
            //左上
            //transform.position = new Vector3(leftMax, 0, rightMax);
        //}
        //if (place == 1)
        //{
            //左下
            //transform.position = new Vector3(leftMax, 0, rightMin);
        //}
        //if (place == 2)
        //{
            //右上
            //transform.position = new Vector3(leftMin, 0, rightMax);
        //}
        //if (place == 3)
        //{
            //右下
            //transform.position = new Vector3(leftMin, 0, rightMin);
        //}
        //Player moveで数を数えられている
        //獲得した時の反応もPlayer move
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (once == 0)
            {
                animtor.SetBool("open treasure ", true);
                once = 1;
            }
        }
    }
}
