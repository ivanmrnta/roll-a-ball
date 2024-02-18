using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject jugador;
    //para diferenciar la posicion de la camara y la del jugador 
    private Vector3 offset;
    void Start()
    {
        //diferencia entre la posicion de camara y jugador 
        offset = transform.position - jugador.transform.position;
    }

    // Update is called once per frame

    //se ejecuta cada frame, pero depsués de haber procesado todo. Es más exacto para la camara. 
    void LateUpdate()
    {
        //actualizo la posicion de la camara 
        transform.position = jugador.transform.position + offset;
    }
}
