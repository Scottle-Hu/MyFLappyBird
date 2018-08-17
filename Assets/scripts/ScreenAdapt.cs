using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdapt : MonoBehaviour {

    public Camera camera;

    public GameObject bird;


	// Use this for initialization
	void Start () {
        //Debug.Log(Screen.width + "*" + Screen.height);
        //camera.aspect = Screen.width / Screen.height;
        //camera.transform.position = new Vector3(bird.transform.position.x + 6, 0, -20f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
