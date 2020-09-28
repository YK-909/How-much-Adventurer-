using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreall : MonoBehaviour
{
    public Text salamanderText;
    public Text salamanderallpoint;
    public Text snakeText;
    public Text snakeallpoint;
    public Text treasureText;
    public Text treasureallpoint;
    public Text allscore;
    int salamanderHunt;
    int snakeHunt;
    int treasurecount;
    int all;
    // Start is called before the first frame update
    void Start()
    {
        salamanderHunt = SalamanderMove.getsalamanderHunt();
        salamanderText.text = string.Format("サラマンダー:{0}体", salamanderHunt);
        salamanderallpoint.text = string.Format("{0}", salamanderHunt * 30);
        snakeHunt = SnakeMove.getsalamanderHunt();
        snakeText.text = string.Format("ヘビ:{0}匹", snakeHunt);
        salamanderallpoint.text = string.Format("{0}", snakeHunt * 20);
        treasurecount = PlayerMove.getTreasure();
        treasureText.text = string.Format("宝物:{0}個", treasurecount);
        treasureallpoint.text = string.Format("{0}", treasurecount * 40);
        all = salamanderHunt * 30 + snakeHunt * 20 + treasurecount * 40;
        allscore.text = string.Format("合計:{0}点", all);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
