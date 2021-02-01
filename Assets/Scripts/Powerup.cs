using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<Scent>().Collectable();
            other.gameObject.GetComponent<DogController>().source.clip = other.gameObject.GetComponent<DogController>().powerup;
            other.gameObject.GetComponent<DogController>().source.Play();
            Destroy(gameObject);
        }
    }
}
