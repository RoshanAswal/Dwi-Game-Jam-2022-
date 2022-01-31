using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject expo;
    public List<GameObject> arr;
    [SerializeField]
    GameManager gm;
    float shakeDuration=0f;
    public GameObject cam;
    Vector3 pos;
    private void Start() {
        pos=cam.transform.position;
    }
    private void Update() {
        if (shakeDuration > 0)
		{
			cam.transform.localPosition = pos + Random.insideUnitSphere * 0.3f;
			
			shakeDuration -= Time.deltaTime * 1f;
		}
		else
		{
			shakeDuration = 0f;
			cam.transform.localPosition =pos;
		}
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="safeBomb"){
            foreach (GameObject obj in arr)
            {
                Destroy(obj);                
            }
        }else if(other.gameObject.tag=="bomb"){
            foreach (GameObject obj in arr)
            {
                Destroy(Instantiate(expo,obj.transform.position,obj.transform.rotation),0.2f);                
                Destroy(obj);
            }
            shakeDuration=1f;
            Vector3 mv=new Vector3(transform.position.x-500,transform.position.y,0);
            transform.position=Vector3.MoveTowards(transform.position,mv,200f*Time.deltaTime); 
            Invoke("End",1f);
        }
    }
    void End(){
        gm.GameOver();
    }
}
