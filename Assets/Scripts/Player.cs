using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 使用游戏UI

// player script
public class Player : MonoBehaviour {

    private Rigidbody rd;

    public int force = 5; // public型可以在面板里直接设置值

    private int score = 0;

    public Text scoreText; // 组件

    public GameObject winText; // 对象 跟随player移动

    public GameObject effect;

    public GameObject eatText; // 添加碰撞特效

	// Use this for initialization 初始化 只一次
	void Start () {
        rd = GetComponent<Rigidbody>(); // 赋值
	}
	
	// Update is called once per frame 持续调用的命令
	void Update () {
        
        // 通过键盘控制移动

        float h = Input.GetAxis("Horizontal"); // 得到水平轴的值 [-1,1] D正向, A负向

        float v = Input.GetAxis("Vertical"); // W S

        rd.AddForce(new Vector3(h, 0, v) * force); // 施加力 向量表示方向 控制运动方式 *force 快速更改方向

        // eatText.GetComponent<Text>().text = "bingo!!"; // 设置GameObject的文本
	}


    // 碰撞检测 会有实际的物理效果
    // 因为后面有了触发检测，这部分代码无效
    private void OnCollisionEnter(Collision collision)
    {
        //string name = collision.collider.name; // 获取碰撞到的游戏物体身上的collider组件，再获取名字
        //print(name); // 输出碰撞体的名字

        if (collision.collider.tag == "PickUp")
        {
            Destroy(collision.collider.gameObject); // 销毁碰撞到的食物
        }

    }


    // 触发检测 没有物理阻挡，可以检测到物体位置 Collider 勾选 Is Trigger
    // 触发检测和碰撞检测不会同时出现，勾选之后，就只有触发检测了

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            // 添加碰撞动画
            GameObject newEffect = (GameObject)Instantiate(effect, transform.position, effect.transform.rotation);
            Destroy(newEffect, 1.0f);

            eatText.SetActive(true);

            score++;
            scoreText.text = score.ToString();

            // 胜利提示 
            if (score >= 5)
            {
                eatText.SetActive(false);
                winText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        eatText.SetActive(false);
        Destroy(other.gameObject);
    }
}
