# Roll a Ball

- [Unity Roll-a-ball tutorial 官网教程](https://unity3d.com/cn/learn/tutorials/s/roll-ball-tutorial)
- [Roll a Ball - Shuai-Xie - Github](https://github.com/Shuai-Xie/roll-a-ball)

## 一、实验要求
1. 构建一个小球滚动的游戏场景；
2. 创建一个小球，按键盘上的上下左右键，小球会朝相应的方向移动，小球移动的时候相机也要相应移动；
3. 在场景中创建多个立方体，每个立方体都在旋转；小球与立方体发生碰撞的时候，立方体消失，计分板上得分加“1”；
4. 当得分达到“5”分时，在屏幕上显示“XXX同学，你赢了！”。

**加分项目：**
1. 添加小球和立方体发生碰撞的特效，添加立方体随机生成，添加小球撞击阻碍物的物理效果。
2. 你能想到的可以实现的其他效果。


![游戏场景](http://upload-images.jianshu.io/upload_images/1877813-0139b29ec371818b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)


## 二、小球设置 Player & 碰撞特效

#### 2.1 上下左右移动
**Player.cs** 设置前后左右移动，以及 force 调节力大小。
```cpp
// Update is called once per frame 持续调用的命令
void Update () {
    
    // 通过键盘控制移动

    float h = Input.GetAxis("Horizontal"); // 得到水平轴的值 [-1,1] D正向, A负向

    float v = Input.GetAxis("Vertical"); // W S

    rd.AddForce(new Vector3(h, 0, v) * force); // 施加力 向量表示方向 控制运动方式 *force 快速更改方向

    // eatText.GetComponent<Text>().text = "bingo!!"; // 设置GameObject的文本
}
```

#### 2.2 小球移动，摄像机跟随

![FollowTarget.cs](http://upload-images.jianshu.io/upload_images/1877813-38f1182bb5738316.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

**FollowTarget.cs** 让 Main Camera 跟随小球 Player 移动

```cpp
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
```
#### 2.3 用prefab创建多个旋转的立方体
![PickUps](http://upload-images.jianshu.io/upload_images/1877813-36fb286e6e06da18.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

**PickUp.cs** 让每个立方体旋转
```cpp
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
```
#### 2.4 触发检测 添加 碰撞特效
###### 2.4.1 坦克大战爆炸特效
![TankExplosion effect](http://upload-images.jianshu.io/upload_images/1877813-6e14aeb067991fd4.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

**Player.cs** 在 OnTriggerEnter 中添加特效

![爆炸特效](http://upload-images.jianshu.io/upload_images/1877813-d92c22d4a614fac5.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

###### 2.4.2 eat 文字弹出动画
![EatText](http://upload-images.jianshu.io/upload_images/1877813-6c1589ab0cc65b15.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)


![eat 放缩动画](http://upload-images.jianshu.io/upload_images/1877813-f0518ab1ff6631f7.gif?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

**Player.cs** 控制 eat 动画在进入触发器是出现，离开触发器时消失。

![eat 弹出特效](http://upload-images.jianshu.io/upload_images/1877813-4a6c044fe8e248f7.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
