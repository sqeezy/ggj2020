using System;
using System.Collections.Generic;
using Zenject;

namespace GenericProvider
{
	public class MainThreadQueue : ITickable
	{
		private readonly Queue<Action> ActionQueue= new Queue<Action>();

		public void enqueueAction(Action action)
		{
			ActionQueue.Enqueue(action);
		}


		public void Tick()
		{
			while (ActionQueue.Count > 0)
			{
				var action = ActionQueue.Dequeue();
				action();
			}
		}
	}
}