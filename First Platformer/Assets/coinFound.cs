using UnityEngine;
using System.Collections;

public class CompletePlayerController : MonoBehaviour
{

  


    // Use this for initialization
    void Start()
    {
     
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this);
        }
    }
    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.

}