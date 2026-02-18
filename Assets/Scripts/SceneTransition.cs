using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 0.8f;
    public static SceneTransition instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        StartCoroutine(Fade(1));
    }

    // EL CAMBIO ESTÁ AQUÍ: El parámetro debe ser int
    public void ChangeScene(int sceneIndex)
    {
        StartCoroutine(FadeAndLoad(sceneIndex));
    }

    private IEnumerator FadeAndLoad(int sceneIndex)
    {
        // 1. Fade Out (Hacia negro)
        yield return StartCoroutine(Fade(1));

        // 2. Cargar escena por índice
        // SceneManager.LoadScene acepta tanto string como int, 
        // pero solo si le pasas el tipo correcto aquí.
        SceneManager.LoadScene(sceneIndex);

        yield return new WaitForSeconds(0.1f);

        // 3. Fade In (Hacia transparente)
        yield return StartCoroutine(Fade(0));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, Time.deltaTime / fadeDuration);
            yield return null;
        }
    }
}