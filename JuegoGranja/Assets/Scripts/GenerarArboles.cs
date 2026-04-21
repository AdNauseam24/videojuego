#if UNITY_EDITOR
using UnityEditor;       
#endif

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
            Object prefab;
            ObjetoDrop drop;

            #if UNITY_EDITOR
                prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Arbol.prefab", typeof(Arboles));
                drop = Instantiate(prefab,spot.transform, false) as ObjetoDrop;
            #endif

            #if UNITY_STANDALONE
                prefab = Resources.Load("Prefabs/Arbol", typeof(Arboles));
                drop = Instantiate(prefab,spot.transform, false) as ObjetoDrop;
            #endif
            }
        }
    }


}
