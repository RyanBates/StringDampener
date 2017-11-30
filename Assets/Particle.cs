using System.Collections.Generic;
using UnityEngine;


        
        
namespace HooksLaw
{
   

    public class Particle
    {
        public Vector3 force;
        public Vector3 position;
        public Vector3 acceleration;
        public Vector3 velocity;

        public float mass;

        public Particle()
        {
            position = Vector3.zero;
            acceleration = Vector3.zero;
            velocity = Vector3.zero;
            force = Vector3.zero;
            mass = 5;
        }

        public Particle(Vector3 p, Vector3 v, float m)
        {
            position = p;
            acceleration = Vector3.zero;
            velocity = v;
            force = Vector3.zero;
            mass = m;
        }

        public void AddForce(Vector3 f)
        {
           force = f;
        }
        
        // Update is called once per frame
        public Vector3 Update(float deltaTime)
        {
            acceleration = force / mass;
            velocity += acceleration * deltaTime;
            position += velocity * deltaTime;

            return position;
        }
    }

    public class SpringDamper
    {
        ParticleBehaviour pb;

        Particle _P1, _P2;
        float _Ks;
        float _Lo;
        float _Kd;

        public List<Particle> m_Particle;

        public SpringDamper()
        {

        }

        public SpringDamper(Particle p1, Particle p2, float springConstant, float dampingFactor, float restLength)
        {
            _P1 = p1;
            _P2 = p2;
            _Ks = springConstant;
            _Kd = dampingFactor;
            _Lo = restLength;
        }
        
        public void CalculateForce()
        {
            m_Particle.Add(_P1);
            m_Particle.Add(_P2);

            //Convert 3D to 1D
            Vector3 e = _P1.position - _P2.position;
            float l = Vector3.Magnitude(e);
            Vector3 E = e.normalized / l;

            //Calculating 1D Velocities
            Vector3 v1 = _P1.velocity;
            Vector3 v2 = _P2.velocity;

            float V1 = Vector3.Dot(E, v1);
            float V2 = Vector3.Dot(E, v2);

            //Convert 1D to 3D
            float Fsd = -_Ks * (_Lo - l) - _Kd * (V1 - V2);
            Vector3 F1 = Fsd * E;
            Vector3 F2 = -F1;

            m_Particle[0].AddForce(F1);
            m_Particle[1].AddForce(F2);
        }
    }
}