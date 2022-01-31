using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    public List<GameObject> upperholes,lowerholes;
    public GameObject shpos1,shpos2,shpos3,shpos4,another,tobe1,tobe2;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="hole"){
            if(upperholes.Contains(other.gameObject)){
                int sucess=1;
                foreach (GameObject obj in upperholes)
                {
                    if(obj.GetComponent<istouching>().touching==false && obj!=other.gameObject){
                        transform.position=tobe1.transform.position;
                        sucess=0;
                        break;
                    }
                }
                if(sucess==1){
                    transform.position=shpos4.transform.position;
                    another.transform.position=shpos3.transform.position;
                }
            }else{
                int sucess=1;
                foreach (GameObject obj in lowerholes)
                {
                    if(obj.GetComponent<istouching>().touching==false && obj!=other.gameObject){
                        transform.position=tobe2.transform.position;
                        sucess=0;
                        break;
                    }
                }
                if(sucess==1){
                    transform.position=shpos1.transform.position;
                    another.transform.position=shpos2.transform.position;
                }                
            }
        }
    }
}
