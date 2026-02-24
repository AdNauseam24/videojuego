using UnityEngine;

public class Trigger2_1 : MonoBehaviour
{

    public delegate void EmpezarScript();
    public static event EmpezarScript OnEmpezarScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnEmpezarScript();
            Destroy(gameObject);
        }
    }
}
