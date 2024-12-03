using UnityEngine;

[CreateAssetMenu(fileName = "IntEvent", menuName = "EventVariables/IntEvent")]
public class IntEvent : ScriptableObject
{
	private int intValue;

	public delegate void ValueChangeDelegate(bool isDebug);
	ValueChangeDelegate valueChangeDelegate;

	[SerializeField] private bool debugChange;

	public int IntValue
	{
		set
		{
			intValue = value;

			ValueChanged();
		}
		get
		{
			return intValue;
		}
	}

	private void ValueChanged()
	{
		if (valueChangeDelegate != null)
		{
			valueChangeDelegate(debugChange);
		}
	}

	//delegate part
	public void RegisterDelegate(ValueChangeDelegate givenDelegate)
	{
		valueChangeDelegate += givenDelegate;
	}

	public void UnregisterDelegate(ValueChangeDelegate givenDelegate)
	{
		valueChangeDelegate -= givenDelegate;
	}
}
