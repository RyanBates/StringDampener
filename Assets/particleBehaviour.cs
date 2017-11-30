using UnityEngine;

public class ParticleBehaviour : MonoBehaviour {

    HooksLaw.Particle particle;
    HooksLaw.SpringDamper spring;
    
	// Use this for initialization
	void Start ()
    {
        particle = new HooksLaw.Particle();
        spring = new HooksLaw.SpringDamper();

        particle.AddForce(new Vector3(9.807f, 0, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = particle.Update(Time.deltaTime);
        
        foreach(HooksLaw.Particle part in spring.m_Particle)
        {
            spring.CalculateForce();
        }
    }
}
