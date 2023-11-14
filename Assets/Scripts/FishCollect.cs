using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollect : MonoBehaviour
{
    public GameObject fishModel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            fishModel.SetActive(false);
            Destroy(gameObject, 2f);
        }
    }
}
