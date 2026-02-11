using UnityEngine;

public class BotonRitmo : MonoBehaviour
{
    private SpriteRenderer spriteBoton;
    public Sprite defaultIMG;
    public Sprite pressedIMG;

    public KeyCode key;

    void Start()
    {
        spriteBoton = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            spriteBoton.sprite = pressedIMG;
        }
        if (Input.GetKeyUp(key))
        {
            spriteBoton.sprite = defaultIMG;
        }
    }
}
