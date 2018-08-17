using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

//flappy bird 小鸟控制
public class BirdScript : MonoBehaviour {

    public float velocity = 0.1f;

    //摄像机
    public Camera camera;

    //分数UI
    public Text text;

    //摄像机与小鸟的初始相对位置
    private Vector3 distance;

    //一秒钟运行十帧
    private int frameNum = 10;

    private float timeCount;

    //记录小鸟贴图的位置，控制纹理动画
    private int birdCount;

    //小鸟刚体
    private Rigidbody rigidBody;

    //小鸟是否已经GG
    private bool failed;

    //通过障碍物个数
    private int score = 0;

	
	void Start () {
        //初始化纹理偏移
        birdCount = 0;
        //记录时间帧
        timeCount = 0;
        //初始化刚体
        rigidBody = this.GetComponent<Rigidbody>();
        //小鸟初速度
        rigidBody.velocity = new Vector3(velocity, 0, 0);  //x方向初速度
        //计算摄像机和小鸟的x轴和z轴方向相对位置
        Vector3 cameraPos = camera.transform.position, birdPos = this.transform.position;
        distance = cameraPos - birdPos;
    }
	
	
	void Update () {
        //让小鸟始终保持在游戏平面内
        Vector3 birdPos = this.transform.position;
        this.transform.position = new Vector3(birdPos.x, birdPos.y, 0);
        //小鸟已死，不接受任何操作
        if (failed)
        {
            return;
        }
        if (timeCount > 1.0/frameNum)  //2d游戏一秒10次就可以了
        {
            //小鸟每帧扇动翅膀的动画
            birdCount = (birdCount + 1) % 2;
            //Debug.Log(birdCount);
            this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(birdCount * 0.3333f, 0));
            timeCount = 0;
        }
        timeCount += Time.deltaTime;
        //Debug.Log(timeCount);
        //控制小鸟向上
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //按下鼠标左键或者键盘空格键
        {
            //Debug.Log("press");
            //给小鸟一个向上的速度
            rigidBody.velocity = new Vector3(velocity, 3, 0);
        }
        //手机屏幕点击事件
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            //给小鸟一个向上的速度
            rigidBody.velocity = new Vector3(velocity, 4, 0);
        }
        //摄像机与小鸟保持同步
        camera.transform.position = new Vector3(this.transform.position.x + distance.x, 
            camera.transform.position.y, this.transform.position.z + distance.z);

    }

    //小鸟撞到柱子或者掉到地面
    private void OnCollisionEnter(Collision collision)
    {
        if (failed)
        {
            return;
        }
        string tag = collision.collider.tag;
        if (tag == "Finish")
        {
            Debug.Log(collision.collider.name);
            failed = true;
            //变成死鸟
            this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.6666f, 0));
            //速度变成0
            rigidBody.velocity = new Vector3(0, 0, 0);
            //TODO 播放失败音效，显示游戏结束

            //退出当前场景，回到结束场景
            Thread.Sleep(2000);
            SceneManager.LoadScene("end");
        }
    }

    //小鸟穿过障碍物
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pass")
        {
            score++;
            text.text = "通过障碍物：" + score;
            //TODO 播放通过障碍物的音效
        }
    }


}
