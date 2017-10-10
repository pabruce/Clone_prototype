using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Represents a series of events that occur at defined times in an interval
/// </summary>
public class Timeline<T>
{
	/* Delegates */
	public delegate void LoopEvent();

	/* Instance Vars */
	private float simulatedTime;
	private List<Event<T>> events;
	private int eventIndex;
	private bool looping;

	private event LoopEvent loopCompleted;

	/* Instance Methods */
	public Timeline()
	{
		simulatedTime = 0f;
		events = new List<Event<T>> ();
		eventIndex = 0;
		looping = false;
	}

	public bool isLooping()
	{
		return looping;
	}
	public void setLooping(bool looping)
	{
		this.looping = looping;
	}

	/// <summary>
	/// Add a listener to an event that fires once every time the Timeline
	/// completes a loop.
	/// </summary>
	/// <param name="listener">Listener.</param>
	public void addLoopListener(LoopEvent listener)
	{
		loopCompleted += listener;
	}

	/// <summary>
	/// Remove an existing listener from the loop completed event.
	/// </summary>
	/// <param name="listener">Listener.</param>
	public void removeLoopListener(LoopEvent listener)
	{
		loopCompleted -= listener;
	}

	/// <summary>
	/// The time of the last event in the timeline
	/// </summary>
	public float endTime
	{
		get
		{
			if (events.Count == 0)
				return 0f;
			else
				return events [events.Count - 1].time;
		}
	}

	/// <summary>
	/// Creates an event at the indicated time.
	/// </summary>
	/// <param name="time">Time.</param>
	/// <param name="action">Action.</param>
	public void addEvent(float time, T action)
	{
		for (int i = 0; i < events.Count; i++)
		{
			if (events [i].time > time)
			{
				events.Insert (i, new Event<T> (time, action));
				return;
			}
		}
		events.Add (new Event<T> (time, action));
	}
	public void addEvent(float time, T[] actions)
	{
		foreach (T action in actions)
			addEvent (time, action);
	}

	/// <summary>
	/// Returns the simulation  to the beginning without clearing any events
	/// </summary>
	public void reset()
	{
		simulatedTime = 0f;
		eventIndex = 0;
	}

	/// <summary>
	/// Reset the simulation time and clear all events from the timeline.
	/// </summary>
	public void clear()
	{
		reset ();
		events.Clear ();
	}

	/// <summary>
	/// Simulate the timeline for dTime seconds, passing out any actions that happened
	/// in that time frame. Returns false if the timeline has reached the end.
	/// </summary>
	/// <param name="dTime">Delta Time</param>
	/// <param name="actions">Set of Actions</param>
	public bool simulate(float dTime, out T[] actions)
	{
		//either the timeline is empty, or the last event has been passed
		if (events.Count == 0 || (!looping && simulatedTime > endTime))
		{
			actions = null;
			return false;
		}

		simulatedTime += dTime;

		List<T> actionList = new List<T> ();

		//check for events that occur between 0 and the current sim time
		while (simulatedTime >= events [eventIndex].time)
		{
			actionList.Add (events [eventIndex].action);
			eventIndex++;

			//reached the end of the timeline
			if (eventIndex >= events.Count)
			{
				if (looping)
				{
					//reset the eventIndex and carry over the sim time
					//may loop again
					eventIndex = 0;
					simulatedTime -= endTime;

					if (loopCompleted != null)
						loopCompleted ();
				}
				else
					//dump the actions found and indicate that the end of the timline 
					// was reached
					break;
			}
		}
		actions = actionList.ToArray ();
		return true;
	}
		
	/// <summary>
	/// Create a deep clone of this instance, specifying if the simulation 
	/// progress of the original should be kept.
	/// </summary>
	/// <param name="keepSim">Keep the simulation progress</param>
	public Timeline<T> clone(bool keepSim)
	{
		Timeline<T> clone = new Timeline<T> ();

		if (keepSim)
		{
			clone.simulatedTime = simulatedTime;
			clone.eventIndex = eventIndex;
		}
		clone.looping = looping;

		foreach (Event<T> e in events)
			clone.events.Add (e);

		return clone;
	}



	/// <summary>
	/// A lightweight object that represents a point of interest in a Timeline.
	/// Holds a generic action object and a float that indicates the point in a 
	/// timeline it lies.
	/// </summary>
	private struct Event<S>
	{
		public float time;
		public S action;

		public Event(float time, S action)
		{
			this.time = time;
			this.action = action;
		}
	}
}
