using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Agua : MonoBehaviour
{
    [SerializeField]
    private GameObject piscina;

    [SerializeField]
    private GameObject cursor;

    [SerializeField]
    private MovePointPez movePointPez;

    [SerializeField]
    private Cursor player;
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public  async Task<float> IniciarMinijuego(Vector2 posicion)
    {
      piscina.SetActive(true);
      piscina.transform.position = posicion;

      cursor.SetActive(true);
      cursor.transform.position = new Vector3(posicion.x,posicion.y,0f);

      float radio = piscina.GetComponent<SpriteRenderer>().bounds.size.x/2;

      cursor.GetComponent<Cursor>().SetLimites(radio, posicion);

      movePointPez.SetRadio(radio);
      movePointPez.SetCentro(posicion);
      movePointPez.Empezar();

      float sliderValue = player.SliderValue();

      Debug.Log(sliderValue);

      while ( sliderValue > 0 && sliderValue < 1)
        {
            sliderValue = player.SliderValue();
           await Task.Yield();
            
        }

        return sliderValue;
      
    }

    public void CerrarMinijuego()
    {
        piscina.SetActive(false);
        cursor.SetActive(false);
    }
}
