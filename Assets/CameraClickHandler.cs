using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClickHandler : MonoBehaviour
{
    Camera mainCamera;
    RaycastHit hitInfo;


    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Comprobar clic izquierdo del ratón
        {
            Debug.Log("Click");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("Hit " + hitInfo.collider.gameObject.name);

                GameObject hitObject = hitInfo.collider.gameObject;
                IClickable clickable = hitObject.GetComponent<IClickable>();

                if (clickable != null)
                {
                    clickable.OnClick();
                }
            }
        }
    }

    // Este método dibuja un gizmo en el editor para visualizar el rayo
    void OnDrawGizmos()
    {
        if (hitInfo.collider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(mainCamera.transform.position, hitInfo.point);
            Gizmos.DrawWireSphere(hitInfo.point, 0.1f);
        }
    }
}