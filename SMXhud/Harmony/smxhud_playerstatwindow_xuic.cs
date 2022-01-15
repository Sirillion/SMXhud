using UnityEngine;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: sphereii.
//	Tweaked: Sirillion, TormentedEmu.

//	Adds a custom controller with bindings lost with the removal of the PlayerStatWindow controller. Additional compatible bindings added from other controllers.
//	Difference: Vanilla removed the PlayerStatWindow controller with A20. As such we lost access to a lot of bindings needed to put things onto the HUD, this restores that.

internal class XUiC_PlayerStatWindow : XUiController
{
    public override void Init()
    {
        base.Init();
    }

    public override bool GetBindingValue(ref string value, string bindingName)
    {
        string fieldName = bindingName;

        // Player LEVEL bindings.
        if (fieldName == "playerleveltitle")
        {
            value = Localization.Get("xuiLevel");
            return true;
        }

        if (fieldName == "playerlevel")
        {
            value = ((this.player != null) ? this.playerLevelFormatter.Format(XUiM_Player.GetLevel(this.player)) : "");
            return true;
        }

        if (fieldName == "playerlevelfill")
        {
            value = ((this.player != null) ? this.playerLevelFillFormatter.Format(XUiM_Player.GetLevelPercent(this.player)) : "");
            return true;
        }

        // Player DEATH bindings.
        if (fieldName == "playerdeathstitle")
        {
            value = Localization.Get("xuiDeaths");
            return true;
        }

        if (fieldName == "playerdeaths")
        {
            value = ((this.player != null) ? this.playerDeathsFormatter.Format(XUiM_Player.GetDeaths(this.player)) : "");
            return true;
        }

        // Player ZOMBIE KILLS bindings.
        if (fieldName == "playerzombiekillstitle")
        {
            value = Localization.Get("xuiZombieKills");
            return true;
        }

        if (fieldName == "playerzombiekills")
        {
            value = ((this.player != null) ? this.playerZombieKillsFormatter.Format(XUiM_Player.GetZombieKills(this.player)) : "");
            return true;
        }


        // Player PVP KILLS bindings.
        if (fieldName == "playerpvpkillstitle")
        {
            value = Localization.Get("xuiPlayerKills");
            return true;
        }

        if (fieldName == "playerpvpkills")
        {
            value = ((this.player != null) ? this.playerPvpKillsFormatter.Format(XUiM_Player.GetPlayerKills(this.player)) : "");
            return true;
        }


        // Player LONGEST LIFE bindings.
        if (fieldName == "playerlongestlifetitle")
        {
            value = Localization.Get("xuiLongestLife");
            return true;
        }

        if (fieldName == "playerlongestlife")
        {
            value = ((this.player != null) ? XUiM_Player.GetLongestLife(this.player) : "");
            return true;
        }

        // Player TRAVELLED bindings.
        if (fieldName == "playertravelledtitle")
        {
            value = Localization.Get("xuiKMTravelled");
            return true;
        }

        if (fieldName == "playertravelled")
        {
            value = ((this.player != null) ? XUiM_Player.GetKMTraveled(this.player) : "");
            return true;
        }

        // Player ITEMS CRAFTED bindings.
        if (fieldName == "playeritemscraftedtitle")
        {
            value = Localization.Get("xuiItemsCrafted");
            return true;
        }

        if (fieldName == "playeritemscrafted")
        {
            value = ((this.player != null) ? this.playerItemsCraftedFormatter.Format(XUiM_Player.GetItemsCrafted(this.player)) : "");
            return true;
        }


        // Player WELLNESS bindings.
        if (fieldName == "playerwellnesstitle")
        {
            value = Localization.Get("xuiWellness");
            return true;
        }

        // CORETEMP
        if (fieldName == "playercoretemptitle")
        {
            value = Localization.Get("xuiFeelsLike");
            return true;
        }

        if (fieldName == "playercoretemp")
        {
            value = ((this.player != null) ? XUiM_Player.GetCoreTemp(this.player) : "");
            return true;
        }

        // FOOD
        if (fieldName == "playerfoodtitle")
        {
            value = Localization.Get("xuiFood");
            return true;
        }

        if (fieldName == "playerfood")
        {
            value = ((this.player != null) ? this.playerFoodFormatter.Format(XUiM_Player.GetFood(this.player)) : "");
            return true;
        }

        if (fieldName == "playerfoodfill")
        {
            value = ((this.player != null) ? this.playerFoodFillFormatter.Format(XUiM_Player.GetFoodPercent(this.player)) : "");
            return true;
        }

        // WATER
        if (fieldName == "playerwatertitle")
        {
            value = Localization.Get("xuiWater");
            return true;
        }

        if (fieldName == "playerwater")
        {
            value = ((this.player != null) ? this.playerWaterFormatter.Format(XUiM_Player.GetWater(this.player)) : "");
            return true;
        }
        
        if (fieldName == "playerwaterfill")
        {
            value = ((this.player != null) ? this.playerWaterFillFormatter.Format(XUiM_Player.GetWaterPercent(this.player)) : "");
            return true;
        }


        // From XUiC_CharacterFrameWindow
        // Player LOOTSTAGE bindings.
        if (bindingName == "playerlootstagetitle")
        {
            value = Localization.Get("xuiLootstage");
            return true;
        }

        if (bindingName == "playerlootstage")
        {
            value = ((this.player != null) ? this.player.GetHighestPartyLootStage(0f, 0f).ToString() : "");
            return true;
        }

        // Player WELLNESS bindings.
        if (bindingName == "playerwatermax")
        {
            value = ((this.player != null) ? this.playerWaterMaxFormatter.Format(XUiM_Player.GetWaterMax(this.player)) : "");
            return true;
        }

        if (bindingName == "playerfoodmax")
        {
            value = ((this.player != null) ? this.playerFoodMaxFormatter.Format(XUiM_Player.GetFoodMax(this.player)) : "");
            return true;
        }

        if (bindingName == "playerhealth")
        {
            value = ((this.player != null) ? this.playerHealthFormatter.Format((int)XUiM_Player.GetHealth(this.player)) : "");
            return true;
        }

        if (bindingName == "playermaxhealth")
        {
            value = ((this.player != null) ? this.playerMaxHealthFormatter.Format((int)XUiM_Player.GetMaxHealth(this.player)) : "");
            return true;
        }

        if (bindingName == "playerstamina")
        {
            value = ((this.player != null) ? this.playerStaminaFormatter.Format((int)XUiM_Player.GetStamina(this.player)) : "");
            return true;
        }

        if (bindingName == "playermaxstamina")
        {
            value = ((this.player != null) ? this.playerMaxStaminaFormatter.Format((int)XUiM_Player.GetMaxStamina(this.player)) : "");
            return true;
        }

        if (bindingName == "playerxptonextlevel")
        {
            value = ((this.player != null) ? this.playerXpToNextLevelFormatter.Format(XUiM_Player.GetXPToNextLevel(this.player) + this.player.Progression.ExpDeficit) : "");
            return true;
        }


        // From PassiveEffects
        if (bindingName == "playerbagsize")
        {
            value = ((this.player != null) ? this.playerBagSizeFormatter.Format((int)EffectManager.GetValue(PassiveEffects.BagSize, null, 0f, this.player, null, default(FastTags), true, true, true, true, 1, true)) : "");
            return true;
        }


        // From XUiC_MapStats
        if (bindingName == "day")
        {
            value = "";
            if (XUi.IsGameRunning() && base.xui.playerUI.entityPlayer != null)
            {
                value = this.dayFormatter.Format(GameManager.Instance.World.worldTime);
            }
            return true;
        }

        if (bindingName == "time")
        {
            value = "";
            if (XUi.IsGameRunning() && base.xui.playerUI.entityPlayer != null)
            {
                value = this.timeFormatter.Format(GameManager.Instance.World.worldTime);
            }
            return true;
        }


        // Team SMX custom code below.


        // From sphereii - Custom Code - Counts Encumbrance up to equal bagsize for display.
        if (bindingName == "playercarrycapacity")
        {
            // Grab the Carry Capacity.
            var unlocked = ((this.player != null) ? this.playerCarryCapacityFormatter.Format((int)EffectManager.GetValue(PassiveEffects.CarryCapacity, null, 0f, this.player, null, default(FastTags), true, true, true, true, 1, true)) : "");

            // Grab the Bag size
            var totalslot = ((this.player != null) ? this.playerBagSizeFormatter.Format((int)EffectManager.GetValue(PassiveEffects.BagSize, null, 0f, this.player, null, default(FastTags), true, true, true, true, 1, true)) : "");

            // By default, we'll set then unlocked as the right value to show
            value = unlocked;

            // If nothing is in total slot, that means its not initialized yet, so just return, using the unlocked value.
            if (string.IsNullOrEmpty(totalslot))
                return true;

            // Convert the strings to a number and see which is bigger.
            if (StringParsers.ParseSInt32(unlocked) > StringParsers.ParseSInt32(totalslot))
                value = totalslot;
            else
                value = unlocked;
            return true;
        }


        // From TormentedEmu - Custom Code - Player Bag Used Slots
        if (bindingName == "playerbagusedslots")
        {
            if (XUi.IsGameRunning() && this.player != null)
            {
                value = this.player.bag.GetUsedSlotCount().ToString();
            }
            return true;
        }


        // From Sirillion - Custom Code - Player Bag Free Slots
        if (bindingName == "playerbagfreeslots")
        {
            if (XUi.IsGameRunning() && this.player != null)
            {
                var total = StringParsers.ParseSInt32(this.playerBagSizeFormatter.Format((int)EffectManager.GetValue(PassiveEffects.BagSize, null, 0f, this.player, null, default(FastTags), true, true, true, true, 1, true)));
                var used = StringParsers.ParseSInt32(this.player.bag.GetUsedSlotCount().ToString());

                var freeslots = total - used;

                value = freeslots.ToString();
            }
            return true;
        }


        // From TormentedEmu - Custom Code - Player Bag Fill Bar
        if (bindingName == "playerbagfill")
        {
            if (XUi.IsGameRunning() && this.player != null)
            {
                value = Mathf.Clamp01((float)this.player.bag.GetUsedSlotCount() / (float)this.player.bag.SlotCount).ToCultureInvariantString();
            }
            return true;
        }


        // From sphereii - Custom Code - Player Bag Fill Bar Coloring
        if (bindingName == "playerbagfillcolor")
        {
            var usedslots = ((this.player != null) ? this.player.bag.GetUsedSlotCount().ToString() : "");
            var totalslot = ((this.player != null) ? this.playerCarryCapacityFormatter.Format((int)EffectManager.GetValue(PassiveEffects.CarryCapacity, null, 0f, this.player, null, default(FastTags), true, true, true, true, 1, true)) : "");

            value = usedslots;

            if (string.IsNullOrEmpty(totalslot))
                return true;

            if (StringParsers.ParseSInt32(usedslots) > StringParsers.ParseSInt32(totalslot))
                value = usedslots;
            else
                value = totalslot;

            var used = StringParsers.ParseFloat(usedslots);
            var total = StringParsers.ParseFloat(totalslot);

            var percent = used / total;

            value = "43,124,18,255"; // Green
            if (percent > 0.75)
                value = "255,255,0,255"; // Yellow
            if (percent > 0.90)
                value = "255,144,24,255"; // Orange
            if (percent > 1)
                value = "175,30,25,255"; // Red
        }


        // From sphereii - Custom Code - "Free's" NPC Portrait for use.
        if (bindingName == "npcportrait")
        {
            if (base.xui.Dialog.Respondent != null)
            {
                value = this.NPC.NPCInfo.Portrait;
            }
            return true;
        }


        // From XUiC_SkillListWindow
        if (bindingName == "skillpointsavailable")
        {
            string v = this.pointsAvailable;
            EntityPlayerLocal entityPlayer = base.xui.playerUI.entityPlayer;
            if (XUi.IsGameRunning() && entityPlayer != null)
            {
                value = this.skillPointsAvailableFormatter.Format(v, entityPlayer.Progression.SkillPoints);
            }
            return true;
        }


        // From TormentedEmu - Custom Code - Hides entries when no skillpoints are available.
        if (bindingName == "hasskillpoint")
        {
            if (XUi.IsGameRunning() && this.player != null)
            {
                if (player.Progression.SkillPoints > 0)
                    value = "true";
                else
                    value = "false";
            }
            return true;
        }


        // From Sirillion - Custom Code - Displays weapon damage on HUD.
 /*       if (bindingName == "damageonhud")
        {
            value = (!this.itemStack.IsEmpty() ? XUiM_ItemStack.GetStatItemValueTextWithModInfo(this.itemStack, base.xui.playerUI.entityPlayer(0) : "");
            return true;
        }*/


        return false;
    }


