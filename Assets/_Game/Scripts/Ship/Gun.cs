using System;
using UnityEngine;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Laser _laserPrefab;

        private float _fireRate;

        private float _fireTimer;

        private void Start()
        {
            _fireRate = GameManager.ActiveManager.PlayerFireRate;
            _fireTimer = _fireRate;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && _fireTimer > _fireRate)
            {
                Shoot();
                _fireTimer = 0;
            }
            _fireTimer += Time.deltaTime;
        }
        
        private void Shoot()
        {
            var trans = transform;
            Instantiate(_laserPrefab, trans.position, trans.rotation);
        }
    }
}
