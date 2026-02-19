using UnityEngine;

public class GameObjectOn : MonoBehaviour
{
    [SerializeField] GameObject door;
    private void OnTriggerEnter2D(Collider2D other)
    {
        door.SetActive(true);
    }
}
