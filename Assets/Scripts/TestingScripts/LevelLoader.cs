using UnityEngine;
namespace SpaceGame
{
    //LevelLoader will load assets from scripts like Weapon and Player. Use this to load all nonMonobehaviors
    public class LevelLoader : MonoBehaviour
    {


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Player player = new Player();
            Enemy enemy1 = new Enemy();
            Enemy enemy2 = new Enemy();
            
            Weapon weapon1 = new Weapon();
            Weapon weapon2 = new Weapon("Assault", 4f);

            player.health.AddHealth(4f); //because player is created above, we can access IT'S health and AddHealth() method
            
            
            EnemyType enemyType1 = new EnemyType();

            enemyType1 = EnemyType.Melee;

            enemy1.SetEnemyType(enemyType1);
            player.weapon = weapon1;


        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
