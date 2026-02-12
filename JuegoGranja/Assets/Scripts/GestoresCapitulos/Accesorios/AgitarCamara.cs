using System.Collections;
using UnityEngine;

public class AgitarCamara : MonoBehaviour
{
    public IEnumerator Agitar(float tiempo, float magnitud)
    {
        Vector3 originalPos = transform.localPosition;
        float timeElapsed = 0f;

        while(timeElapsed < tiempo)
        {
            float xOffset = Random.Range(originalPos.x - 0.5f, originalPos.x +0.5f) * magnitud;
            float yOffset = Random.Range(originalPos.y-0.5f, originalPos.y + 0.5f) * magnitud;
            transform.localPosition = new Vector3(xOffset,yOffset,originalPos.z);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
