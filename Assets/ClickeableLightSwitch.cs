using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickeableLightSwitch : MonoBehaviour, IClickable
{
    LeverController leverController;

    void Start()
    {
        leverController = GetComponent<LeverController>();
    }


    public void OnClick()
    {
        leverController.ToggleRotation();
    }
}