using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
		FollowFirst();
	}

	private void FollowAllOtherThanLast()
	{
		var orderedPlayers = _model.GetOrderedPlayers().ToArray();
		if (!orderedPlayers.Any())
		{
			return;
		}

		var first = orderedPlayers.FirstOrDefault();
		var secondToLast = orderedPlayers.Skip(orderedPlayers.Length - 2).FirstOrDefault();

		var y1 = first?.PlayerData.CarData.Position.y ?? CameraPositon.y;
		var y2 = secondToLast?.PlayerData.CarData.Position.y ?? CameraPositon.y;

		var mid = (y1 + y2) / 2;
		UpdateCameraY(mid);
	}

	private void FollowFirst()
	{
		var first = _model.GetOrderedPlayers().FirstOrDefault();
		if (first != null)
		{
			var position = first.PlayerData.CarData.Position;
			var positionY = position.y;
			UpdateCameraY(positionY);
		}
	}

	private void UpdateCameraY(float positionY)
	{
		gameObject.transform.position = new Vector3(CameraPositon.x, positionY - 5, CameraPositon.z);
	}

	private Vector3 CameraPositon => gameObject.transform.position;
}