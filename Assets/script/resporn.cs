using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resporn : MonoBehaviour
{
	//　出現させる敵を入れておく
	[SerializeField] GameObject[] enemys;
	//　この場所から出現する敵の数
	[SerializeField] int maxNumOfEnemys;
	//　次に敵が出現するまでの時間
	public double appearNextTime;
	//　今何人の敵を出現させたか（総数）
	private int numberOfEnemys;
	//　待ち時間計測フィールド
	private float elapsedTime;
	//敵の出現する範囲
	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;


	// Use this for initialization
	void Start()
	{
		numberOfEnemys = 0;
		elapsedTime = 0f;
	}

	// Update is called once per frame
	void Update()
	{
			appearNextTime = 1;
			maxNumOfEnemys = 5;
		//　この場所から出現する最大数を超えてたら何もしない
		if (numberOfEnemys >= maxNumOfEnemys)
		{
			//これ以降を飛ばす
			return;
		}
		//　経過時間を足す
		elapsedTime += Time.deltaTime;

		//　経過時間が経ったら
		if (elapsedTime > appearNextTime)
		{
			elapsedTime = 0f;

			AppearEnemy();
		}
	}

	//　敵出現メソッド
	void AppearEnemy()
	{
		//　出現させる敵をランダムに選ぶ
		var randomValue = Random.Range(0, enemys.Length);
		//　敵の向きをランダムに決定
		var randomRotationY = Random.value * 360f;
		float x = Random.Range(minX, maxX);
		float z = Random.Range(minZ, maxZ);

		GameObject.Instantiate(enemys[randomValue], new Vector3(x, 0, z), Quaternion.Euler(0f, randomRotationY, 0f));

		numberOfEnemys++;
		elapsedTime = 0f;
	}
}