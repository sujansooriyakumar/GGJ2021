using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scent : MonoBehaviour
{
    GameObject[] goals;
    public GameObject goal;
    public GameObject player;
    float scentStrength;
    ParticleSystem particles;

    private void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("Buildings");
        int rand = Random.Range(0, goals.Length);
        goal = goals[rand];
        particles = GetComponent<ParticleSystem>();
        goal.tag = "Goal";
        foreach(Transform t in goal.transform)
        {
            t.gameObject.tag = "Goal";
        }
        scentStrength = 1.0f;
    }
    private void Update()
    {
        transform.position = player.transform.position;
        ParticleSystem.MainModule psMain = particles.main;
        ParticleSystem.ShapeModule psShape = particles.shape;
        Quaternion lookRotation = Quaternion.LookRotation(goal.transform.position - transform.position, Vector3.up);
        transform.rotation = lookRotation;

        if(particles.isPlaying == false)
        {
            psMain.duration = scentStrength;
        }
    }

    public void PlayParticles()
    {

        particles.Play();
    }

    public void Collectable()
    {
        ParticleSystem.MainModule psMain = particles.main;
        ParticleSystem.ShapeModule psShape = particles.shape;
        psShape.angle -= 15.0f;
        scentStrength++;
    }
}
