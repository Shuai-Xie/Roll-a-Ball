using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// pickup script
public class PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { // 调用 60次/s   1°/s
        transform.Rotate(new Vector3(0, 1, 0)); // 绕着y轴旋转
	}
}
