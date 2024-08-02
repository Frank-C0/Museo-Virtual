using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obj, PuntoA, PuntoB, PuntoC, PuntoD;
    public Text Texto;
    public Vector3 ChangePos, ChangeSca;


    public Vector3 PosA, PosB, PosC, PosD;


    public int Grado;

    public int chang = 0;

    public bool nocambiar;

    void ReiniciarPosicion()
    {
        PuntoA.transform.position = PosA;
        PuntoB.transform.position = PosB;
        PuntoC.transform.position = PosC;
        PuntoD.transform.position = PosD;
    }

    void Start()
    {

        ReiniciarPosicion();

        

        Texto.text = "Antes\n";
        Texto.text = Texto.text + "A (" + PuntoA.transform.position.x + ","+ PuntoA.transform.position.y + ")\n";
        Texto.text = Texto.text + "B (" + PuntoB.transform.position.x + "," + PuntoB.transform.position.y + ")\n";
        Texto.text = Texto.text + "C (" + PuntoC.transform.position.x + "," + PuntoC.transform.position.y + ")\n";
        Texto.text = Texto.text + "D (" + PuntoD.transform.position.x + "," + PuntoD.transform.position.y + ")\n";

        PuntoA.transform.position = PuntoA.transform.position + ChangePos;
        PuntoB.transform.position = PuntoB.transform.position + ChangePos;
        PuntoC.transform.position = PuntoC.transform.position + ChangePos;
        PuntoD.transform.position = PuntoD.transform.position + ChangePos;

        if (chang == 0)
        {

            Texto.text = Texto.text + "Despues\n";
            Texto.text = Texto.text + "A (" + PuntoA.transform.position.x + "," + PuntoA.transform.position.y + ")\n";
            Texto.text = Texto.text + "B (" + PuntoB.transform.position.x + "," + PuntoB.transform.position.y + ")\n";
            Texto.text = Texto.text + "C (" + PuntoC.transform.position.x + "," + PuntoC.transform.position.y + ")\n";
            Texto.text = Texto.text + "D (" + PuntoD.transform.position.x + "," + PuntoD.transform.position.y + ")\n";

            return;
        }

        if (!nocambiar)
        {
            ReiniciarPosicion();
        }
   

        PuntoA.transform.position = PuntoA.transform.position * ChangeSca.x;
        PuntoB.transform.position = PuntoB.transform.position * ChangeSca.x;
        PuntoC.transform.position = PuntoC.transform.position * ChangeSca.x;
        PuntoD.transform.position = PuntoD.transform.position * ChangeSca.x;


        if (chang == 1)
        {

            Texto.text = Texto.text + "Despues\n";
            Texto.text = Texto.text + "A (" + PuntoA.transform.position.x + "," + PuntoA.transform.position.y + ")\n";
            Texto.text = Texto.text + "B (" + PuntoB.transform.position.x + "," + PuntoB.transform.position.y + ")\n";
            Texto.text = Texto.text + "C (" + PuntoC.transform.position.x + "," + PuntoC.transform.position.y + ")\n";
            Texto.text = Texto.text + "D (" + PuntoD.transform.position.x + "," + PuntoD.transform.position.y + ")\n";

            return;
        }
        if (!nocambiar)
        {
            ReiniciarPosicion();
        }
 
        Obj.transform.Rotate(0, 0.0f, Grado, Space.World);

        if (chang == 2)
        {

            Texto.text = Texto.text + "Despues\n";
            Texto.text = Texto.text + "A (" + PuntoA.transform.position.x + "," + PuntoA.transform.position.y + ")\n";
            Texto.text = Texto.text + "B (" + PuntoB.transform.position.x + "," + PuntoB.transform.position.y + ")\n";
            Texto.text = Texto.text + "C (" + PuntoC.transform.position.x + "," + PuntoC.transform.position.y + ")\n";
            Texto.text = Texto.text + "D (" + PuntoD.transform.position.x + "," + PuntoD.transform.position.y + ")\n";

            return;
        }


        Texto.text = Texto.text + "Despues\n";
        Texto.text = Texto.text + "A (" + PuntoA.transform.position.x + "," + PuntoA.transform.position.y + ")\n";
        Texto.text = Texto.text + "B (" + PuntoB.transform.position.x + "," + PuntoB.transform.position.y + ")\n";
        Texto.text = Texto.text + "C (" + PuntoC.transform.position.x + "," + PuntoC.transform.position.y + ")\n";
        Texto.text = Texto.text + "D (" + PuntoD.transform.position.x + "," + PuntoD.transform.position.y + ")\n";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
