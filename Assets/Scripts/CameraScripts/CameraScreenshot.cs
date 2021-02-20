        using System;
using System.IO;
using UnityEngine;

public class CameraScreenshot : MonoBehaviour
{
    [SerializeField] private Camera _camera = default;
    [SerializeField] private GameObject _ui = default;
    private readonly string _screenshotsFolder = "/Screenshots";
    private readonly int _resolutionWidth = 1920;
    private readonly int _resolutionHeight = 1080;


    public string TakeScreenshot()
    {
        string savePath = Application.persistentDataPath + _screenshotsFolder;
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        _ui.SetActive(false);
        RenderTexture renderTexture = new RenderTexture(_resolutionWidth, _resolutionHeight, 24);
        _camera.targetTexture = renderTexture;
        Texture2D screenshotTexture = new Texture2D(_resolutionWidth, _resolutionHeight, TextureFormat.RGB24, false);
        _camera.Render();
        RenderTexture.active = renderTexture;
        screenshotTexture.ReadPixels(new Rect(0, 0, _resolutionWidth, _resolutionHeight), 0, 0);
        screenshotTexture.Apply();
        _camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);
        byte[] bytes = screenshotTexture.EncodeToPNG();
        string filename = ScreenShotPath();
        File.WriteAllBytes(filename, bytes);
        _ui.SetActive(true);
        return filename;
    }

    private string ScreenShotPath()
    {
        string savePath = Application.persistentDataPath + _screenshotsFolder;
        return savePath + "/" + ScreenshotImageName();
    }

    private string ScreenshotImageName()
    {
        return string.Format("screen_{0}x{1}_{2}.png", _resolutionWidth, _resolutionHeight,
                             DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
