using System.Collections.Generic;
using UnityEngine;

public class LayerProvider : MonoBehaviour
{
    private static List<LayerMask> _layerMasks = new List<LayerMask>();


    public static LayerMask GetLayerMask(LayerMasksEnum layerMaskEnum)
    {
        LayerMask layerMask = LayerMask.GetMask(layerMaskEnum.ToString());
        if (!_layerMasks.Contains(layerMask))
        {

        }
        return layerMask;
    }
}
