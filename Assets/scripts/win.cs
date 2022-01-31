using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class win : MonoBehaviour
{
    public GameObject panel;
    int t=0;
    private void Update() {
        if(t==2){
            panel.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="circle"){
            if(t==0)t=1;
        }
        if(other.gameObject.tag=="square"){
            if(t==1)t=2;
        }
    }
}
