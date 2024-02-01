using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberIncrement : MonoBehaviour
{
    private int collectedObjectNum = 0;
    private PlayerManager playerManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("incremented");
            Destroy(other.gameObject);
            collectedObjectNum++;
            print(collectedObjectNum);
            playerManager.AddHealt();

        }

    }
}
