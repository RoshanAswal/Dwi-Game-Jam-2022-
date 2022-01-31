using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float upextent,downextent,speed;
    Vector3 posup,posdown,original;
    Vector3 tomove=Vector3.zero;
    private void Start() {
        posup=new Vector3(transform.position.x,transform.position.y+upextent,transform.position.z);
        posdown=new Vector3(transform.position.x,transform.position.y-downextent,transform.position.z);
        original=transform.position; 
    }
    private void Update() {
        string s=gameObject.tag;
        if(s=="UpperObstacle")moveAround(posdown);
        else if(s=="LowerObstacle") moveAround(posup);
        if(tomove!=Vector3.zero){
            transform.position=Vector3.MoveTowards(transform.position,tomove,speed*Time.deltaTime);  
        }

    }
    public void moveAround(Vector3 pos){
        if(transform.position==pos)
            tomove=original;
        else if(transform.position==original)
            tomove=pos;
    }
}
