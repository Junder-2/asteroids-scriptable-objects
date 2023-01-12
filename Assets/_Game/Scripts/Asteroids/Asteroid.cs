using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private ScriptableEventInt _onAsteroidDestroyed;
        
        /*[Header("Config:")]
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minTorque;
        [SerializeField] private float _maxTorque;*/

        private AnimationCurve _force;
        private AnimationCurve _size;
        private AnimationCurve _torque;

        //[Header("References:")]
        //[SerializeField] private Transform _shape;
        private Transform _shape;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private int _instanceId;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _instanceId = GetInstanceID();
            _shape = transform.GetChild(0);

            _force = GameManager.ActiveManager.AsteroidForce;
            _size = GameManager.ActiveManager.AsteroidSize;
            _torque = GameManager.ActiveManager.AsteroidTorque;
            
            SetDirection();
            AddForce();
            AddTorque();
            SetSize();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Laser"))
            {
               HitByLaser();
            }
        }

        private void HitByLaser()
        {
            _onAsteroidDestroyed.Raise(_instanceId);
            Destroy(gameObject);
        }

        // TODO Can we move this to a single listener, something like an AsteroidDestroyer?
        public void OnHitByLaser(IntReference asteroidId)
        {
            if (_instanceId == asteroidId.GetValue())
            {
                Destroy(gameObject);
            }
        }
        
        public void OnHitByLaserInt(int asteroidId)
        {
            if (_instanceId == asteroidId)
            {
                Destroy(gameObject);
            }
        }
        
        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            //var force = Random.Range(_minForce, _maxForce);
            var force = _force.Evaluate(Random.Range(0, 1f));
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            //var torque = Random.Range(_minTorque, _maxTorque);
            var torque = _torque.Evaluate(Random.Range(0, 1f));
            var negate = Random.Range(0, 2);

            if (negate == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetSize()
        {
            //var size = Random.Range(_minSize, _maxSize);
            var size = _size.Evaluate(Random.Range(0, 1f));
            _shape.localScale = new Vector3(size, size, 0f);
        }
    }
}
