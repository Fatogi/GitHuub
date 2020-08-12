﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void LoadScene(string name)
    {
        //Melakukan pengecekan jika name tidak null atau empty
        if (!string.IsNullOrEmpty(name))
        {
            //membuka scene dengan nama sesuai dengan variable name
            SceneManager.LoadScene(name);
        }
    }
}
