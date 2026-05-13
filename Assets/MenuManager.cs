using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Salir()
    {
        Application.Quit();
    }
}