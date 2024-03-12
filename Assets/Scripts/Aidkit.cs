using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    private float healAmout = 50;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if(playerHealth !=null)
        {
            playerHealth.AddHealth(healAmout);
            Destroy(gameObject);
        }
    }
}
