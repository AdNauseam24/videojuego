using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject hotbar;
    private bool menuAbierto;
    void Start()
    {
        hotbar.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventario") && !menuAbierto)
        {
            hotbar.transform.SetParent(GameObject.FindGameObjectWithTag("Huecos").transform);
            menuAbierto = true;
        }
    }
}
