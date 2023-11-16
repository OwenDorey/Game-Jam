using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnimation : MonoBehaviour
{
    public int videoLength = 33;

    public Animator fade;
    public float fadeTime = 1f;
    private void Start()
    {
        StartCoroutine(waitLength());
    }

    IEnumerator waitLength()
    {
        yield return new WaitForSeconds(videoLength);

        fade.SetTrigger("Fade");

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(2);
    }
}
