using UnityEngine;

namespace InitializeSystem
{
	public static class InitializeMonoBehaviour
	{
		public static void AddComponent<TComponent, TValue>(
			this GameObject gameObject, TValue tValue) 
			where TComponent : Component, IInitialize<TValue>
		{
			gameObject.AddComponent<TComponent>().Assign(tValue);
		}
		
		public static void AddComponent<TComponent, TValue, TValue2>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2) 
			where TComponent : Component, IInitialize<TValue, TValue2>
		{
			gameObject.AddComponent<TComponent>().Initialize(tValue, tValue2);
		}
		
		public static void AddComponent<TComponent, TValue, TValue2, TValue3>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2, TValue3 tValue3) 
			where TComponent : Component, IInitialize<TValue, TValue2, TValue3>
		{
			gameObject.AddComponent<TComponent>().Initialize(tValue, tValue2, tValue3);
		}
		public static void AddComponent<TComponent, TValue, TValue2, TValue3, TValue4>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2, TValue3 tValue3, TValue4 tValue4) 
			where TComponent : Component, IInitialize<TValue, TValue2, TValue3, TValue4>
		{
			gameObject.AddComponent<TComponent>().Initialize(tValue, tValue2, tValue3, tValue4);
		}
		public static void AddComponent<TComponent, TValue, TValue2, TValue3, TValue4, TValue5>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2, TValue3 tValue3, TValue4 tValue4, TValue5 tValue5) 
			where TComponent : Component, IInitialize<TValue, TValue2, TValue3, TValue4, TValue5>
		{
			gameObject.AddComponent<TComponent>().Initialize(tValue, tValue2, tValue3, tValue4, tValue5);
		}
		
		
		public static void GetComponent<TComponent, TValue>(
			this GameObject gameObject, TValue tValue) 
			where TComponent : Component, IInitialize<TValue>
		{
			gameObject.GetComponent<TComponent>().Assign(tValue);
		}
		
		public static void GetComponent<TComponent, TValue, TValue2>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2) 
			where TComponent : Component, IInitialize<TValue, TValue2>
		{
			gameObject.GetComponent<TComponent>().Initialize(tValue,tValue2);
		}
		
		public static void GetComponent<TComponent, TValue, TValue2, TValue3>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2, TValue3 tValue3) 
			where TComponent : Component, IInitialize<TValue, TValue2, TValue3>
		{
			gameObject.GetComponent<TComponent>().Initialize(tValue, tValue2, tValue3);
		}
		
		public static void GetComponent<TComponent, TValue, TValue2, TValue3, TValue4>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2, TValue3 tValue3, TValue4 tValue4) 
			where TComponent : Component, IInitialize<TValue, TValue2, TValue3, TValue4>
		{
			gameObject.GetComponent<TComponent>().Initialize(tValue, tValue2, tValue3, tValue4);
		}
		
		public static void GetComponent<TComponent, TValue, TValue2, TValue3, TValue4, TValue5>(
			this GameObject gameObject, TValue tValue, TValue2 tValue2, TValue3 tValue3, TValue4 tValue4, TValue5 tValue5) 
			where TComponent : Component, IInitialize<TValue, TValue2, TValue3, TValue4, TValue5>
		{
			gameObject.GetComponent<TComponent>().Initialize(tValue, tValue2, tValue3, tValue4, tValue5);
		}
	}
}