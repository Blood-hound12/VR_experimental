using System.Collections;
using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    public float esperaAntesDeFade = 5f;
    public float tiempoDeFade = 2f;
    private Renderer rend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();

        StartCoroutine(RoutineFade());
    }

    IEnumerator RoutineFade()
    {
        yield return new WaitForSeconds(esperaAntesDeFade);

        float lerpTime = 0;
        Color colorOriginal = rend.material.color;

        while(lerpTime < 1)
        {
            lerpTime += Time.deltaTime / tiempoDeFade;

            Color nuevoColor = colorOriginal;
            nuevoColor.a = Mathf.Lerp(1, 0, lerpTime);

            rend.material.color = nuevoColor;

            yield return null;
        }

        Destroy(gameObject);
    }
}
