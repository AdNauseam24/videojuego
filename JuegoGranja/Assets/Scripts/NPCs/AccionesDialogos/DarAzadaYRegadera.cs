using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ComportamientoDerivadoPrueba", menuName = "Scriptable Objects/DarAzadaYRegadera")]
public class DarAzadaYRegadera : ComportamientoBaseSO
{
     public override void OnUse()
    {
        Object prefab;
        #if UNITY_EDITOR
        prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
        #endif
        #if UNITY_STANDALONE
        prefab = Resources.Load("Prefabs/ObjetoDrop", typeof(ObjetoDrop));
        #endif
		ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

        drop.transform.position = StatsGenerales.Instance.gameObject.transform.position;
		drop.SetCantidad(1);
		drop.SetId(4);
		drop.GetComponent<ObjetoDrop>().enabled = true;

        Object prefab2;
        #if UNITY_EDITOR
        prefab2 = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
        #endif
        #if UNITY_STANDALONE
        prefab2 = Resources.Load("Prefabs/ObjetoDrop", typeof(ObjetoDrop));
        #endif
		ObjetoDrop drop2 = Instantiate(prefab2,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

        drop2.transform.position = StatsGenerales.Instance.gameObject.transform.position;
		drop2.SetCantidad(1);
		drop2.SetId(5);
		drop2.GetComponent<ObjetoDrop>().enabled = true;
        GestorDIalogos.Instance.TerminarDialogo();
    }
}
