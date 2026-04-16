using UnityEngine;

public class InputPlayer : MonoBehaviour
{
     // CREAR VARIABLE PARA GUARDAR LA POSICION DEL MOUSE ASI LA USO EN EL SCRIPT DE MOVIMIENTO
    public Vector3 mousePosition;
    public bool mouseLeftClick;

    // CREAR VARIABLE PARA GUARDAR LOS INPUTS DE TECLADO ASI LOS USO EN EL SCRIPT DE MOVIMIENTO
    public float h;
    public float v;
    
    void Update()
    {
        // ACTUALIZACION DE INPUTS DE TECLADO
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        
        // ACTUALIZACION DE LA POSICION DEL MOUSE
        mousePosition = Input.mousePosition;

        // ACTUALIZACION DEL CLIC DEL MOUSE
        mouseLeftClick = Input.GetMouseButtonDown(0);
    }
}