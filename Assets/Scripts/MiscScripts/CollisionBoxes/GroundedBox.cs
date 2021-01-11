using UnityEngine;

public class GroundedBox : MonoBehaviour
{
	[SerializeField] private GameObject _groundedBoxResponder = default;
	private LayerMask _groundLayerMask;
	private IPushboxResponder _pushboxResponder;

	private void Start()
	{
		_pushboxResponder = _groundedBoxResponder.GetComponent<IPushboxResponder>();
		_groundLayerMask = LayerProvider.GetLayerMask(LayerMasksEnum.Ground);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 10)
		{
			_pushboxResponder.OnGrounded();
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 10)
		{
			_pushboxResponder.OnAir();
		}
	}
}
