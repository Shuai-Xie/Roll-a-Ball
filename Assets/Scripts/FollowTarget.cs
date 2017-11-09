using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// camera script
public class FollowTarget : MonoBehaviour {

    public Transform playerTransform; // player的Transform 把Player从面板上拖过去

    private Vector3 offset; // 相机和小球最开始的偏移

	// Use this for initialization
	void Start () {

        // 计算初始的时候位置的偏移
        offset = transform.position - playerTransform.position; // main camera - player 向量差

	}
	
	// Update is called once per frame
	void Update () {
        // player current pos + offset = camera current pos
        transform.position = playerTransform.position + offset;
	}
}
