using UnityEngine;

public interface IFallboxResponder
{
	bool StartFall();
	void SetSafeLocation(Vector2 safeLocation);
}

