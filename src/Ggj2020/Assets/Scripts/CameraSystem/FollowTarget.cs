using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class FollowTarget : MonoBehaviour
{
	private GameModel _model;

	[Inject]
	public void Init(GameModel model)
	{
		_model = model;
	}

	// Start is called before the first frame update
	private void Start()
	{
	}

	// Update is called once per frame
	private void LateUpdate()
	{
		var first = _model.GetOrderedPlayers().FirstOrDefault();
		if (first != null)
		{
			var position = first.PlayerData.CarData.Position;
			var transformPosition = gameObject.transform.position;
			gameObject.transform.position = new Vector3(transformPosition.x, position.y - 5, transformPosition.z);
		}
	}
}