using UnityEngine;
using System.Collections;

public class Shootable : MonoBehaviour
{
    //The object's current health point total
    public int currentHealth = 3;
    public AudioSource boomAudio;
    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;
        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            boomAudio.Play();
            //if health has fallen below zero, deactivate it 
            //gameObject.SetActive(false);

        }

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            transform.Rotate(6, 0, 2);
        }
    }

}
