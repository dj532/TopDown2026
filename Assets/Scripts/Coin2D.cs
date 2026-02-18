using UnityEngine;

public class Coin2D : MonoBehaviour
{
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // En 2D usamos Collider2D y OnTriggerEnter2D
        if (collision.CompareTag("Player"))
        {
            if (collectSound != null)
            {
                // Reproduce el sonido en la posición de la cámara para que se escuche claro
                AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            }
            Destroy(gameObject);
        }
    }
}
