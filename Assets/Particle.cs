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
        Particle _P1, _P2;
        float _Ks;
        float _Lo;

        public SpringDamper()
        {

        }

        public SpringDamper(Particle p1, Particle p2, float springConstant, float restLength)
        {
            _P1 = p1;
            _P2 = p2;
            _Ks = springConstant;
            _Lo = restLength;
        }

        public float Spring(float springConstant)
        {
            _Ks = springConstant;

            return _Ks;
        }

        public float Rest(float restLength)
        { 
            _Lo = restLength;

            return _Lo;
        }

        public Vector3 Span()
        {
            _P1.position = _P1.position / Spring(5);
            _P1.position.y = Rest(5);

            return _P1.position;           
        }
    }
}