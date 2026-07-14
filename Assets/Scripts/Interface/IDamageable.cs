using UnityEngine;

namespace SpaceGame
{

    /// <summary>
    /// Interface Script
    ///Always starts with letter "I"!
    ///Interface vs Abstract object.
    /// Interfaces link unrelated objects if they have acommon method they need to call
    /// you can inherit multiple interfaces to a single object. WHere class can only inhert one class
    /// When you need to call a method on unrelated objects, but similar interfaces.
    /// Ex: car and bike may both use IRepairable, but they don't affect each other
    /// </summary>
    
    public interface IDamageable
    {
        void GetDamage(float damage);

    }
}


