using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour
{
    public float y=1f;
    float originalY;
    void Start()
    {
        originalY=transform.position.y;
    }

    void Update()
    {
        transform.position=new Vector3(transform.position.x,
                            originalY+((float)Mathf.Sin(Time.time)*y),
                            transform.position.z);
    }
}
