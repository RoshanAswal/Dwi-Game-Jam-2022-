using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class istouching : MonoBehaviour
{
    public bool touching=false;
    public string triggerobj;
    private void OnTriggerEnter2D(Collider2D other) {
        touching=true;
        triggerobj=other.gameObject.tag;
    }
    private void OnTriggerExit2D(Collider2D other) {
        touching=false;
    }
}
