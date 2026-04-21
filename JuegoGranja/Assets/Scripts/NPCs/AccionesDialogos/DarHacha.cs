using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ComportamientoDerivadoPrueba", menuName = "Scriptable Objects/DarHacha")]
public class DarHacha : ComportamientoBaseSO
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
		drop.SetId(3);
		drop.GetComponent<ObjetoDrop>().enabled = true;
        GestorDIalogos.Instance.TerminarDialogo();
    }
}
