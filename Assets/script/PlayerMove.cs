﻿using System.Collections;
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
    public int itemcount;
    public int treasurecount;
    //敵と当たった時
    private int stan;
    public GameObject Stan;
    // Start is called before the first frame update
    void Start()
    {
        animtor = GetComponent<Animator>();
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
            if (Input.GetKey("left shift"))
            {
                speed = Sprintspeed;
            }
            else
            {
                //歩きの速さの調整をする際はここも
                speed = 3.0f;
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
            }
            else
            {
                animtor.SetBool("player walking", false);
                animtor.SetBool("player running", false);
            }

            if (Input.GetKey("z"))
            {
                if (weapon == 0)
                {
                    animtor.SetBool("Sword Attack", true);
                    Invoke("AttackInterval", 1.05f);
                }
                else if (weapon == 1)
                {
                    animtor.SetBool("Lance Attack", true);
                    Invoke("AttackInterval", 0.45f);
                }
                else if (weapon == 2)
                {
                    animtor.SetBool("Axe Attack", true);
                    Invoke("AttackInterval", 1.05f);
                }
            }

            //武器チェンジ
            if (Input.GetKey("c"))
            {
                weapon += 1;
                if (weapon > 3) 
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
                    sword.SetActive(true);
                    lance.SetActive(false);
                    axe.SetActive(true);
                }

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
        //スタンした時
        if (other.gameObject.CompareTag("Enemy"))
        {
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
            stan = 1;
            Stan.SetActive(true);
            Invoke("Stan2", 2f);
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
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
        }
        if (other.gameObject.CompareTag("Salamander"))
        {
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 15f, ForceMode.VelocityChange);
        }
        if (other.gameObject.CompareTag("Fire"))
        {
            var rd = GetComponent<Rigidbody>();
            rd.AddForce(-transform.forward * 10f, ForceMode.VelocityChange);
        }
    }
    void Stan2()
    {
        stan = 0;
        Stan.SetActive(false);
    }

    void AttackInterval()
    {
        animtor.SetBool("Sword Attack", false);
        animtor.SetBool("Axe Attack", false);
        animtor.SetBool("Lance Attack", false);
        //他の武器も同様に
    }
}