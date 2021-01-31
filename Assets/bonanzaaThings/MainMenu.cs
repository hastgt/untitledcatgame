using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image leftCat;
    public Image rightCat;

    public GameObject buttonGroup;

    private void Start()
    {
        StartCoroutine(FadeInImage(rightCat));
        StartCoroutine(FadeInImage(leftCat));
        StartCoroutine(ButtonActivation());
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator FadeInImage(Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / 1f));
            yield return null;
        }
        PlayerFloat pFloat = image.transform.GetComponent<PlayerFloat>();
        pFloat.enabled = true;
    }

    private IEnumerator ButtonActivation()
    {
        yield return new WaitForSeconds(2);
        buttonGroup.SetActive(true);
    }
}
