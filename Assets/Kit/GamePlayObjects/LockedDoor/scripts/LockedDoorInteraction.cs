using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LockedDoorInteraction : MonoBehaviour
{
    [SerializeField] InventoryItemDefinition keyDefinition;
    [SerializeField] int targetSceneIndex;
    public GameObject interactionText;
    [SerializeField] InputActionReference interactAction; // Acción E en Input System

    private bool isPlayerNearby = false;

    private void OnEnable()
    {
        interactAction.action.Enable();
        interactAction.action.performed += OnInteract;
    }

    private void OnDisable()
    {
        interactAction.action.performed -= OnInteract;
        interactAction.action.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            isPlayerNearby = true;
            interactionText.SetActive(true);
            interactionText.GetComponent<TextMeshProUGUI>().text = "Presione E";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactionText != null)
        {
            isPlayerNearby = false;
            interactionText.GetComponent<TextMeshProUGUI>().text = "";
            interactionText.SetActive(false);
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (!isPlayerNearby) return;

        if (InventoryUI.instance.Contains(keyDefinition))
        {
            InventoryUI.instance.Consume(keyDefinition);

            // Cambiar de escena si hay target
            if (targetSceneIndex >= 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneIndex);
            else
                Destroy(gameObject);
        }
        else
        {
            if (interactionText != null)
                interactionText.GetComponent<TextMeshProUGUI>().text = "Necesitas la llave";
        }
    }
}
