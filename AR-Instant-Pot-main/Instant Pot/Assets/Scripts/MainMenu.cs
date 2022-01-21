using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private IEnumerator coroutine;
    [SerializeField]
    GameObject panelBlack;

    public void Start()
    {
        Image panelImage = panelBlack.GetComponent<Image>();
        coroutine = FadeOut(panelImage);
        StartCoroutine(coroutine);
    }

    private IEnumerator FadeOut(Image panelImage)
    {
        yield return new WaitForSeconds(3f);

        float alpha = 0f;
        float timeToWait = .05f;

        while (alpha < (1 + timeToWait))
        {
            alpha += timeToWait;
            yield return new WaitForSeconds(timeToWait);

            Color newColor = new Color(0.0f, 0.0f, 0.0f, alpha);
            panelImage.color = newColor;
        }

        SceneManager.LoadScene("ARScene v1.9");

        StopCoroutine("FadeOut");
    }
}