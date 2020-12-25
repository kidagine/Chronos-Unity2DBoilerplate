using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;


	void Update()
	{
		CheckPlayersFlip();
	}

	private void CheckPlayersFlip()
	{
		if (_playerOne.transform.position.x > _playerTwo.transform.position.x)
		{
			if (_playerOne.TryGetComponent(out Player player))
			{
				if (!player.IsFlipped)
				{
					player.FlipSide();
				}
			}
			if (_playerTwo.TryGetComponent(out Player playerTwo))
			{
				if (!playerTwo.IsFlipped)
				{
					playerTwo.FlipSide();
				}
			}
		}
		else
		{
			if (_playerOne.TryGetComponent(out Player playerOne))
			{
				if (playerOne.IsFlipped)
				{
					playerOne.FlipSide();
				}
			}
			if (_playerTwo.TryGetComponent(out Player playerTwo))
			{
				if (playerTwo.IsFlipped)
				{
					playerTwo.FlipSide();
				}
			}
		}
	}

	public GameObject GetPlayer()
    {
        return _playerOne;
    }
}
