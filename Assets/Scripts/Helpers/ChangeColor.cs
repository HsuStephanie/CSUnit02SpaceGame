using System.Collections;
using UnityEngine;

namespace SpaceGame
{
    public class ChangeColor : MonoBehaviour
    {
        [SerializeField] private Color startColor;
        [SerializeField] private Color currentColor;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            startColor = GetComponentInChildren<SpriteRenderer>().color;

            StartCoroutine(ColorShift(0.5f));
            
        }

        IEnumerator ColorShift(float waitTime)
        {

            while (true)
            {
            
            currentColor = Color.red;
            yield return new WaitForSeconds(waitTime);
            GetComponentInChildren<SpriteRenderer>().color = currentColor;
            
            yield return new WaitForSeconds(waitTime);
            GetComponentInChildren<SpriteRenderer>().color =startColor;
            }
            

        }

       
    }
}
