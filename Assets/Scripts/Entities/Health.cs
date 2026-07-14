using UnityEngine;
namespace SpaceGame
{
 
 /// <summary>
/// Non MonoBehavior Class
///Encapsulation: Player will have instance of health and so will Enemies
///Methods like Start, Update, Awake OnCollisionEnter were part of MonoBehavior Class, a class that Unity created. They do not exist in general C#.
///non Monobehavior scripts cannot be added to Objects. So we can't use serialized variables becasue they can't be visualized in project
///Constructor--is a method that is the same spelling as the class.
/// </summary>
    


//This class is meant for creating a new object.
public class Health
{

    private float currentHealth;
    private float maxHealth;
    private float healthRegenRate;

    public Health(float _maxHealth, float _healthRegenRate, float _currentHealth = 100f) //Another form of encapsulation. _underscore variables only accessible through this method
    {
        currentHealth = _currentHealth;
        maxHealth = _maxHealth;
        healthRegenRate = _healthRegenRate;
    }

    public Health( float _maxHealth)
    {
        maxHealth = _maxHealth;
    }

    public Health()
    {
        
    }

    //Create methods to access variables
    public void AddHealth(float value)
    {
        currentHealth += value;
    }

    public void RemoveHealth (float value)
    {
        currentHealth -= value;
    }



}

}

