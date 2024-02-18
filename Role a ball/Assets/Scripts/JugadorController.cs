using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    // se declara la variable tipo RidigBody que luego accionará al jugador
    private Rigidbody rb;
    public float velocidad;
    private int contador; 
    // private AudioSource audioSource;

    public Text textoContador, textoGanar, contadorUp;
    public float Timer;

    void Start()
    {
        //captura esa variable al iniciar el juego 
        rb = GetComponent<Rigidbody>();
        // audioSource = GetComponent<AudioSource>();
        contador = 0; 

        setTextoContador();
        textoGanar.text= "";
        
    }

    // Update is called once per frame
    //para que se sincronice con los frames de la fisica del motor, se utiliza FixedUpdate
    void FixedUpdate()
    {
        //estas variables capturan el movimiento en vertical y horizontal 
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Un Vector3 es un trio de posiciones en el espacio XYZ, en este caso el que compone el movimiento 
        Vector3 movimiento = new Vector3 (movimientoH, 0.0f, movimientoV);

        //se asigna el movimiento al RidigBody 
        rb.AddForce(movimiento * velocidad);
    }
    
    //se ejecuta al entrar a un objeto con la opcion is trigger seleccionada 
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Coleccionable")){
            other.gameObject.SetActive(false);


            // incremento del contador 
            contador+=1; 
            setTextoContador();
           
            // GameObject.Find("Sound Management").GetComponent<AudioSource>().Play();
        }
    }
    void setTextoContador(){

        textoContador.text = "Contador: "+ contador.ToString();
      
        if(contador >=12){
            textoGanar.text = "¡Ganaste! :D ";
        }
    }

    
}

