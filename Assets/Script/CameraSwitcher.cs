using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    void Start()
    {
        // Desactiva todas las cámaras excepto la primera
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            currentCameraIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
            cameras[1].gameObject.SetActive(false);
            cameras[0].gameObject.SetActive(true);
    }
}
