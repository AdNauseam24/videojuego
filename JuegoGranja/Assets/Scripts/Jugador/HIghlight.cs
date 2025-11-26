using UnityEngine;

public class HIghlight : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector2 mouse;

    private Vector2 worldPos;

    private float contador;

    private bool activado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(contador > 0)
        {
            contador -= Time.unscaledDeltaTime;
        }
        else
        {
            activado = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
         /*mouse = Input.mousePosition;

         worldPos = Camera.main.ScreenToWorldPoint(mouse);

        Vector2 playerPos = player.position;

       
        Vector2 diferencia = worldPos - playerPos;
        float x = diferencia.x;
        float y = diferencia.y;

        if (Mathf.Abs(x)> 2 || Mathf.Abs(y)> 2)
        {
            activado = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            activado = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if(x>0 && y<0.5 && y > -0.5)
        {
            transform.position = playerPos + new Vector2(1,0);
        }
        else if (y>0 && x < 0.5 && x > -0.5)
        {
            transform.position = playerPos + new Vector2(0,1);
        }
        else if(x<0 && y<0.5 && y > -0.5)
        {
            transform.position = playerPos + new Vector2(-1,0);
        }
        else if (y<0 && x < 0.5 && x > -0.5)
        {
            transform.position = playerPos + new Vector2(0,-1);
        }
        
        else if(x>0 && y > 0)
        {
            transform.position = playerPos + new Vector2(1,1);
        }
        else if( x>0 && y < 0)
        {
            transform.position = playerPos + new Vector2(1,-1);
        }
        else if (x<0 && y > 0)
        {
            transform.position = playerPos + new Vector2(-1,1);
        }
        else if( x<0 && y< 0)
        {
            transform.position = playerPos + new Vector2(-1,-1);
        }
        */

    }

    public bool GetPosicionValida()
    {
        mouse = Input.mousePosition;

        worldPos = Camera.main.ScreenToWorldPoint(mouse);

        Vector2 playerPos = player.position;

        Vector2 diferencia = worldPos - playerPos;
        float x = diferencia.x;
        float y = diferencia.y;

        if (Mathf.Abs(x)> 2 || Mathf.Abs(y)> 2)
        {
            return false;
        }

        return true;
    }
    public Vector2 GetPosicion()
    {
        mouse = Input.mousePosition;

        worldPos = Camera.main.ScreenToWorldPoint(mouse);

        Vector2 playerPos = player.position;

        Vector2 diferencia = worldPos - playerPos;
        float x = diferencia.x;
        float y = diferencia.y;

        if(x>0 && y<0.5 && y > -0.5)
        {
            return playerPos + new Vector2(1,0);
        }
        else if (y>0 && x < 0.5 && x > -0.5)
        {
            return playerPos + new Vector2(0,1);
        }
        else if(x<0 && y<0.5 && y > -0.5)
        {
            return playerPos + new Vector2(-1,0);
        }
        else if (y<0 && x < 0.5 && x > -0.5)
        {
            return playerPos + new Vector2(0,-1);
        }
        else return playerPos;

    }

    public void VisibleValido(Vector2 posicion)
    {
        transform.position = posicion;
        activado = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        contador = 1;
                Debug.Log("valido");

    }

    public void VisibleNoValido(Vector2 posicion)
    {
        transform.position = posicion;
        activado = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0,0,0.5f);
        contador = 1;
        Debug.Log("NO valido");
    }
}
