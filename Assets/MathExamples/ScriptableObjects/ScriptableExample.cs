using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableExample", menuName = "Scriptable Objects/ScriptableExample")]
public class ScriptableExample : ScriptableObject
{
    public string exampleName;
    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public Rigidbody rb;
}
