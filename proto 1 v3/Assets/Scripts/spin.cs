using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    //public GameObject obj;
    //newBehaviorScript theScript = obj.GetComponent<newBehaviorScript>();
    //float planeSpeed = theScript.speed;
    //private NewBehaviourScript newBehaviourScript;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    private float spinSpeed = 1000;
    // Update is called once per frame
    void Update()
    {
        //spinSpeed = (200 * planeSpeed);
        transform.Rotate(Vector3.back * Time.deltaTime * spinSpeed);
    }
}