    public override void Update(float _dt)
    {
        if (base.ViewComponent.IsVisible && Time.time > this.updateTime)
        {
            this.updateTime = Time.time + 0.25f;
            base.RefreshBindings(this.IsDirty);
            if (this.IsDirty)
            {
                this.IsDirty = false;
            }
        }
        base.Update(_dt);
    }

    public override void OnOpen()
    {
        base.OnOpen();
        this.IsDirty = true;
        this.player = base.xui.playerUI.entityPlayer;
        this.NPC = base.xui.Dialog.Respondent;
    }

    private EntityPlayer player;
    public EntityVehicle Vehicle { get; private set; }

    public EntityNPC NPC;

    private readonly CachedStringFormatter<int> playerDeathsFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<float> playerFoodFormatter = new CachedStringFormatter<float>((float _i) => _i.ToCultureInvariantString("0"));

    private readonly CachedStringFormatter<float> playerFoodFillFormatter = new CachedStringFormatter<float>((float _i) => _i.ToCultureInvariantString());

    private readonly CachedStringFormatter<int> playerItemsCraftedFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerLevelFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<float> playerLevelFillFormatter = new CachedStringFormatter<float>((float _i) => _i.ToCultureInvariantString());

    private readonly CachedStringFormatter<int> playerPvpKillsFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<float> playerWaterFormatter = new CachedStringFormatter<float>((float _i) => _i.ToCultureInvariantString("0"));

