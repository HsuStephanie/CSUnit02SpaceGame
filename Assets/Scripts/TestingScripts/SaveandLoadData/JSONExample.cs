using UnityEngine;

namespace SpaceGame
{
    public class JSONExample: MonoBehaviour
    {
        
        void Start()

        {
            SampleData sample = new SampleData();
            sample.name = "Bob";
            sample.score = 10.0f;

            string data = JsonUtility.ToJson(sample); //JsonUtility is built in. Take gameobject and deserialize them into Json file
            Debug.Log("Raw json: " + data);
            //Json is not human readable, but compressed and easier to store. Everything is added to 1 line
            
            //taking data out of the Json file
            string exampleJson = "{\n\t\"name\":\"Alice\", \n\t\"score\":90.34\n}"; //Json converted to json
            Debug.Log(exampleJson);

            //Deserialized to output into neat list
            SampleData data2 = JsonUtility.FromJson<SampleData>(data);
            Debug.Log($"Deserialized {data2.name} - Score: {data2.score}");
       }
    }
}
