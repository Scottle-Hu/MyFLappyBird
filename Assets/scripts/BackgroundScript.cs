using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//地面背景的脚本
public class BackgroundScript : MonoBehaviour {

    //一个背景上有六个障碍物
    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject barrier4;
    public GameObject barrier5;
    public GameObject barrier6;

    //背景预制体，用于循环赋值
    public GameObject bg;

    //防止重复出发复制背景事件，记录当前背景是否已经被复制
    bool copied = false;

	// Use this for initialization
	void Start () {
        //随机初始化障碍物位置
        //上面的障碍物的y坐标在0.55~0.9，下面的障碍物的坐标在-0.55~-0.7
        RandomY(barrier1, 0.4f, 0.7f);
        RandomY(barrier3, 0.4f, 0.7f);
        RandomY(barrier5, 0.4f, 0.7f);
        RandomY(barrier2, -0.5f, -0.2f);
        RandomY(barrier4, -0.5f, -0.2f);
        RandomY(barrier6, -0.5f, -0.2f);
    }

    // Update is called once per frame
    void Update () {
		
	}

    //当小鸟进入一个背景时，复制一个到下下个
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(bg, new Vector3(this.transform.position.x + 20 * 2, 0, 0), Quaternion.identity);
    }

    //随即初始化障碍物的函数
    static void RandomY(GameObject barrier, float min, float max)
    {
        Vector3 v = barrier.transform.position;
        barrier.transform.position = new Vector3(v.x, 10 * Random.Range(min, max), v.z);
        //Debug.Log(barrier.transform.position.y);
    }
}
