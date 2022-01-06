using System;
using System.Globalization;
using UnityEngine;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: The Fun Pimps.
//	Tweaked: Sirillion.

//	This is the complete vanilla controller. We disabled the visible component that removes the entire toolbelt when entering a vehicle so that we can display our XP bar all the time.
//	Difference: Disables the visible component, no other change. Can be used as a replacement for the vanilla XUiC_ToolbeltWindow controller if you want to show the toolbelt while using vehicles.

public class XUiC_ToolbeltXP : XUiController
{
	public override void Update(float _dt)
	{
		base.Update(_dt);
		this.deltaTime = _dt;
		if ((DateTime.Now - this.updateTime).TotalSeconds > 0.5)
		{
			this.updateTime = DateTime.Now;
		}
		base.RefreshBindings(false);
		// base.ViewComponent.IsVisible = ((!(this.localPlayer.AttachedToEntity != null) || !(this.localPlayer.AttachedToEntity is EntityVehicle)) && !this.localPlayer.IsDead());
		if (this.CustomAttributes.ContainsKey("standard_xp_color"))
		{
			this.standardXPColor = this.CustomAttributes["standard_xp_color"];
		}
		else
		{
			this.standardXPColor = "128,4,128";
		}
		if (this.CustomAttributes.ContainsKey("updating_xp_color"))
		{
			this.updatingXPColor = this.CustomAttributes["updating_xp_color"];
		}
		else
		{
			this.updatingXPColor = "128,4,128";
		}
		if (this.CustomAttributes.ContainsKey("deficit_xp_color"))
		{
			this.expDeficitColor = this.CustomAttributes["deficit_xp_color"];
		}
		else
		{
			this.expDeficitColor = "222,20,20";
		}
		if (this.CustomAttributes.ContainsKey("xp_fill_speed"))
		{
			this.xpFillSpeed = StringParsers.ParseFloat(this.CustomAttributes["xp_fill_speed"], 0, -1, NumberStyles.Any);
		}
	}

	public override void OnOpen()
	{
		base.OnOpen();
		if (this.localPlayer == null)
		{
			this.localPlayer = base.xui.playerUI.entityPlayer;
		}
		this.currentValue = (this.lastValue = XUiM_Player.GetLevelPercent(this.localPlayer));
	}

	public override bool GetBindingValue(ref string value, string bindingName)
	{
		if (bindingName != null)
		{
			if (bindingName == "xp")
			{
				if (this.localPlayer != null)
				{
					if (this.localPlayer.Progression.ExpDeficit > 0)
					{
						float v = Math.Max(this.lastDeficitValue, 0f) * 1.01f;
						value = this.bindingXp.Format(v);
						this.currentValue = (float)this.localPlayer.Progression.ExpDeficit / (float)this.localPlayer.Progression.GetExpForNextLevel();
						if (this.currentValue != this.lastDeficitValue)
						{
							this.lastDeficitValue = Mathf.Lerp(this.lastDeficitValue, this.currentValue, Time.deltaTime * this.xpFillSpeed);
							if (Mathf.Abs(this.currentValue - this.lastDeficitValue) < 0.005f)
							{
								this.lastDeficitValue = this.currentValue;
							}
						}
					}
					else
					{
						float v2 = Math.Max(this.lastValue, 0f) * 1.01f;
						value = this.bindingXp.Format(v2);
						this.currentValue = XUiM_Player.GetLevelPercent(this.localPlayer);
						if (this.currentValue != this.lastValue)
						{
							this.lastValue = Mathf.Lerp(this.lastValue, this.currentValue, Time.deltaTime * this.xpFillSpeed);
							if (Mathf.Abs(this.currentValue - this.lastValue) < 0.005f)
							{
								this.lastValue = this.currentValue;
							}
						}
					}
				}
				return true;
			}
			if (bindingName == "xpcolor")
			{
				if (this.localPlayer != null)
				{
					if (this.localPlayer.Progression.ExpDeficit > 0)
					{
						value = this.expDeficitColor;
					}
					else
					{
						value = ((this.currentValue == this.lastValue) ? this.standardXPColor : this.updatingXPColor);
					}
				}
				else
				{
					value = "";
				}
				return true;
			}
		}
		return false;
	}

	private EntityPlayer localPlayer;

	private DateTime updateTime;

	private float lmpPositionAdjustment = 0.05f;

	private float lastValue;

	private float currentValue;

	private float lastDeficitValue;

	private float deltaTime;

	private string standardXPColor = "";

	private string updatingXPColor = "";

	private string expDeficitColor = "";

	private float xpFillSpeed = 2.5f;

	private CachedStringFormatter<float> bindingXp = new CachedStringFormatter<float>((float _f) => _f.ToCultureInvariantString());
}
