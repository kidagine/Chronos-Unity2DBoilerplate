﻿using UnityEngine;

public class GroundedBox : MonoBehaviour
{
	[SerializeField] private GameObject _groundedBoxResponder = default;
	private int _groundLayerMaskIndex;
	private IPushboxResponder _pushboxResponder;

	private void Start()
	{
		if (_groundedBoxResponder != null)
		{
			if (_groundedBoxResponder.TryGetComponent(out IPushboxResponder pushboxResponder))
			{
				_pushboxResponder = pushboxResponder;
				_groundLayerMaskIndex = LayerProvider.GetLayerMaskIndex(LayerMasksEnum.Ground);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == _groundLayerMaskIndex)
		{
			_pushboxResponder.OnGrounded();
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == _groundLayerMaskIndex)
		{
			_pushboxResponder.OnAir();
		}
	}
}
