using UnityEngine;

namespace SpaceGame
{
    //This is a constructor for name and damage of weapon to be loaded from.
    //CANNOT go directly on an object.
    public class Weapon
{
    private string name;
    private float damage;


    public Weapon (string _name, float _damage)
        {
            name = _name;
            damage = _damage;
        }


    public Weapon()
        {
            
        }

    public void Shoot()
        {
           
            
                 Debug.Log("Shooting from gun");
            
        }
}

}
