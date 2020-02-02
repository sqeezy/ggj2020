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
		GameModel.CameraPosition = gameObject.transform.position;
		FollowAllOtherThanLast();
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

		var y1 = first?.PlayerData.CarData.Position.y ?? CameraPosition.y;
		var y2 = secondToLast?.PlayerData.CarData.Position.y ?? CameraPosition.y;
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
		gameObject.transform.position = new Vector3(CameraPosition.x, positionY - 5, CameraPosition.z);
	}

	private Vector3 CameraPosition => gameObject.transform.position;
}