    private readonly CachedStringFormatter<float> playerWaterFillFormatter = new CachedStringFormatter<float>((float _i) => _i.ToCultureInvariantString());

    private readonly CachedStringFormatter<int> playerZombieKillsFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());


    // From CharacterWindow

    private readonly CachedStringFormatter<int> playerWaterMaxFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerFoodMaxFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerHealthFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerMaxHealthFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerStaminaFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerMaxStaminaFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerXpToNextLevelFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());

    private readonly CachedStringFormatter<int> playerCarryCapacityFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());


    // From PassiveEffects

    private readonly CachedStringFormatter<int> playerBagSizeFormatter = new CachedStringFormatter<int>((int _i) => _i.ToString());


    // From MapWindow

    private readonly CachedStringFormatter<ulong> dayFormatter = new CachedStringFormatter<ulong>((ulong _worldTime) => ValueDisplayFormatters.WorldTime(_worldTime, "{0}"));

    private readonly CachedStringFormatter<ulong> timeFormatter = new CachedStringFormatter<ulong>((ulong _worldTime) => ValueDisplayFormatters.WorldTime(_worldTime, "{1:00}:{2:00}"));


    private float updateTime;
 
    private string pointsAvailable;

    private readonly CachedStringFormatter<string, int> skillPointsAvailableFormatter = new CachedStringFormatter<string, int>((string _s, int _i) => string.Format("{1}", _s, _i));
}



