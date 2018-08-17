using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOrAgainClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //点击came over
    public void OnClose()
    {
        Application.Quit();
    }

    //点击再来一局
    public void OnAgain()
    {
        //回到主场景
        SceneManager.LoadSceneAsync("main");
    }
}
