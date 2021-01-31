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

    public List<TMP_Text> mementoText;
    public Image textBox;

    public LayerMask soulsLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("click registered");
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);

            if (Physics.Raycast(ray, out hit,Mathf.Infinity, soulsLayer))
            {
                Debug.Log("casting ray");

                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                    hit.collider.gameObject.SetActive(false);
                    _soulsCollected++;
                    _countText.text = _soulsCollected.ToString();

                    StartCoroutine(FadeInText(_countText));
                    StartCoroutine(FadeInText(_maxSoulText));
                    StartCoroutine(FadeInImage(_soulIcon));

                }
                
            }
        }

        switch (_soulsCollected)
        {
            case 1:
                FirstMemento();
                break;
            case 2:
                SecondMemento();
                break;
            case 3:
                ThirdMemento();
                break;
            case 4:
                FourthMemento();
                break;
            case 5:
                FifthMemento();
                break;
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

    private void FirstMemento()
    {
        StartCoroutine(FadeInTextbox(textBox));
        FadeInMementoText(mementoText[_soulsCollected - 1]);
    }

    private void SecondMemento()
    {

    }

    private void ThirdMemento()
    {

    }

    private void FourthMemento()
    {

    }

    private void FifthMemento()
    {

    }

    private void SixthMemento()
    {

    }

    private void SeventhMemento()
    {

    }

    private IEnumerator FadeInTextbox(Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / 0.5f));
            yield return null;
        }
        yield return new WaitForSeconds(6);
        StartCoroutine(FadeOutTextbox(image));
    }

    private IEnumerator FadeOutTextbox(Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / 0.5f));
            yield return null;
        }
    }

    private IEnumerator FadeInMementoText(TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 0.5f));
            yield return null;
        }
        yield return new WaitForSeconds(6);
        StartCoroutine(FadeOutMementoText(text));

    }

    private IEnumerator FadeOutMementoText(TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 0.5f));
            yield return null;
        }
    }
}
