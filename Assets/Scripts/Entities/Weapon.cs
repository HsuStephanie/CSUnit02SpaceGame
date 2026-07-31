using UnityEngine;

namespace SpaceGame
{
    //This is a constructor for name and damage of weapon to be loaded from.
    //CANNOT go directly on an object.
    public class Weapon
    {
        private string name;
        private float damage;
        private float bulletSpeed; //bullet has a speed, but the weapon should be controlling the speed


        public Weapon(string _name, float _damage, float _bulletSpeed)
        {
            name = _name;
            damage = _damage;
            bulletSpeed = _bulletSpeed;
        }


        public Weapon()
        {

        }

        public void Shoot(Bullet _bullet, Transform _shootPosition, string _targetTag)
        {

            
            Debug.Log("Shooting from gun");
            Bullet tempBullet = GameObject.Instantiate(_bullet, _shootPosition.position, _shootPosition.rotation);
            tempBullet.SetBullet(damage, _targetTag, bulletSpeed);
        }

        public float GetDamage()
        {
            return damage;
        }
    }

}
