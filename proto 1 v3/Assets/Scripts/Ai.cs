using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //private float e = 0;
    //private float noE = 0;

    public float speed = 60;
    private float turnSpeed = 70;
    //private float hIn;
    //private float fwdIn;
    //private float mDir;
    public Transform GameObject;
    public Transform Player;
    public float pitchUpThreshold;
    //private float fineSteeringAngle = 0;
    private float rollFactor = 0.01f;
    private Vector3 lastInput = new Vector3(0, 0, 0);
    public Transform g1;
    public Transform g2;

    void Update()
    {
        var error = Player.transform.position - GameObject.transform.position;
        error = Quaternion.Inverse(GameObject.transform.rotation) * error;   //transform into local space

        Vector3 dir = -GameObject.transform.up;
        Vector3 rayOrigin = GameObject.transform.position + dir * 10;
        Debug.DrawRay(rayOrigin, dir * 1000f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, /*gunEnd.transform.forward*/dir, out hit, 1000f))
        {
            Shootable health = hit.collider.GetComponent<Shootable>();
            if (health != null)
            {
                health.Damage(1);
            }
        }
        else
        {
             
        }
        
        g1.GetComponent<Aishoot>().shootE();
        g2.GetComponent<Aishoot>().shootE();
            
        Vector3 targetInput = new Vector3();

        var pitchError = new Vector3(0, error.y, error.z).normalized;
        var pitch = Vector3.SignedAngle(Vector3.right, pitchError, Vector3.up);
        if (-pitch < pitchUpThreshold) pitch += 360f;
        {
            targetInput.x = pitch;
        }

        var rollError = new Vector3(error.x, error.y, 0).normalized;
        if (/*Vector3.Angle(Vector3.forward, errorDir) < fineSteeringAngle*/false)
        {
            //targetInput.y = error.x;
        }
        else
        {
            var roll = Vector3.SignedAngle(Vector3.up, rollError, Vector3.forward);
            targetInput.y = roll * -rollFactor;
        }

        targetInput.x = Mathf.Clamp(targetInput.x, -1, 1);
        targetInput.y = Mathf.Clamp(targetInput.y, -1, 1);
        targetInput.z = Mathf.Clamp(targetInput.z, -1, 1);
        var input = Vector3.MoveTowards(lastInput, targetInput, turnSpeed * Time.deltaTime);
        lastInput = input;
        //var input = new Vector3(0,0,0);

        Ray ray = new Ray(GameObject.transform.position + new Vector3(0, 0, 0), Quaternion.AngleAxis(10, -transform.up) * -GameObject.transform.up); 
        Debug.DrawRay(ray.origin, ray.direction * 75);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100) || 100 > Vector3.Distance(GameObject.transform.position, Player.transform.position))
        {
            //roll level and pull up
            var roll = GameObject.transform.rotation.eulerAngles.y;
            if (roll > 180f) roll -= 360f;
            input = new Vector3(-1, Mathf.Clamp(-roll * rollFactor, -1, 1), 0);
            //Debug.Log("Hit");
            lastInput = input;
        }
        else
        {
            //Debug.Log("Miss");
        }

        transform.Rotate(input);

        transform.Translate(Vector3.up * Time.deltaTime * -speed);
        
    }
}