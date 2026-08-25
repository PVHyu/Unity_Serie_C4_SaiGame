using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyScript : MonoBehaviour
{
    void FixedUpdate()
    {
        this.TestClass();
    }

    void TestClass()
    {
        Enemy zombie = new Enemy();
        Enemy wolf = new Enemy();
        Enemy eagle = new Enemy();
        Enemy ghost = new Enemy();

        zombie.Moving();
        wolf.Moving();
        eagle.Moving();
        ghost.Moving();
    }
}
