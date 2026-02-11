using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool empezado;
    void Start()
    {
        beatTempo = beatTempo/60f;
    }

    void Update()
    {
        if (empezado)
        {
            transform.position -= new Vector3(0f, beatTempo*Time.deltaTime,0f);
        }
    }
}
