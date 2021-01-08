using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineManager : Singleton<CoroutineManager>
{
    public void ImageFade(ref Image color, float startValue, float endValue, float duration)
    {
        StartCoroutine(ImageFadeCoroutine(color, startValue, endValue, duration));
    }

    private IEnumerator ImageFadeCoroutine(Image color, float startValue, float endValue, float duration)
    {
        float elapsedTime = 0;
        float returnedValue;
        while (elapsedTime < duration)
        {
            returnedValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            color.color = new Color(255.0f, 255.0f, 255.0f, returnedValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
