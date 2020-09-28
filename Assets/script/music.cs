using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{
    //ヒエラルキーからD&Dしておく
    public AudioSource BGM_title;
    public AudioSource BGM_main;
    public AudioSource BGM_result;

    //１つ前のシーン名
    private string beforeScene = "title";

    // Use this for initialization
    void Start()
    {
        //自分と各BGMオブジェクトをシーン切り替え時も破棄しないようにする
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(BGM_title.gameObject);
        DontDestroyOnLoad(BGM_main.gameObject);
        DontDestroyOnLoad(BGM_result.gameObject);

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //シーンが切り替わった時に呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定

        //メニューからメインへ
        if (beforeScene == "tittle" && nextScene.name == "SampleScene")
        {
            BGM_title.Stop();
            BGM_main.Play();
            BGM_result.Stop();
        }

        //メインからメニューへ
        if (beforeScene == "SampleScene" && nextScene.name == "result")
        {
            BGM_main.Stop();
            BGM_title.Stop();
            BGM_result.Play();
        }

        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
    }
}
