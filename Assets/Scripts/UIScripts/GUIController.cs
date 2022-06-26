using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI moneyText = null;
	private int moneyHolder;

	#region GUIController Singleton Pattern
	public static GUIController Instance { get; private set; }

	private void Awake()
	{
		Instance = this;

		//Events
		EventBroker.UpdateMoneyUI += MoneyUpdate;

	}
	#endregion

	public void MoneyPopUp(int temp)
	{
		GameObject moneyPopUpFromPool = (GameObject)PoolingSystem.Instance.SpawnFromPool("MoneyPopUp", Vector3.zero, Quaternion.identity);
		bool plus = false;
		string moneyInt = temp.ToString();
		if (temp > 0)
		{
			plus = true;
			moneyInt = "$" + temp.ToString();
		}
		moneyPopUpFromPool.GetComponent<MoneyPopUp>().SetConfig(moneyInt, plus, moneyText.GetComponent<RectTransform>());
	}

	private void MoneyUpdate()
	{
		moneyHolder = MoneySystem.Instance.money; // Get Money amount

		moneyText.SetText("$" + moneyHolder.ToString());
	}
}
