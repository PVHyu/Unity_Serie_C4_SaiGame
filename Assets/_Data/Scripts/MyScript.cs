using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyScript : MonoBehaviour
{
    void FixedUpdate()
    {
        this.TestClass();
        this.TestOperator();
    }

    void TestOperator()
    {
        
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
