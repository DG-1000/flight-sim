using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    /*[SerializeField]
    float maxHealth;
    [SerializeField]
    float health;

    [Header("Weapons")]
    [SerializeField]
    List<Transform> hardpoints;
    [SerializeField]
    Target target;
    [SerializeField]
    [Tooltip("Firing rate in Rounds Per Minute")]
    float cannonFireRate;
    [SerializeField]
    float cannonDebounceTime;
    [SerializeField]
    float cannonSpread;
    [SerializeField]
    Transform cannonSpawnPoint;
    [SerializeField]
    GameObject bulletPrefab;

    bool cannonFiring;
    float cannonDebounceTimer;
    float cannonFiringTimer;

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = Mathf.Max(0, value);
        }
    }

    public float Health
    {
        get
        {
            return health;
        }
        private set
        {
            health = Mathf.Clamp(value, 0, maxHealth);

            if (health <= MaxHealth * .5f && health > 0)
            {
                damageEffect.SetActive(true);
            }
            else
            {
                damageEffect.SetActive(false);
            }

            if (health == 0 && MaxHealth != 0 && !Dead)
            {
                Die();
            }
        }
    }

    public bool Dead { get; private set; }

    public Target Target
    {
        get
        {
            return target;
        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
    public void ApplyDamage(float damage)
    {
        Health -= damage;
    }

    void Die()
    {
        throttleInput = 0;
        Throttle = 0;
        Dead = true;
        cannonFiring = false;

        damageEffect.GetComponent<ParticleSystem>().Pause();
        deathEffect.SetActive(true);
    }

    void CalculateAngleOfAttack()
    {
        if (LocalVelocity.sqrMagnitude < 0.1f)
        {
            AngleOfAttack = 0;
            AngleOfAttackYaw = 0;
            return;
        }

        AngleOfAttack = Mathf.Atan2(-LocalVelocity.y, LocalVelocity.z);
        AngleOfAttackYaw = Mathf.Atan2(LocalVelocity.x, LocalVelocity.z);
    }

    void UpdateWeapons(float dt)
    {
        UpdateWeaponCooldown(dt);
        //UpdateMissileLock(dt);
        UpdateCannon(dt);
    }

    void UpdateWeaponCooldown(float dt)
    {
        missileDebounceTimer = Mathf.Max(0, missileDebounceTimer - dt);
        cannonDebounceTimer = Mathf.Max(0, cannonDebounceTimer - dt);
        cannonFiringTimer = Mathf.Max(0, cannonFiringTimer - dt);

        for (int i = 0; i < missileReloadTimers.Count; i++)
        {
            missileReloadTimers[i] = Mathf.Max(0, missileReloadTimers[i] - dt);

            if (missileReloadTimers[i] == 0)
            {
                animation.ShowMissileGraphic(i, true);
            }
        }
    }

    void UpdateCannon(float dt)
    {
        if (cannonFiring && cannonFiringTimer == 0)
        {
            cannonFiringTimer = 60f / cannonFireRate;

            var spread = Random.insideUnitCircle * cannonSpread;

            var bulletGO = Instantiate(bulletPrefab, cannonSpawnPoint.position, cannonSpawnPoint.rotation * Quaternion.Euler(spread.x, spread.y, 0));
            var bullet = bulletGO.GetComponent<Bullet>();
            bullet.Fire(this);
        }
    }*/

    // Update is called once per frame

    public float speed = 30;
    private float turnSpeed = 80;
    private float hIn;
    private float fwdIn;
    private float mDir;
    public Transform GameObject;
    public Text Display;
    void Update()
    {
        //UpdateWeapons(Time.deltaTime);
        hIn   = Input.GetAxis("Horizontal");
        fwdIn = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(0, speed - 20, speed);
        if (speed > 30 && fwdIn < 0 || speed < 80 && fwdIn > 0)
        {
            speed += fwdIn * Time.deltaTime * 20;
        }
        Display.text = ("Velocity: " + Mathf.Round(speed) + "m/s").ToString();
        //transform.Translate(movement * Time.deltaTime);*/
        transform.Translate(Vector3.right * Time.deltaTime * -speed);
        mDir = (Mathf.Rad2Deg * (Mathf.Atan((Input.mousePosition.x - (Screen.width / 2)) / Input.mousePosition.y)) % 360);

        //transform.Translate(Vector3.up * -10 * Time.deltaTime, Space.World);

        /*if (((gameObject.transform.rotation.z > 0.35 && gameObject.transform.rotation.z < 0.7) || (gameObject.transform.rotation.z < 0 && gameObject.transform.rotation.z > -0.35) || (gameObject.transform.rotation.z < -0.7)) && hIn == 0)
        {
            hIn = -1;
        }
        else if (hIn == 0 && gameObject.transform.rotation.z != 0)
        {
            hIn = 1;
        }
        else 
        {
            
        }

        if (gameObject.transform.rotation.x < 0  && fwdIn == 0)
        {
            fwdIn = -1;
        }
        else if (fwdIn == 0 && gameObject.transform.rotation.x != 0)
        {
            fwdIn = 1;
        }
        else
        {

        }/**/


        //Debug.Log(Mathf.Round(speed));
        //Debug.Log(gameObject.transform.rotation.z);

        //transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed * hIn  ); //roll
        //if 
        //transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed * hIn);
        //Debug.Log("(" + (Input.mousePosition.x - (Screen.height / 2)) + "," + (Input.mousePosition.y - (Screen.height / 2)) + ")");
        //Debug.Log((Mathf.Rad2Deg * (Mathf.Atan((Input.mousePosition.x - (Screen.width / 2)) / (Input.mousePosition.y - (Screen.height / 2)))) % 360) + " " + (GameObject.eulerAngles.z));
        //   -GameObject.eulerAngles.x- 
        /*
        if ( 45 < (Mathf.Rad2Deg * (Mathf.Atan((Input.mousePosition.x - (Screen.width / 2)) / Input.mousePosition.y)) % 360))
        {
            *//*
        }
        if (-45 > (Mathf.Rad2Deg * (Mathf.Atan((Input.mousePosition.x - (Screen.width / 2)) / Input.mousePosition.y)) % 360))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed * -1);
        }//*/
        //transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed * (mDir - GameObject.eulerAngles.z) / 180);
        //transform.Rotate(Vector3.back * Time.deltaTime * (Mathf.Round(gameObject.transform.rotation.z * 1) / 1 - gameObject.transform.rotation.z));
        //transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed * fwdIn); //lift
        //if ( 100 < (Mathf.Sqrt(Mathf.Pow(Input.mousePosition.x - (Screen.width / 2), 2) + Mathf.Pow(Input.mousePosition.y, 2))))
        //{
        if (speed > 25) {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed * mDir / 100); //rotation
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * (Input.mousePosition.y - 100) / Screen.height); //pitch
        }
        //}
        //transform.Rotate(Vector3.left * Time.deltaTime * (Mathf.Round(gameObject.transform.rotation.x * 1) / 1 - gameObject.transform.rotation.x));
    }
}
