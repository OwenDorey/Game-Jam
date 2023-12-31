using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator fade;
    public float fadeTime = 1f;
    public void StartGame()
    {
        Cursor.visible = false;
        StartCoroutine(Load(2));
    }

    public void StartAnimation()
    {
        Cursor.visible = false;
        StartCoroutine(Load(1));
    }

    public void OpenMenu()
    {
        StartCoroutine(Load(0));
    }

    public void StartLevel(int levelIndex)
    {
        StartCoroutine(Load(levelIndex));
    }

    IEnumerator Load(int levelIndex)
    {
        fade.SetTrigger("Fade");

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(levelIndex);
    }
}
