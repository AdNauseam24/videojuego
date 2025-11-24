using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
   private float temporizador;

   private Slider slider;

   private bool activo;


    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            temporizador += Time.unscaledDeltaTime;
            slider.value = temporizador;
            if (Input.GetMouseButtonDown(0))
            {
                activo = false;
            }
        }
    }
    public void Activar()
    {
        temporizador = 0;
        slider.value = 0;
        activo = true;
    }

    public float DevolverMultiplicador()
    {
        if(slider.value >= 0.4 && slider.value <= 0.6)
        {
            return 1.5f;
        }
        if((slider.value < 0.4 && slider.value >= 0.2) || (slider.value > 0.6 && slider.value <= 0.8))
        {
            return 1;
        }
        return 0.5f;
    }
}
