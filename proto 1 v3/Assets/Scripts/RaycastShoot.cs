using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .5f;
    public float weaponRange = 100f;
    public float hitForce = 100f;
    public Transform gunEnd;

    public Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.25f);
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
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange)) 
            {
                laserLine.SetPosition(1, hit.point);
                //laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
                Shootable health = hit.collider.GetComponent<Shootable>();
                if (health != null)
                {
                    health.Damage(gunDamage);
                }
            }
            else
            {
                laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
            }
            //Debug.DrawRay(rayOrigin, fpsCam.transform.forward * weaponRange, Color.green);
        }
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
