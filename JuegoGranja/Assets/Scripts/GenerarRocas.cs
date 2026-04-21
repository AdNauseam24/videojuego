using UnityEditor;
using UnityEngine;

public class GenerarRocas : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spotsRocas;
    void Start()
    {
        
        foreach(GameObject spot in spotsRocas)
        {
            int x = Random.Range(1,4);
            if(x == 1)
            {
            int y = Random.Range(1,11);
            Object prefab;
            if(y >= 1 && y <= 4)
                {
                    #if UNITY_EDITOR
                        prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Rocas/Roca.prefab", typeof(Rocas));
                    #endif
                    #if UNITY_STANDALONE
                         prefab = Resources.Load("Prefabs/Rocas/Roca", typeof(Rocas));
                    #endif
                    
                }
            else if(y >=5 && y <= 7)
                {
                    #if UNITY_EDITOR
                        prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Rocas/Cobre.prefab", typeof(Rocas));
                    #endif
                    #if UNITY_STANDALONE
                        prefab = Resources.Load("Prefabs/Rocas/Cobre", typeof(Rocas));   
                    #endif
                    
                }
            else if (y == 8 || y == 9)
                {
                    #if UNITY_EDITOR
                        prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Rocas/Hierro.prefab", typeof(Rocas));
                    #endif
                    #if UNITY_STANDALONE
                        prefab = Resources.Load("Prefabs/Rocas/Hierro", typeof(Rocas));
                    #endif
                  
                }
                else
                {
                    #if UNITY_EDITOR
                        prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Rocas/Oro.prefab", typeof(Rocas));
                    #endif
                    #if UNITY_STANDALONE
                        prefab = Resources.Load("Prefabs/Rocas/Oro", typeof(Rocas));
                    #endif
                   
                }
            
		    ObjetoDrop drop = Instantiate(prefab,spot.transform,false) as ObjetoDrop;
            }
        }
    }


}
