﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using MenuFramework;

namespace Roleplay.Client.UI.Menus.CharacterEditor.CustomizeMenu
{
    internal class MPEyeSelector : MenuItemHorSelector<int>
	{
		private CharacterEditorMenu Root;

		public MPEyeSelector( CharacterEditorMenu root ) {
			Root = root;
			Title = "Eye color";
			Type = MenuItemHorizontalSelectorType.Number;
			wrapAround = true;
			minState = 0;
			maxState = 63;
			state = 0;
			OnChange = SetNewAppearance;
			OnSelect = new Action<MenuItem>( ( menuItem ) => { root.Editor.lookAtHead(); ; } );
		}

		private void SetNewAppearance( int value, MenuItemHorSelector<int> item ) {
			API.SetPedEyeColor( Game.PlayerPed.Handle, value );
			Root.AdditionalSaveData.EyeColor = (byte)value;
		}
	}
}