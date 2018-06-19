using System.ComponentModel;
using UnityEngine;

public partial class SROptions
{

	[Category("Test")]
	public void LogTimeSinceStart()
	{
		Debug.Log(Time.realtimeSinceStartup);
	}

	public enum FpsEnum
	{
		Normal = 30,
		High = 60
	}

	[Category("Performance")]
	public FpsEnum Fps
	{
		get { return (FpsEnum) Application.targetFrameRate; }
		set
		{
			Application.targetFrameRate = (int) value;
			OnPropertyChanged("Fps");
		}
	}
}
