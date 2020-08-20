using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0f;
    //アイテム回収時の数の集計
    public int count;
    public Text countText;
    //敵と当たった時
    private int stan;
    public GameObject Stan;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        stan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stan == 0)
        {
            if (Input.GetKey("up"))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("down"))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("right"))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("left"))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //アイテムのカウント
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        //敵キャラに当たった時にノックバック
        if (other.gameObject.CompareTag("Enemy"))
        {
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.right * 10f, ForceMode.VelocityChange);
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

    //アイテムのテキスト表示
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
