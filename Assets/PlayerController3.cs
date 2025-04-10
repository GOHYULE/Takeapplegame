using UnityEngine;
using System.Collections;
public class PlayerController3 : MonoBehaviour {

	//实例化的对象.
	public GameObject effect;
	private Vector3 rawPosition;
	private Vector3 hatPosition;
	private float maxWidth;

	// Use this for initialization
	void Start () {

		//将屏幕的宽度转换成世界坐标.
		Vector3 screenPos = new Vector3(Screen.width,0,0);
		Vector3 moveWidth=Camera.main.ScreenToWorldPoint(screenPos);

		//计算帽子的宽度.
		float hatWidth=GetComponent<Renderer>().bounds.extents.x;

		//获得帽子的初始位置.
		hatPosition=transform.position;
		//计算帽子的移动宽度.
		maxWidth=moveWidth.x-hatWidth;
		
	}
	
	// Update is called once per physics timestep
	void Update () {

		//轉換滑鼠座標到世界座標
		rawPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//帽子x座標對應滑鼠x座標
		hatPosition= new Vector3(rawPosition.x,hatPosition.y,0);
        //設定帽子不要跑出螢幕
		hatPosition.x=Mathf.Clamp(hatPosition.x,-maxWidth,maxWidth);

		//帽子移動
		GetComponent<Rigidbody2D>().MovePosition(hatPosition);
	}

	//碰撞偵測
	void OnTriggerEnter2D(Collider2D col){

        //碰撞後產生粒子效果
		GameObject neweffect=(GameObject)Instantiate(effect,transform.position,effect.transform.rotation);
		neweffect.transform.parent=transform;

        //移除保齡球
		Destroy(col.gameObject);
        //移除粒子效果
		Destroy(neweffect,1.0f);

	}

}

