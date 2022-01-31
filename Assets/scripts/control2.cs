using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control2 : MonoBehaviour
{
    [SerializeField]
    GameManager gm;

    Rigidbody2D rb;
    float sf=1;
    int mod=7;
    public float speed=120f;
    Vector3 screenBounds;
    private void Start() {
        rb=GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        InputManager();
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // Vector3 pos=transform.position;
        // pos.x = Mathf.Clamp(pos.x, -screenBounds.x + transform.localScale.x, screenBounds.x - transform.localScale.x);
        // pos.y = Mathf.Clamp(pos.y, -screenBounds.y + transform.localScale.y, screenBounds.y - transform.localScale.y);
        // transform.position=pos;
        if(sf!=0 && (int)sf%mod==0){
            float temp1=transform.localScale.x-0.0002f;
            float temp2=transform.localScale.y-0.0002f;
            transform.localScale=new Vector3(temp1,temp2,0);
            if(temp1<0.01f || temp2<0.01f){
                Vector3 mv=new Vector3(transform.position.x-50,transform.position.y,0);
                transform.position=Vector3.MoveTowards(transform.position,mv,20f*Time.deltaTime); 
                gm.GameOver();
            }
        }
        sf+=1f*Time.deltaTime;        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="end"){
            gm.LevelChange();
        }        
        if(other.gameObject.tag=="regain"){
            Regain();
            Destroy(other.gameObject);
        }
    }

    private void Regain()
    {
        FindObjectOfType<AudioManager>().Play("coin");
        float temp1=transform.localScale.x+0.01f;
        float temp2=transform.localScale.y+0.01f;
        transform.localScale=new Vector3(temp1,temp2,0);
    }

    private void InputManager()
    {
        Vector2 newV=new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position+(newV*Time.fixedDeltaTime*speed));
        // if(Input.touchCount>0){
        //     Touch touch=Input.GetTouch(0);
        //     if(touch.phase==TouchPhase.Moved){
        //         rb.MovePosition(rb.position+(touch.deltaPosition*Time.fixedDeltaTime*speed));

        //     }
        // }
    }
}
