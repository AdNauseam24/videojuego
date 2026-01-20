using UnityEditor;
using UnityEngine;

public class GenerarArboles : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spotsArboles;
    void Start()
    {
        
        foreach(GameObject spot in spotsArboles)
        {
            int x = Random.Range(1,6);
            if(x == 1)
            {
            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Arbol.prefab", typeof(Arboles));
		    ObjetoDrop drop = Instantiate(prefab,spot.transform, false) as ObjetoDrop;
            }
        }
    }


}
