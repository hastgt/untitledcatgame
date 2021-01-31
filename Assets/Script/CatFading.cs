using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatFading : MonoBehaviour
{
    private bool isFaded;
    private float _fading;
    public SpriteRenderer cat;

    // Update is called once per frame
    void LateUpdate()
    {
        _fading -= 0.0000099f;
        cat.color += new Color(0, 0, 0, _fading);
        if (cat.color.a <= 0 && !isFaded)
        {
            isFaded = true;
            Invoke("LoadNextScene", 20f);
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
