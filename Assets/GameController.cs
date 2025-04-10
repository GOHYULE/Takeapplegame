using UnityEngine;
using System.Collections;
public class GameController : MonoBehaviour {

    //生成物
	public GameObject ball;
    //生成保齡球的左右最大範圍
	private float maxWidth;
    //生成時間
	private float time=2;
    //每次的生成物
	private GameObject newball;	

    // Use this for initialization
	void Start () {

		//遊戲螢幕寬度轉成世界座標
		Vector3 screenPos = new Vector3(Screen.width,0,0);
		Vector3 moveWidth=Camera.main.ScreenToWorldPoint(screenPos);

		//保齡球的寬度
		float ballWidth=ball.GetComponent<Renderer>().bounds.extents.x;

		//扣掉保齡球寬度(生成物的座標範圍)
		maxWidth=moveWidth.x-ballWidth;
	}

    void Update(){

        //計時器
		time-=Time.deltaTime;

		if(time<0)
		{
			//隨機數字，1.5秒至2.0秒之間
			time=Random.Range(1.5f,2.0f);

			//隨機x座標位置，在此處產生新保齡球
			float posX = Random.Range(-maxWidth,maxWidth);
			Vector3 spawnPosition=new Vector3(posX,transform.position.y,0);

			//生成保龄球，10秒後銷毀
			newball=(GameObject)Instantiate(ball,spawnPosition,Quaternion.identity);
			Destroy(newball,10);
		}
	}
}

