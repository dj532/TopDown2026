using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyManager : MonoBehaviour
{
    [Header("Paneles de Interfaz")]
    [SerializeField] private GameObject panelLobby;
    [SerializeField] private GameObject panelInstrucciones;

    [Header("Configuración de Escena")]
    [SerializeField] private string nombreEscenaJuego;
    void Start()
    {
        MostrarLobby();
    }
    public void MostrarInstrucciones()
    {
        panelLobby.SetActive(false);
        panelInstrucciones.SetActive(true);
    }
    public void MostrarLobby()
    {
        panelInstrucciones.SetActive(false);
        panelLobby.SetActive(true);
    }
    public void IniciarJuego()
    {
        if (!string.IsNullOrEmpty(nombreEscenaJuego)) {SceneManager.LoadScene(nombreEscenaJuego);}
        else {Debug.LogWarning("No has asignado el nombre de la escena en el Inspector.");}
    }
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}