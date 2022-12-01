using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//activar la libreria UnityEngine.UI
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //control total de mondedas
    private int totalMonedas;
    [SerializeField] private TMP_Text textoMonedas;
    //Lista corazones
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazoneMuerto;
    // Start is called before the first frame update
    void Start()
    {
        Moneda.sumaMoneda += SumarMonedas;  
    }
    private void SumarMonedas(int moneda){
        totalMonedas += moneda;
        textoMonedas.text = totalMonedas.ToString();
    }
    //funcion para llamar desde el personaje para bajar la vida
    public void RstaCorazones (int indice){
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazoneMuerto;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
