using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float degreesPerSecond = 20;

    public int dir =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ScaleTransform()
    {
        float valscale = 1.15f;
        transform.localScale = transform.localScale * valscale;
    }

    void MoveTransform()
    {
        Vector3 dir = new Vector3(0.05f,0,0);


        dir = dir * -1;
        transform.Translate(dir);

    }

    void RotateTransform()
    {
        switch (dir)
        {
            case 0:
                transform.Rotate(new Vector3(degreesPerSecond, 0, 0) * Time.deltaTime);
                break;
            case 1:
                transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
                break;
            case 2:
                transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        RotateTransform();
        MoveTransform();
        ScaleTransform();
    }
}
