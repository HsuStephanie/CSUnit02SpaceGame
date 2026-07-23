using UnityEngine;

namespace SpaceGame
{
    /// <summary>
    /// Pickups will derive from this abstract class
    /// </summary>
    public abstract class Pickup : MonoBehaviour
    {
        public virtual void OnPicked()
        {
            Destroy(gameObject);
        }
    }
}
