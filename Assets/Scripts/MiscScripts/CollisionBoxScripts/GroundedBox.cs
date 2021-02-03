using UnityEngine;

public class GroundedBox : MonoBehaviour
{
	[SerializeField] private GameObject _groundedBoxResponder = default;
	private IPushboxResponder _pushboxResponder;
	private int _groundLayerMaskIndex;


	void Start()
	{
		if (_groundedBoxResponder != null)
		{
			if (_groundedBoxResponder.TryGetComponent(out IPushboxResponder pushboxResponder))
			{
				_pushboxResponder = pushboxResponder;
				_groundLayerMaskIndex = LayerProvider.GetLayerMaskIndex(LayerMaskEnum.Ground);
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
