using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleBehaviour : MonoBehaviour {

    HooksLaw.Particle particle;
    HooksLaw.SpringDamper spring;

    public GameObject _particle;
    public GameObject anchor;

	// Use this for initialization
	void Start ()
    {
        anchor.transform.position = Vector3.zero;

        particle = new HooksLaw.Particle();
        spring = new HooksLaw.SpringDamper();
        particle.AddForce(new Vector3(0,-9.807f, 0));
        spring.Spring(10);
        spring.Rest(5);
    }
	
	// Update is called once per frame
	void Update ()
    {
        _particle.transform.position = particle.Update(Time.deltaTime);

        
	}
}
