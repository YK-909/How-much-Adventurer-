using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //SEの呼び出し
    public AudioClip swordsound;
    public AudioClip lancesound;
    public AudioClip axesound;
    AudioSource audioSource;
    //アニメーションのため
    private Animator animtor;
    public float speed = 3.0f;
    public float Sprintspeed = 10.0f;
    //武器チェンジ
    private int weapon;
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
        audioSource = GetComponent<AudioSource>();
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

       //移動方法
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //キャラクターが指定の向きを向く
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //前方に移動する
            transform.position += transform.forward * speed * Time.deltaTime;
            //ダッシュ時と歩きのアニメーション
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }
            //移動できる範囲
            if (transform.position.z >= 125)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //キャラクターが指定の向きを向く
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //前方に移動する
            transform.position += transform.forward * speed * Time.deltaTime;
            //ダッシュ時と歩きのアニメーション
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }
            //移動できる範囲
            if (transform.position.z <= 10)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //キャラクターが指定の向きを向く
            transform.rotation = Quaternion.Euler(0, 90, 0);
            //前方に移動する
            transform.position += transform.forward * speed * Time.deltaTime;
            //ダッシュ時と歩きのアニメーション
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }
            //移動できる範囲
            if (transform.position.x >= 230)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //キャラクターが指定の向きを向く
            transform.rotation = Quaternion.Euler(0, -90, 0);
            //前方に移動する
            transform.position += transform.forward * speed * Time.deltaTime;
            //ダッシュ時と歩きのアニメーション
            if (speed == Sprintspeed)
            {
                animtor.SetBool("player running", true);
            }
            else
            {
                animtor.SetBool("player walking", true);
            }
            //移動できる範囲
            if (transform.position.x <= 10)
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
                    //SE
                    audioSource.PlayOneShot(swordsound);
                    //一定時間後にfalseへ
                Invoke("AttackInterval", 1.05f);
                }
                else if (weapon == 1)
                {
                    //アニメーション
                    animtor.SetBool("lance attack", true);
                    //SE
                    audioSource.PlayOneShot(lancesound);
                    //一定時間後にfalseへ
                    Invoke("AttackInterval", 0.8f);
                }
                else if (weapon == 2)
                {
                    //アニメーション
                    animtor.SetBool("axe attack", true);
                    //SE
                    audioSource.PlayOneShot(axesound);
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
        }
        //HPテキストの表示
        playerHPtext.text = string.Format("HP:{0}", playerHP);
        //ゲームオーバー
        if(playerHP<=0)
        {
            SceneManager.LoadScene("result");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        //宝のカウント
        if (other.gameObject.CompareTag ("Treasure"))
        {
            treasurecount = 1;
        }
        //敵キャラに当たった時 HPの減少
        //ノックバック
        if (other.gameObject.CompareTag("Snake"))
        {
            playerHP -=15;
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward *80f, ForceMode.VelocityChange);
        }
        if (other.gameObject.CompareTag("Salamander"))
        {
            playerHP -= 25;
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 80f, ForceMode.VelocityChange);
        }
        if (other.gameObject.tag == "Fire")
        {
            playerHP -= 15;
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 80f, ForceMode.VelocityChange);
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