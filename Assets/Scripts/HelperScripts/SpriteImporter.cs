using System.IO;
using UnityEngine;

public static class SpriteImporter
{
    public static Sprite LoadSprite(string imagePath)
    {

        if (File.Exists(imagePath))
        {
            byte[] FileData = File.ReadAllBytes(imagePath);
            Texture2D texture2D = new Texture2D(2, 2);
            if (texture2D.LoadImage(FileData))
            {
                texture2D.filterMode = FilterMode.Point;
                Sprite newSprite =Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero, 32);
                return newSprite;
            }
        }
        return null;
    }
}
