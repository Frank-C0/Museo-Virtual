using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light pointLight;

    private void Start()
    {
        pointLight = GetComponent<Light>();
        if (pointLight.type != LightType.Point)
        {
            Debug.LogError("Este script debe estar adjunto a una luz puntual.");
        }
    }

    // Cambiar la intensidad de la luz progresivamente
    public void ChangeIntensity(float targetIntensity, float duration)
    {
        StartCoroutine(ChangeIntensityCoroutine(targetIntensity, duration));
    }

    private IEnumerator ChangeIntensityCoroutine(float targetIntensity, float duration)
    {
        float startIntensity = pointLight.intensity;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            pointLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        pointLight.intensity = targetIntensity;
    }

    // Girar la luz hacia una dirección específica
    public void RotateTowards(Transform targetTransform)
    {
        Vector3 direction = targetTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }

    // Cambiar el color de la luz progresivamente
    public void ChangeColor(Color targetColor, float duration)
    {
        StartCoroutine(ChangeColorCoroutine(targetColor, duration));
    }

    private IEnumerator ChangeColorCoroutine(Color targetColor, float duration)
    {
        Color startColor = pointLight.color;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            pointLight.color = Color.Lerp(startColor, targetColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        pointLight.color = targetColor;
    }

    // set intensity and color instantly
    public void SetLightSettings(Color color, float intensity)
    {
        pointLight.color = color;
        pointLight.intensity = intensity;
    }
}