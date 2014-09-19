﻿using System;
using UnityEngine;

namespace Pluton {
	public class Player {

		public readonly BasePlayer basePlayer;

		public Player (BasePlayer player) {
			basePlayer = player;
		}

		public static Player Find(string nameOrSteamidOrIP) {
			return new Player(BasePlayer.Find(nameOrSteamidOrIP));
		}

		public static Player FindByGameID(ulong steamID) {
			return new Player(BasePlayer.FindByID(steamID));
		}

		public static Player FindBySteamID(string steamID) {
			return new Player(BasePlayer.FindByID(UInt64.Parse(steamID)));
		}

		public void Kick(string reason = "") {
			Network.Net.sv.Kick(basePlayer.net.connection, reason);
		}

		public void Kill() {
			var info = new HitInfo ();
			info.damageType = Rust.DamageType.Suicide;
			info.Initiator = basePlayer as BaseEntity;
			basePlayer.Die(info);
		}

		public bool Admin {
			get {
				return basePlayer.IsAdmin();
			}
		}

		public string AuthStatus {
			get {
				return basePlayer.net.connection.authStatus;
			}
		}

		public ulong GameID {
			get {
				return basePlayer.userID;
			}
		}

		public float Health {
			get {
				return basePlayer.Health();
			}
		}

		public string IP {
			get {
				return basePlayer.net.connection.ipaddress;
			}
		}

		public Vector3 Location {
			get {
				return basePlayer.transform.position;
			}
			set {
				basePlayer.transform.position.Set(value.x, value.y, value.z);
			}
		}

		public string Name {
			get {
				return basePlayer.displayName;
			}
		}

		public string OS {
			get {
				return basePlayer.net.connection.os;
			}
		}

		public int Ping {
			get {
				return basePlayer.net.connection.ping;
			}
		}

		public string SteamID {
			get {
				return basePlayer.userID.ToString();
			}
		}

		public float TimeOnline {
			get {
				return basePlayer.net.connection.connectionTime;
			}
		}

		public float X {
			get {
				return basePlayer.transform.position.x;
			}
			set {
				basePlayer.transform.position.Set(value, Y, Z);
			}
		}

		public float Y {
			get {
				return basePlayer.transform.position.y;
			}
			set {
				basePlayer.transform.position.Set(X, value, Z);
			}
		}

		public float Z {
			get {
				return basePlayer.transform.position.z;
			}
			set {
				basePlayer.transform.position.Set(X, Y, value);
			}
		}
	}
}
