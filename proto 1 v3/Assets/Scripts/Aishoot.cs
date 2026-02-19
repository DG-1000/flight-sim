using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aishoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 1000f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public Transform self;
    public bool play = false;


    //public Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.125f);
    public AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        //fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootE()
    {
        Vector3 dir = -self.up; //new Vector3(0.0f, 1.0f, 0.0f);
        Vector3 rayOrigin = self.position;// new Vector3(0.5f, 0.0f, 0.0f);
        Debug.DrawRay(rayOrigin, dir * weaponRange, Color.blue);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(rayOrigin, /*gunEnd.transform.forward-*/dir, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                //laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
                Shootable health = hit.collider.GetComponent<Shootable>();
                if (health != null)
                {
                    //health.Damage(gunDamage);
                }
            }
            else
            {
                laserLine.SetPosition(1, gunEnd.transform.forward * weaponRange);
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        if (play)
        {
            gunAudio.Play();
        }
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
