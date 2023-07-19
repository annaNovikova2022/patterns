using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name + " is destroyed." );
        Destroy(collision.gameObject);
    }
}
