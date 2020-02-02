using System.Collections;
using System.Collections.Generic;
using GenericProvider;
using UnityEngine;
using Zenject;

public class OnlyOnMaster : MonoBehaviour
{
	private URLReader _reader;

	[Inject]
	public void Init(URLReader reader)
	{
		_reader = reader;
		if (!reader.AmIMaster())
		{
			gameObject.SetActive(false);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}
}