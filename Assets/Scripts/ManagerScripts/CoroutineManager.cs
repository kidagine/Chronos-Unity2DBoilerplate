using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineManager : Singleton<CoroutineManager>
{
    public void ImageFade(ref Image color, float startValue, float endValue, float duration)
    {
        StartCoroutine(ImageFade(color, startValue, endValue, duration));
    }

    IEnumerator ImageFade(Image color, float startValue, float endValue, float duration)
    {
        float elapsedTime = 0;
        float returnedValue;
        while (elapsedTime < duration)
        {
            returnedValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            color.color = new Color(255, 255, 255, returnedValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
