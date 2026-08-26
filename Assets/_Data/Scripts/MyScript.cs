using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

public class MyScript : MonoBehaviour
{
    void FixedUpdate()
    {
        this.TestClass();
        this.TestIsDead();
    }

    void TestIsDead()
    {
        // Zombie zombie = new Zombie();
        // zombie.SetHP(0);
        // string logMessage = zombie.GetName() + ": " + zombie.GetCurrentHP() + " " + zombie.IsDead();
        // Ghost ghost = new Ghost();
        // string Message = ghost.GetName() + ": " + ghost.GetCurrentHP() + " " + ghost.IsDead();
        // Debug.Log(Message);
        // Debug.Log(logMessage);
    }

    void TestClass()
    {
        Zombie zombie = new Zombie();
        Wolf wolf = new Wolf();
        Eagle eagle = new Eagle();
        Ghost ghost = new Ghost();

        zombie.Moving();
        wolf.Moving();
        eagle.Moving();
        ghost.Moving();
    }
}
