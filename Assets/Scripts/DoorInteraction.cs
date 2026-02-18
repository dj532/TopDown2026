using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    [Header("Configuración de Escena")]
    // Definimos explícitamente como int
    public int targetSceneIndex;

    [Header("UI de Interacción")]
    public GameObject interactionText;

    private bool isPlayerNearby = false;

    void Update()
    {
        // Verificamos la entrada del jugador
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ExecuteChange();
        }
    }

    private void ExecuteChange()
    {
        // 1. Verificación de seguridad para evitar que el índice esté fuera de rango
        if (targetSceneIndex >= 0 && targetSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // 2. Llamada al Singleton pasando el ENTERO
            if (SceneTransition.instance != null)
            {
                // Aquí es donde ocurría el error. Nos aseguramos de pasar 'targetSceneIndex' (int)
                SceneTransition.instance.ChangeScene(targetSceneIndex);
            }
            else
            {
                Debug.LogWarning("No se encontró el objeto SceneTransition en la escena. Cargando directamente...");
                SceneManager.LoadScene(targetSceneIndex);
            }
        }
        else
        {
            Debug.LogError($"El índice {targetSceneIndex} no es válido. Revisa tus Build Settings.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionText != null) interactionText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionText != null) interactionText.SetActive(false);
        }
    }
}