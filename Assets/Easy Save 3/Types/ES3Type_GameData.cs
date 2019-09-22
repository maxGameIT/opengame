using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("unick", "usex", "uface", "uvip", "is_guest", "guest_key", "uname", "upwd", "game_info", "zid")]
	public class ES3Type_GameData : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_GameData() : base(typeof(Master.ugame.GameData)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Master.ugame.GameData)obj;
			
			writer.WriteProperty("unick", instance.unick, ES3Type_string.Instance);
			writer.WriteProperty("usex", instance.usex, ES3Type_int.Instance);
			writer.WriteProperty("uface", instance.uface, ES3Type_int.Instance);
			writer.WriteProperty("uvip", instance.uvip, ES3Type_int.Instance);
			writer.WriteProperty("is_guest", instance.is_guest, ES3Type_bool.Instance);
			writer.WriteProperty("guest_key", instance.guest_key, ES3Type_string.Instance);
			writer.WriteProperty("uname", instance.uname, ES3Type_string.Instance);
			writer.WriteProperty("upwd", instance.upwd, ES3Type_string.Instance);
			writer.WriteProperty("game_info", instance.game_info);
			writer.WriteProperty("zid", instance.zid, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Master.ugame.GameData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "unick":
						instance.unick = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "usex":
						instance.usex = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "uface":
						instance.uface = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "uvip":
						instance.uvip = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "is_guest":
						instance.is_guest = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "guest_key":
						instance.guest_key = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "uname":
						instance.uname = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "upwd":
						instance.upwd = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "game_info":
						instance.game_info = reader.Read<LitJson.JsonData>();
						break;
					case "zid":
						instance.zid = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new Master.ugame.GameData();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_GameDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_GameDataArray() : base(typeof(Master.ugame.GameData[]), ES3Type_GameData.Instance)
		{
			Instance = this;
		}
	}
}