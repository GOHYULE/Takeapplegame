using UnityEngine;
using System.Collections;
public class SwanMove : MonoBehaviour {

    //天鵝移動速度
	public float moveSpeed=4;
    
	// Use this for initialization
	void Start () {

		//设置天鹅的初始位置.
		transform.position=new Vector3(22,3,0);
	}

	// Update is called once per frame
	void Update () {

		if(transform.position.x>-22){

			//天鹅往左飛
			transform.Translate(Vector3.right*-moveSpeed*Time.deltaTime);
		}
		else{
            //超過後回到右邊起始位子
			transform.position=new Vector3(22,3,0);
		}
	}
}
