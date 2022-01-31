using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wlcm : MonoBehaviour
{
    [SerializeField]
    GameManager gm;
    // Update is called once per frame
    void Update()
    {
        // if(Input.touchCount>0){
        //     gm.LevelChange();
        // }
        if(Input.GetKey("space")){
            gm.LevelChange();
        }
    }
}
