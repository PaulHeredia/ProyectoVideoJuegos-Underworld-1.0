using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack_Sword : MonoBehaviour
{
    private BoxCollider2D Animation_Atack;
    // Start is called before the first frame update
    void Start()
    {
        Animation_Atack=GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro){
        if(otro.CompareTag("Troll")){
            Destroy(otro.gameObject);
        }
    }
}
