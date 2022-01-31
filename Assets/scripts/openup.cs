using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openup : MonoBehaviour
{
    public GameObject obj1,obj2,obj3,obj4;
    public GameObject l1,l2;
    moving mn;
    int success=0;
    Color lcol1,lcol2;
    float c=0;
    private void Start() {
        lcol1=l1.GetComponent<SpriteRenderer>().color;
        lcol2=l2.GetComponent<SpriteRenderer>().color;
    }
    private void Update() {
        check(obj1,obj2);
        check(obj3,obj4);
        if(success==1){
            l1.GetComponent<SpriteRenderer>().color=new Color(lcol1.r,lcol1.g,lcol1.b,lcol1.a-c);
            l2.GetComponent<SpriteRenderer>().color=new Color(lcol2.r,lcol2.g,lcol2.b,lcol2.a-c);
            if(c>100){
                l1.GetComponent<PolygonCollider2D>().isTrigger=true;
                l2.GetComponent<PolygonCollider2D>().isTrigger=true;
            }
            c+=50*Time.deltaTime;
        }
    }
    private void check(GameObject ob1, GameObject ob2)
    {
        if(success==0){
            if(ob1.GetComponent<istouching>().touching==true){
                if(ob2.GetComponent<istouching>().touching==true){
                    string s1=ob1.GetComponent<istouching>().triggerobj;
                    string s2=ob2.GetComponent<istouching>().triggerobj;
                    if(s1=="square" && s2=="circle")success=1;
                }
            }
        }

    }
}
