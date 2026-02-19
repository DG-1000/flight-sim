using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float hIn;
    private float fwdIn;
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -20);
    // Update is called once per frame
    void LateUpdate()
    {
        hIn = Input.GetAxis("Horizontal");
        fwdIn = Input.GetAxis("Vertical");
        //transform.position = player.transform.position + offset;  
        //transform.Rotate(Vector3.back * Time.deltaTime * 80 * hIn);
        //transform.Rotate(Vector3.left * Time.deltaTime * -40 * fwdIn);
    }
}
