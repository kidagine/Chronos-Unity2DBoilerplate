using System.Collections.Generic;

public static class SceneDataCarrier
{
	private static readonly Dictionary<string, int> intSceneDataDictionary = new Dictionary<string, int>();
	private static readonly Dictionary<string, float> floatSceneDataDictionary = new Dictionary<string, float>();
	private static readonly Dictionary<string, string> stringSceneDataDictionary = new Dictionary<string, string>();


	public static void SetInt(string key, int value)
	{
		if (!intSceneDataDictionary.ContainsKey(key))
		{
			intSceneDataDictionary.Add(key, value);
		}
		else
		{
			intSceneDataDictionary[key] = value;
		}
	}

	public static int GetInt(string key, int defaultValue)
	{
		if (intSceneDataDictionary.TryGetValue(key, out int value))
		{
			return value;
		}
		else
		{
			return defaultValue;
		}
	}

	public static void SetFloat(string key, float value)
	{
		if (!floatSceneDataDictionary.ContainsKey(key))
		{
			floatSceneDataDictionary.Add(key, value);
		}
		else
		{
			floatSceneDataDictionary[key] = value;
		}
	}

	public static float GetFloat(string key, float defaultValue)
	{
		if (floatSceneDataDictionary.TryGetValue(key, out float value))
		{
			return value;
		}
		else
		{
			return defaultValue;
		}
	}

	public static void SetString(string key, string value)
	{
		if (!stringSceneDataDictionary.ContainsKey(key))
		{
			stringSceneDataDictionary.Add(key, value);
		}
		else
		{
			stringSceneDataDictionary[key] = value;
		}
	}

	public static string GetString(string key, string defaultValue)
	{
		if (stringSceneDataDictionary.TryGetValue(key, out string value))
		{
			return value;
		}
		else
		{
			return defaultValue;
		}
	}
}
