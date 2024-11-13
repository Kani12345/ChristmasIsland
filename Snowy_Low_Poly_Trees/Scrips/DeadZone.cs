using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform respawnPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = respawnPoint.position;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
         }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
