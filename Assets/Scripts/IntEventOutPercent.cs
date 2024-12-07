using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class IntEventOutPercent : MonoBehaviour
{
	[SerializeField] private IntEvent attachedIntEvent;
	[SerializeField] private TextMeshProUGUI attachedIntEventText;

	private void OnEnable()
	{
		attachedIntEvent.RegisterDelegate(AttachedIntEventChanged);
	}

	private void OnDisable()
	{
		attachedIntEvent.UnregisterDelegate(AttachedIntEventChanged);
	}

	private void AttachedIntEventChanged(bool isDebug)
	{
		//Debug.Log("IntEvent new value = " + attachedIntEvent.IntValue.ToString());
		attachedIntEventText.text = $@"{attachedIntEvent.IntValue}%";
		//do stuff
	}
}
