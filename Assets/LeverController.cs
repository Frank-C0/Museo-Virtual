using UnityEngine;

public class LeverController : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Transform RampObject;
    public float minRotation = 0f;
    public float maxRotation = 90f;
    public float rotationSpeed = 300f;
    public float activationPercentage = 0.5f; // Percentage to switch isOn state

    private float currentRotation;
    private Quaternion startRotation;
    private bool rotatingToMax = true;
    private bool isRotating = false;
    public bool isOn = false;
    private bool previousIsOn = false;

    [Header("Light Settings")]
     
    public LightController lightController;

    // initial intensity and color
    public Color initialColor = Color.white;
    public float initialIntensity = 0.0f;

    //final intensity and color
    public Color finalColor = Color.white;
    public float finalIntensity = 1.0f;

    public float changeDuration = 1.0f;

    void Start()
    {
        startRotation = RampObject.rotation;

        // Set initial rotation and light settings based on isOn state
        if (isOn)
        {
            currentRotation = maxRotation;
            lightController.SetLightSettings(finalColor, finalIntensity);
        }
        else
        {
            currentRotation = minRotation;
            lightController.SetLightSettings(initialColor, initialIntensity);
        }

        RampObject.rotation = startRotation * Quaternion.Euler(currentRotation, 0f, 0f);
        previousIsOn = isOn;
    }

    void Update()
    {
        if (isRotating)
        {
            AnimateRotation();
        }
    }

    public void ToggleRotation()
    {
        if (!isRotating)
        {
            isRotating = true;
            rotatingToMax = !rotatingToMax;
        }
    }

    void AnimateRotation()
    {
        if (rotatingToMax)
        {
            currentRotation = Mathf.MoveTowards(currentRotation, maxRotation, rotationSpeed * Time.deltaTime);
            if (currentRotation >= maxRotation)
            {
                isRotating = false;
            }
        }
        else
        {
            currentRotation = Mathf.MoveTowards(currentRotation, minRotation, rotationSpeed * Time.deltaTime);
            if (currentRotation <= minRotation)
            {
                isRotating = false;
            }
        }

        RampObject.rotation = startRotation * Quaternion.Euler(currentRotation, 0f, 0f);
        UpdateIsOn();
    }

    void UpdateIsOn()
    {
        float activationRotation = minRotation + (maxRotation - minRotation) * activationPercentage;
        if (rotatingToMax)
        {
            if (currentRotation >= activationRotation)
            {
                isOn = true;
            }
            else
            {
                isOn = false;
            }
        }
        else
        {
            if (currentRotation <= activationRotation)
            {
                isOn = false;
            }
            else
            {
                isOn = true;
            }
        }

        if (isOn != previousIsOn)
        {
            OnIsOnChanged();
            previousIsOn = isOn;
        }
    }

    void OnIsOnChanged()
    {
        // This function is called whenever isOn changes
        Debug.Log("isOn state changed to: " + isOn);

        // turn on/off light
        if(isOn)
        {
            lightController.ChangeColor(finalColor, changeDuration);
            lightController.ChangeIntensity(finalIntensity, changeDuration);
        }
        else
        {
            lightController.ChangeColor(initialColor, changeDuration);
            lightController.ChangeIntensity(initialIntensity, changeDuration);
        }
    }
}
