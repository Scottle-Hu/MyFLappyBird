﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("start...");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartClick()
    {
        SceneManager.LoadSceneAsync("main");
    }
}