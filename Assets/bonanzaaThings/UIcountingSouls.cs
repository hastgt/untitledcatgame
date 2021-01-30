using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIcountingSouls : MonoBehaviour
{
    Vector2 mousePos;
    public Camera cam;

    public int _soulsCollected = 0;

    public TMP_Text _maxSoulText;
    public TMP_Text _countText;
    public Image _soulIcon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                hit.collider.gameObject.SetActive(false);
                _soulsCollected++;
                _countText.text = _soulsCollected.ToString();

                StartCoroutine(FadeInText(_countText));
                StartCoroutine(FadeInText(_maxSoulText));
                StartCoroutine(FadeInImage(_soulIcon));
                
            }
        }
    }

    private IEnumerator FadeInText(TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 0.5f));
            yield return null;
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeOutText(text));
        
    }

    private IEnumerator FadeOutText(TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 0.5f));
            yield return null;
        }
    }

    private IEnumerator FadeInImage(Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / 0.5f));
            yield return null;
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeOutImage(image));
    }

    private IEnumerator FadeOutImage(Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / 0.5f));
            yield return null;
        }
    }
}
