﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leserScrpit : MonoBehaviour
{
  
  public float speed = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up *speed *Time.deltaTime);
        if(transform.position.y > 6.3){
            Destroy(this.gameObject);
        }
    }
}
