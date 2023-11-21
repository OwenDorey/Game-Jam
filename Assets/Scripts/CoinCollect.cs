using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public GameObject coinModel;
    public TMP_Text coinCounter;
    [SerializeField] private int coinAmount;

    public EndGame endGame;

    private void Start()
    {
        coinCounter = GameObject.Find("CoinCounter").GetComponent<TMP_Text>();
        endGame = GameObject.Find("FinalDogObject").GetComponent<EndGame>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            coinAmount = endGame.coins + 1;
            coinCounter.text = coinAmount.ToString() + " / 15";

            endGame.addCoin();

            coinModel.SetActive(false);
            Destroy(gameObject, 2f);
        }
    }
}
