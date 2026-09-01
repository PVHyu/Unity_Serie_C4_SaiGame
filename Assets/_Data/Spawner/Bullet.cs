using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : SaiMonoBehaviour
{
    [SerializeField] protected float speed = 10f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}