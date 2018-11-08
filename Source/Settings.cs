﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace UseBedrolls
{
	class Settings : ModSettings
	{
		public bool reclaimAggresively = false;
		public bool unclaimOnExit = true;
		public bool distanceCheck = false;
		public float distance = 100f;

		public static Settings Get()
		{
			return LoadedModManager.GetMod<UseBedrolls.Mod>().GetSettings<Settings>();
		}

		public void DoWindowContents(Rect wrect)
		{
			var options = new Listing_Standard();
			options.Begin(wrect);

			options.Label("TD.ExplainHomeBeds".Translate());
			options.CheckboxLabeled("TD.SettingReclaimAggresively".Translate(), ref reclaimAggresively, "TD.SettingReclaimAggresivelyDesc".Translate());
			options.CheckboxLabeled("TD.SettingUnClaimOnExit".Translate(), ref unclaimOnExit, "TD.SettingUnClaimOnExitDesc".Translate());

			options.GapLine();
			options.CheckboxLabeled("TD.SettingFarFromBed".Translate(), ref distanceCheck);
			if (distanceCheck)
			{
				options.Label("TD.SettingFarFromBedAmount".Translate() + $" {distance:0.}");
				distance = options.Slider(distance, 0, 300);
			}

			options.End();
		}
		
		public override void ExposeData()
		{
			Scribe_Values.Look(ref reclaimAggresively, "reclaimAggresively", false);
			Scribe_Values.Look(ref unclaimOnExit, "unclaimOnExit", true);
			Scribe_Values.Look(ref distanceCheck, "distanceCheck", true);
			Scribe_Values.Look(ref distance, "distance", 100f);
		}
	}
}