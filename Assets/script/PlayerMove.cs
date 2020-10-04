using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //アニメーションのため
    private Animator animtor;
    public float speed = 3.0f;
    public float Sprintspeed = 10.0f;
    //武器チェンジ
    public int weapon;
    public GameObject sword;
    public GameObject lance;
    public GameObject axe;
    //アイテム回収時の数の集計
    public static int treasurecount;
    //体力
    public int playerHP;
    public Text playerHPtext;

    // Start is called before the first frame update
    void Start()
    {
        animtor = GetComponent<Animator>();
    }

    // Update is called once per frame
    //修正
    void Update()
    {
            if (Input.GetKey("left shift"))
            {
                speed = Sprintspeed;
            }
            else
            {
                //歩きの速さの調整をする際はここも
                speed = 2.0f;
            }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }

            if (transform.position.z >= 111)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += transform.forward * speed * Time.deltaTime;
            animtor.SetBool("player waiking", true);
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }

            if (transform.position.z <= 5)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position += transform.forward * speed * Time.deltaTime;
            animtor.SetBool("player waiking", true);
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }

            if (transform.position.x >= 235)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position += transform.forward * speed * Time.deltaTime;
            animtor.SetBool("player waiking", true);
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }

            if (transform.position.x <= 5)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        else
        {
            animtor.SetBool("player walking", false);
            animtor.SetBool("player running", false);
        }
        
        //武器の振るモーション
            if (Input.GetKeyDown("z"))
            {
                if (weapon == 0)
                {
                　　//アニメーション
                    animtor.SetBool("sword attack", true);
                　　//一定時間後にfalseへ
                    Invoke("AttackInterval", 1.05f);
                }
                else if (weapon == 1)
                {
                    //アニメーション
                    animtor.SetBool("lance attack", true);
                    //一定時間後にfalseへ
                    Invoke("AttackInterval", 0.8f);
                }
                else if (weapon == 2)
                {
                    //アニメーション
                    animtor.SetBool("axe attack", true);
                    //一定時間後にfalseへ
                    Invoke("AttackInterval", 1.05f);
                }
            }

        //武器チェンジ
        if (Input.GetKeyDown("c"))
        {
            weapon += 1;
            if (weapon > 2)
            {
                weapon = 0;
            }

            if (weapon == 0)
            {
                sword.SetActive(true);
                lance.SetActive(false);
                axe.SetActive(false);
            }
            else if (weapon == 1)
            {
                sword.SetActive(false);
                lance.SetActive(true);
                axe.SetActive(false);

            }
            else if (weapon == 2)
            {
                sword.SetActive(false);
                lance.SetActive(false);
                axe.SetActive(true);
            }
            playerHPtext.text = string.Format("HP:{0}", playerHP);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //宝のカウント
        if (other.gameObject.CompareTag("Treasure"))
        {
            treasurecount = 1;
        }
        //敵キャラに当たった時 HP等どうするのか
        if (other.gameObject.CompareTag("Wolf"))
        {
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
        }
        if (other.gameObject.CompareTag("Rabbit"))
        {
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
        }
        if (other.gameObject.CompareTag("Snake"))
        {
            playerHP -= 15;
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
        }
        if (other.gameObject.CompareTag("Salamander"))
        {
            playerHP -= 25;
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 15f, ForceMode.VelocityChange);
        }
        if (other.gameObject.CompareTag("Fire"))
        {
            playerHP -= 15;
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
        }
    }
    public static int getTreasure()
    {
        return treasurecount;
    }

    //武器を振った後のインターバル
    void AttackInterval()
    {
        animtor.SetBool("sword attack", false);
        animtor.SetBool("axe attack", false);
        animtor.SetBool("lance attack", false);
        //他の武器も同様に
    }
}