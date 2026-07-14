using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace SpaceGame
{
    /// <summary>
    /// 
    /// Dictionary is like a list but with unique identifier
    /// Sometimes called a hash map
    /// each reference has a string value called a "key". Dictionary also = Key value pair
    /// If you have multiple types of currency or pick ups. (Ex: gems, currency, bullets)
    /// 
    /// Game example- Minecraft- blocks all have unique identifiers
    /// 
    /// </summary>
    public class DictionaryExample : MonoBehaviour
    {
        public Dictionary<string, int> myDictionary = new Dictionary<string, int>();//int could also be GameObject, player, anything
        public string checkKey = "Gems";
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
             //use TryAdd-- will make sure that everything is unique terms
            myDictionary.Add("Gems", 0); //all are set value to 0. When the player starts, the inventory will be 0
            myDictionary.Add("Coins", 0);
            myDictionary.Add("Bullets", 0);
            myDictionary.Add("BottleCaps", 0);
        }

        void AddGems() //will add 1 gem to the count
        {
            if (myDictionary.ContainsKey(checkKey)) //CcontainsKey is like a bool
            {
                myDictionary["Gems"] ++;
                //or myDictionary[checkKey] ++;
            }
        }
        void CheckKey()
        {
            bool hasKey = myDictionary.TryGetValue(checkKey, out int value);
            Debug.Log(checkKey + value);
        }
    }
}
