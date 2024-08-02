using System.Collections;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    // Referencia al controlador de la luz
    public LightController lightController;

    // Valores de intensidad y color
    public float[] intensities;
    public Color[] colors;
    public float changeDuration = 2.0f;

    private int currentIntensityIndex = 0;
    private int currentColorIndex = 0;

    private void Start()
    {
        if (lightController == null)
        {
            Debug.LogError("Se debe asignar el LightController en el Inspector.");
            return;
        }

        // Inicia el ciclo de cambios
        
    }

    private void Update()
    {
        // on press L key run the coroutine to change the light
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(CycleLightChanges());
        }
    }

    private IEnumerator CycleLightChanges()
    {
        while (true)
        {
            // Cambiar la intensidad
            float targetIntensity = intensities[currentIntensityIndex];
            lightController.ChangeIntensity(targetIntensity, changeDuration);
            currentIntensityIndex = (currentIntensityIndex + 1) % intensities.Length;

            // Esperar a que se complete el cambio de intensidad
            yield return new WaitForSeconds(changeDuration);

            // Cambiar el color
            Color targetColor = colors[currentColorIndex];
            lightController.ChangeColor(targetColor, changeDuration);
            currentColorIndex = (currentColorIndex + 1) % colors.Length;

            // Esperar a que se complete el cambio de color
            yield return new WaitForSeconds(changeDuration);
        }
    }
}
