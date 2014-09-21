﻿using System;

namespace Pluton.Events {
	public class PlayerHurtEvent : HurtEvent {

		private Player _victim;
		private HitInfo _info;

		public PlayerHurtEvent(Player player, HitInfo info) : base(info) {
			_victim = player;
			_info = info;
		}

		public Player Victim {
			get {
				return _victim;
			}
		}
	}
}
