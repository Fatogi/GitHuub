﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Point : MonoBehaviour
{
    [SerializeField]
    private Bird bird;
    [SerializeField]
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Melakukan pengecekan burung mati atau tidak
        if (!bird.IsDead())
        {
            //menggerakan game object kesebelah kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }
    public void SetSize(float size)
    {
        //Mendapatkan komponent BoxCollider2D
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        //Pengecekan Null variable
        if (collider != null)
        {
            //mengubah ukuran collider sesuai dengan paramater
            collider.size = new Vector2(collider.size.x, size);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Mendapatkan komponen Bird
        Bird bird = collision.gameObject.GetComponent<Bird>();
        //Menambahkan score jika burung tidak null dan burung belum mati;
        if (bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }

}
