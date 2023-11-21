using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public MenuController menuController;
    public int coins = 0;

    public void addCoin()
    {
        coins += 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && coins == 15)
        {
            Cursor.visible = true;
            menuController.StartLevel(4);
        }
    }
}
