using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    private Animator animator;
    int WeaponFaze,WeaponPiece,w1,w2,w3,w4,w5,s;
    int[] WeaponNumber = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        s = 0;
        for (int i = 0; i < 5; i++)
        {
            WeaponNumber[i] = 0;
        }

        //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
        //部位の種類と個数を番号で指定(剣=1,槍=2,斧=3,弓=4,無し=0),今回は剣,槍,弓
        w1 = 1;
        w2 = 2;
        w3 = 4;
        w4 = 0;
        w5 = 0;
        //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊

        //武器の個数を設定、初期画像書き換え用として配列にも入力
        if (w2 == 0)
        {
            WeaponNumber[0] = w1;
            WeaponNumber[1] = w1;
            WeaponNumber[2] = w1;
            WeaponNumber[3] = w1;
            WeaponNumber[4] = w1;
            WeaponPiece = 1;
        }
        else if (w3 == 0)
        {
            WeaponNumber[0] = w1;
            WeaponNumber[1] = w2;
            WeaponNumber[2] = w1;
            WeaponNumber[3] = w2;
            WeaponNumber[4] = w2;
            WeaponPiece = 2;
        }
        else if (w4 == 0)
        {
            WeaponNumber[0] = w1;
            WeaponNumber[1] = w2;
            WeaponNumber[2] = w3;
            WeaponNumber[3] = w1;
            WeaponNumber[4] = w3;
            WeaponPiece = 3;
        }
        else if (w5 == 0)
        {
            WeaponNumber[0] = w1;
            WeaponNumber[1] = w2;
            WeaponNumber[2] = w3;
            WeaponNumber[3] = w4;
            WeaponNumber[4] = w4;
            WeaponPiece = 4;
        }

        animator = GetComponent<Animator>();
        // オブジェクトの取得
        GameObject image_object = GameObject.Find("Image");
        // コンポーネントの取得
        Image image_component = image_object.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object2 = GameObject.Find("Image2");
        // コンポーネントの取得
        Image image_component2 = image_object2.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object3 = GameObject.Find("Image3");
        // コンポーネントの取得
        Image image_component3 = image_object3.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object4 = GameObject.Find("Image4");
        // コンポーネントの取得
        Image image_component4 = image_object4.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object5 = GameObject.Find("Image5");
        // コンポーネントの取得
        Image image_component5 = image_object5.GetComponent<Image>();
        //Resourcesフォルダから画像データを取得
        Texture2D texture = Resources.Load("剣") as Texture2D;
        Texture2D texture2 = Resources.Load("槍") as Texture2D;
        Texture2D texture3 = Resources.Load("弓") as Texture2D;
        Texture2D texture4 = Resources.Load("斧") as Texture2D;
        // Spriteを作って武器を反映させる
        if (WeaponNumber[0] == 1)
        {
            image_component2.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[0] == 2)
        {
            image_component2.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[0] == 3)
        {
            image_component2.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[0] == 4)
        {
            image_component2.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        if (WeaponNumber[1] == 1)
        {
            image_component3.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[1] == 2)
        {
            image_component3.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[1] == 3)
        {
            image_component3.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[1] == 4)
        {
            image_component3.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        if (WeaponNumber[2] == 1)
        {
            image_component4.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[2] == 2)
        {
            image_component4.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[2] == 3)
        {
            image_component4.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[2] == 4)
        {
            image_component4.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        if (WeaponNumber[3] == 1)
        {
            image_component5.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[3] == 2)
        {
            image_component5.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[3] == 3)
        {
            image_component5.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[3] == 4)
        {
            image_component5.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }

        if (WeaponNumber[4] == 1)
        {
            image_component.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[4] == 2)
        {
            image_component.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[4] == 3)
        {
            image_component.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else if (WeaponNumber[4] == 4)
        {
            image_component.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトの取得
        GameObject image_object = GameObject.Find("Image");
        // コンポーネントの取得
        Image image_component = image_object.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object2 = GameObject.Find("Image2");
        // コンポーネントの取得
        Image image_component2 = image_object2.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object3 = GameObject.Find("Image3");
        // コンポーネントの取得
        Image image_component3 = image_object3.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object4 = GameObject.Find("Image4");
        // コンポーネントの取得
        Image image_component4 = image_object4.GetComponent<Image>();
        // オブジェクトの取得
        GameObject image_object5 = GameObject.Find("Image5");
        // コンポーネントの取得
        Image image_component5 = image_object5.GetComponent<Image>();
        //Resourcesフォルダから画像データを取得
        Texture2D texture = Resources.Load("剣") as Texture2D;
        Texture2D texture2 = Resources.Load("槍") as Texture2D;
        Texture2D texture3 = Resources.Load("斧") as Texture2D;
        Texture2D texture4 = Resources.Load("弓") as Texture2D;

        //Bキー入力でアニメーションの起動及び画像の書き換え
        if (Input.GetKeyDown(KeyCode.C) && WeaponFaze == 0)
        {
            animator.SetFloat("W", 1f);
            if (WeaponNumber[s] == 1)
            {
                image_component5.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 2)
            {
                image_component5.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 3)
            {
                image_component5.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 4)
            {
                image_component5.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            s++;
            if (s == WeaponPiece)
            {
                s = 0;
            }
            WeaponFaze++;
        }
        else if (Input.GetKeyDown(KeyCode.C) && WeaponFaze == 1)
        {
            animator.SetFloat("W", 2f);
            if (WeaponNumber[s] == 1)
            {
                image_component.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 2)
            {
                image_component.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 3)
            {
                image_component.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 4)
            {
                image_component.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            s++;
            if (s == WeaponPiece)
            {
                s = 0;
            }
            WeaponFaze++;
        }
        else if (Input.GetKeyDown(KeyCode.C) && WeaponFaze == 2)
        {
            animator.SetFloat("W", 3f);
            if (WeaponNumber[s] == 1)
            {
                image_component2.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 2)
            {
                image_component2.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 3)
            {
                image_component2.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 4)
            {
                image_component2.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            s++;
            if (s == WeaponPiece)
            {
                s = 0;
            }
            WeaponFaze++;
        }
        else if (Input.GetKeyDown(KeyCode.C) && WeaponFaze == 3)
        {
            animator.SetFloat("W", 4f);
            if (WeaponNumber[s] == 1)
            {
                image_component3.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 2)
            {
                image_component3.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 3)
            {
                image_component3.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 4)
            {
                image_component3.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            s++;
            if (s == WeaponPiece)
            {
                s = 0;
            }
            WeaponFaze++;
        }
        else if (Input.GetKeyDown(KeyCode.C) && WeaponFaze == 4)
        {
            animator.SetFloat("W", 5f);
            if (WeaponNumber[s] == 1)
            {
                image_component4.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 2)
            {
                image_component4.sprite = Sprite.Create(texture2, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 3)
            {
                image_component4.sprite = Sprite.Create(texture3, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else if (WeaponNumber[s] == 4)
            {
                image_component4.sprite = Sprite.Create(texture4, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            s++;
            if (s == WeaponPiece)
            {
                s = 0;
            }
            WeaponFaze = 0;
        }
    }
}
