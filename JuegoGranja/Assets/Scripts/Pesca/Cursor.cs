using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    private float radio;

    [SerializeField]
    private Vector2 centro;

    private Vector2 posicionraton;
   
   [SerializeField]
   private Slider slider;

    //A mayor número más lento
    public float velocidadPesca;
    public float VelocidadPerderPez;

    
    void Update()
    {
        
        posicionraton = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Physics.Simulate(Time.fixedDeltaTime);

        
        if(Vector2.Distance(centro, posicionraton) < radio)
        {
            transform.position = posicionraton;
           
        }
        
        if(Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Pez")))
        {
            slider.value += Time.unscaledDeltaTime/velocidadPesca;
        }
        else
        {
            slider.value -= Time.unscaledDeltaTime/VelocidadPerderPez;
        }
    }

    public void SetLimites(float radio, Vector2 centro)
    {
        this.radio = radio;
        this.centro = centro;
        slider.value = 0.5f;

    }

    public float SliderValue()
    {
        return slider.value;
    }
}
