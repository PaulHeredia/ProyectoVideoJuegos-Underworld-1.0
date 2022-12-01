using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    //delegado y evento
    public delegate void SumaMoneda(int moneda);
    public static event SumaMoneda sumaMoneda;

    [SerializeField] private int cantidadMonedas;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sumaMoneda != null)
            {
                SumarMoneda();
                Destroy(this.gameObject);
            }
        }
    }
    private void SumarMoneda(){
        sumaMoneda(cantidadMonedas);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
