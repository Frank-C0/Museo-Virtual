using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Instancia estática de la clase
    private static GameManager _instance;

    // Propiedad para acceder a la instancia
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Buscar si hay una instancia en la escena
                _instance = FindObjectOfType<GameManager>();

                // Si no existe, crear uno nuevo
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia del singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject); // Mantener el objeto al cambiar de escena
        }
    }

    // Método para cambiar a una escena específica
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("Museo");
    }
}