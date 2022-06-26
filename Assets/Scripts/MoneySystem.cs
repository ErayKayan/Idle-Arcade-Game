using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
	public int money = 0;
	public int moneyOnStake;

	[SerializeField] private int customerMoney = 20;
	[SerializeField] private int VipCustomerMoney = 60;

	[Header("Money Prefab List")]
	public List<GameObject> moneyPrefabContaier;

	[Header("Money Prefab")]
	[SerializeField] private GameObject moneyPrefab = null;

	[Header("Money Container")]
	[SerializeField] private Transform moneyContainer = null;

	[Header("Money Order Config")]
	[SerializeField] private Vector2 betweenSpace = new Vector2(.2f, .2f);


	#region MoneySystem Singleton Pattern
	public static MoneySystem Instance { get; private set; }

	private void Awake()
	{
		Instance = this;

	}
	#endregion

	private void Start()
	{
		moneyPrefabContaier = new List<GameObject>();
	}

	private void Update()
	{
		Debug.Log("MONEY= " + money);
		Debug.Log("MONEY ON STAKE = " + moneyOnStake);

		EventBroker.UpdateMoney();

	}

	public void CollectMoney()
	{
		if (moneyOnStake > 0)
		{
			money += moneyOnStake;
			moneyOnStake = 0;
			Invoke(nameof(RemoveList), 1.3f);
			GUIController.Instance.MoneyPopUp(customerMoney);
		}
	}

	public void GetCustomersMoney()
	{
		moneyOnStake += customerMoney;
		AddList();
	}

	public void AddList()
	{
		GameObject itemTemp = (GameObject)Instantiate(moneyPrefab, moneyContainer);
		if (!moneyPrefabContaier.Contains(itemTemp))
		{
			moneyPrefabContaier.Add(itemTemp);
		}
		OrderList();
	}

	public void RemoveList()
	{
		if (moneyPrefabContaier.Count >= 0)
		{
			GameObject temp = null;
			foreach (var item in moneyPrefabContaier)
			{
				temp = item;
				Destroy(temp);
			}
			moneyPrefabContaier.Clear();
			OrderList();
		}
	}

	private void OrderList()
	{
		int yMultiply = 1;
		for (int i = 0; i < moneyPrefabContaier.Count; i++)
		{
			switch (i % 2)
			{
				case 0:
					moneyPrefabContaier[i].transform.localPosition = new Vector3(0f, betweenSpace.y * yMultiply, 0f);
					break;

				case 1:
					moneyPrefabContaier[i].transform.localPosition = new Vector3(betweenSpace.x, betweenSpace.y * yMultiply, 0f);
					yMultiply++;
					break;
			}
		}
	}

}
