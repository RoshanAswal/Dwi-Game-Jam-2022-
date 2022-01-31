using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Text upText,downText;
    [SerializeField]
    moving mv;
    int upper=3,lower=7;
    public GameObject upplus,upminus,downplus,downminus,lockW1,lockW2;

    void Update()
    {
        if((lower==9 && upper==6) || (lower==6 && upper==9)){
            upText.color=Color.green;
            downText.color=Color.green;
            Vector3 nv=new Vector3(lockW1.transform.position.x,lockW1.transform.position.y+20,0);
            lockW1.GetComponent<moving>().moveAround(nv);
            Vector3 nv1=new Vector3(lockW2.transform.position.x,lockW2.transform.position.y-20,0);
            lockW2.GetComponent<moving>().moveAround(nv1);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        GameObject temp=other.gameObject;
        if(temp==upplus){
            upper+=1;
            upText.text=upper.ToString("0");
        }else if(temp==downplus){
            lower+=1;
            downText.text=lower.ToString("0");
        }else if(temp==upminus){
            upper-=1;
            upText.text=upper.ToString("0");
        }else if(temp==downminus){
            lower-=1;
            downText.text=lower.ToString("0");
        }
    }
}
