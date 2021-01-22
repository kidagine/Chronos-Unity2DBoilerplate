using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Device Configurator", menuName = "Scriptable Objects/Device Configurator", order = 1)]
public class DeviceConfigurator : ScriptableObject
{
    [System.Serializable]
    public struct DeviceSet
    {
        public string deviceRawPath;
        public DeviceSettings deviceDisplaySettings;
    }

    [System.Serializable]
    public struct DisconnectedSettings
    {
        public string disconnectedDisplayName;
        public Color disconnectedDisplayColor;
    }

    public List<DeviceSet> listDeviceSets = new List<DeviceSet>();

    public DisconnectedSettings disconnectedDeviceSettings;

    private Color fallbackDisplayColor = Color.white;


    public string GetDeviceName(UnityEngine.InputSystem.PlayerInput playerInput)
    {

        string currentDeviceRawPath = playerInput.devices[0].ToString();

        string newDisplayName = null;

        for (int i = 0; i < listDeviceSets.Count; i++)
        {

            if (listDeviceSets[i].deviceRawPath == currentDeviceRawPath)
            {
                newDisplayName = listDeviceSets[i].deviceDisplaySettings.deviceDisplayName;
            }
        }

        if (newDisplayName == null)
        {
            newDisplayName = currentDeviceRawPath;
        }

        return newDisplayName;

    }


}
