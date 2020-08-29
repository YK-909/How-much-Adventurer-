using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0f;
    public float Sprintspeed = 10.0f;
    //アイテム回収時の数の集計
    public int itemcount;
    public int treasurecount;
    //敵と当たった時
    private int stan;
    public GameObject Stan;
    // Start is called before the first frame update
    void Start()
    {
        itemcount = 0;
        treasurecount = 0;
        stan = 0;
    }

    // Update is called once per frame
    //修正
    void Update()
    {
        if (stan == 0)
        {
            if (Input.GetKey("w"))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("left shift") && Input.GetKey("w"))
            {
                transform.position += transform.forward * Sprintspeed * Time.deltaTime;
            }
            if (Input.GetKey("left shift") && Input.GetKey("s"))
            {
                transform.position += transform.forward * Sprintspeed * Time.deltaTime;
            }
            if (Input.GetKey("left shift") && Input.GetKey("d"))
            {
                transform.position += transform.forward * Sprintspeed * Time.deltaTime;
            }
            if (Input.GetKey("left shift") && Input.GetKey("a"))
            {
                transform.position += transform.forward * Sprintspeed * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //アイテムのカウント
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            itemcount = itemcount + 1;
        }
        //宝のカウント
        if (other.gameObject.CompareTag("Treasure"))
        {
            //other.gameObject.SetActive(false);
            treasurecount = treasurecount + 1;
        }
        //敵キャラに当たった時にノックバック
        if (other.gameObject.CompareTag("Enemy"))
        {
            var rd = GetComponent<Rigidbody>();
            //right→forwrard
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
            stan = 1;
            Stan.SetActive(true);
            Invoke("Stan2", 2f);
        }
    }
    void Stan2()
    {
        stan = 0;
        Stan.SetActive(false);
    }
}