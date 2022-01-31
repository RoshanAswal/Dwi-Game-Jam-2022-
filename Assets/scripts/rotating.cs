using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour
{
    public float speed=50f;
    public GameObject anchor;
    private void Update() {
        if(this.gameObject.tag=="log"){
            Vector3 v=new Vector3(0,0,1);            
            transform.RotateAround(anchor.transform.position,v,speed*Time.deltaTime);
        }else{
            Vector3 v=new Vector3(transform.position.x,transform.position.y,1);
            transform.RotateAround(transform.position,v,speed*Time.deltaTime);
        }
    }
}
