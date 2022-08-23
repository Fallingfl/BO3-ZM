namespace zm
{
	internal class address
	{
		public static long baseadd = 0L;

		public static long vita;

		public static long vitamax;

		public static long ammo1;

		public static long ammo2;

		public static long ammo3;

		public static long ammo4;

		public static long ammo5;

		public static long ammo6;

		public static long ammo7;

		public static long rapid;

		public static long rapid2;

		public static long soldi;

		public static long give1;

		public static long give2;

		public static long give3;

		public static long curweap;

		public static long jump;

		public static long X;

		public static long Y;

		public static long Z;

		public static long gravita;

		public static long speed;

		public static long timescale;

		public static long perk;

		public static long perk2;

		public static long nzombie;

		public static long freeze;

		public static long[] vz = new long[30];

		public static long skull;

		public static long thirdperson;

		public static long model;

		public static long g_ai;

		public static long g_spawnai;

		public static long norecoil;

		public static long ai_meleerange;

		public static long ai_meleedamage;

		public static long sv_cheats;

		public static long round_static;

		public static long[] X_z = new long[30];

		public static long[] Y_z = new long[30];

		public static long[] Z_z = new long[30];

		public static long[] float_val = new long[8];

		public static long[] int_val = new long[3];

		public static long vita_p2;

		public static long vitamax_p2;

		public static long ammo1_p2;

		public static long ammo2_p2;

		public static long ammo3_p2;

		public static long ammo4_p2;

		public static long ammo5_p2;

		public static long ammo6_p2;

		public static long ammo7_p2;

		public static long rapid_p2;

		public static long rapid2_p2;

		public static long soldi_p2;

		public static long give1_p2;

		public static long give2_p2;

		public static long give3_p2;

		public static long curweap_p2;

		public static long perk_p2;

		public static long perk2_p2;

		public static long X_p2;

		public static long Y_p2;

		public static long Z_p2;

		public static long freeze_p2;

		public static long skull_p2;

		public static long model_p2;

		public static long thirdperson_p2;

		public static long vita_p3;

		public static long vitamax_p3;

		public static long ammo1_p3;

		public static long ammo2_p3;

		public static long ammo3_p3;

		public static long ammo4_p3;

		public static long ammo5_p3;

		public static long ammo6_p3;

		public static long ammo7_p3;

		public static long rapid_p3;

		public static long rapid2_p3;

		public static long soldi_p3;

		public static long give1_p3;

		public static long give2_p3;

		public static long give3_p3;

		public static long perk_p3;

		public static long perk2_p3;

		public static long X_p3;

		public static long Y_p3;

		public static long Z_p3;

		public static long freeze_p3;

		public static long skull_p3;

		public static long model_p3;

		public static long thirdperson_p3;

		public static long vita_p4;

		public static long vitamax_p4;

		public static long ammo1_p4;

		public static long ammo2_p4;

		public static long ammo3_p4;

		public static long ammo4_p4;

		public static long ammo5_p4;

		public static long ammo6_p4;

		public static long ammo7_p4;

		public static long rapid_p4;

		public static long rapid2_p4;

		public static long soldi_p4;

		public static long give1_p4;

		public static long give2_p4;

		public static long give3_p4;

		public static long perk_p4;

		public static long perk2_p4;

		public static long X_p4;

		public static long Y_p4;

		public static long Z_p4;

		public static long freeze_p4;

		public static long skull_p4;

		public static long model_p4;

		public static long thirdperson_p4;

		public static void setadd()
		{
			memory memory2 = new memory();
			memory2.AttackProcess("BlackOps3");
			baseadd = memory.GetBaseAddress("BlackOps3").ToInt64();
			vita = memory2.GetPointerInt(baseadd + 173325800, new long[1] { 712L }, 1);
			ammo1 = memory2.GetPointerInt(baseadd + 167008496, new long[1] { 1672L }, 1);
			thirdperson = memory2.GetPointerInt(baseadd + 167008496, new long[1] { 188L }, 1);
			vitamax = ammo1 + 91472;
			ammo2 = ammo1 + 8;
			ammo3 = ammo1 + 4;
			ammo4 = ammo1 + 12;
			ammo5 = ammo1 + 16;
			ammo6 = ammo1 - 4;
			ammo7 = ammo1 + 20;
			skull = ammo1 + 524;
			rapid = ammo1 - 1588;
			rapid2 = ammo1 - 1560;
			soldi = ammo1 + 92156;
			give1 = ammo1 - 736;
			give2 = ammo1 - 640;
			give3 = ammo1 - 592;
			curweap = baseadd + 57110992;
			jump = baseadd + 50829876;
			gravita = baseadd + 397292896;
			speed = baseadd + 397198336;
			X = ammo1 - 1624;
			Y = X + 4;
			Z = X + 8;
			timescale = baseadd + 397387136;
			nzombie = baseadd + 393193424;
			for (int i = 0; i < vz.Length; i++)
			{
				vz[i] = vita + 30528 + 1272 * i;
			}
			perk = ammo1 + 1132;
			perk2 = ammo1 + 1140;
			freeze = ammo1 + 92508;
			model = ammo1 - 984;
			g_ai = baseadd + 397200576;
			g_spawnai = baseadd + 397200736;
			norecoil = baseadd + 18602059;
			ai_meleerange = baseadd + 397135080;
			ai_meleedamage = baseadd + 397217696;
			sv_cheats = baseadd + 397182336;
			for (int j = 0; j < X_z.Length; j++)
			{
				X_z[j] = vz[0] - 152 + 1272 * j;
				Y_z[j] = X_z[j] + 4;
				Z_z[j] = X_z[j] + 8;
			}
			float_val[0] = baseadd + 397269856;
			float_val[1] = baseadd + 397213696;
			float_val[2] = timescale;
			float_val[3] = baseadd + 397236896;
			float_val[4] = baseadd + 397269376;
			float_val[5] = baseadd + 397526976;
			float_val[6] = baseadd + 397527616;
			float_val[7] = baseadd + 397507936;
			int_val[0] = baseadd + 397207616;
			int_val[1] = speed;
			int_val[2] = baseadd + 397214496;
			vita_p2 = vita + 1272;
			vitamax_p2 = vitamax + 94704;
			ammo1_p2 = ammo1 + 94704;
			ammo2_p2 = ammo2 + 94704;
			ammo3_p2 = ammo3 + 94704;
			ammo4_p2 = ammo4 + 94704;
			ammo5_p2 = ammo5 + 94704;
			ammo6_p2 = ammo6 + 94704;
			ammo7_p2 = ammo7 + 94704;
			rapid_p2 = rapid + 94704;
			rapid2_p2 = rapid2 + 94704;
			soldi_p2 = soldi + 94704;
			give1_p2 = give1 + 94704;
			give2_p2 = give2 + 94704;
			give3_p2 = give3 + 94704;
			X_p2 = X + 94704;
			Y_p2 = Y + 94704;
			Z_p2 = Z + 94704;
			perk_p2 = perk + 94704;
			perk2_p2 = perk2 + 94704;
			freeze_p2 = freeze + 94704;
			skull_p2 = skull + 94704;
			model_p2 = model + 94704;
			thirdperson_p2 = thirdperson + 94704;
			vita_p3 = vita + 2544;
			vitamax_p3 = vitamax + 189408;
			ammo1_p3 = ammo1 + 189408;
			ammo2_p3 = ammo2 + 189408;
			ammo3_p3 = ammo3 + 189408;
			ammo4_p3 = ammo4 + 189408;
			ammo5_p3 = ammo5 + 189408;
			ammo6_p3 = ammo6 + 189408;
			ammo7_p3 = ammo7 + 189408;
			rapid_p3 = rapid + 189408;
			rapid2_p3 = rapid2 + 189408;
			soldi_p3 = soldi + 189408;
			give1_p3 = give1 + 189408;
			give2_p3 = give2 + 189408;
			give3_p3 = give3 + 189408;
			X_p3 = X + 189408;
			Y_p3 = Y + 189408;
			Z_p3 = Z + 189408;
			perk_p3 = perk + 189408;
			perk2_p3 = perk2 + 189408;
			freeze_p3 = freeze + 189408;
			skull_p3 = skull + 189408;
			model_p3 = model + 189408;
			thirdperson_p3 = thirdperson + 189408;
			vita_p4 = vita + 3816;
			vitamax_p4 = vitamax + 284112;
			ammo1_p4 = ammo1 + 284112;
			ammo2_p4 = ammo2 + 284112;
			ammo3_p4 = ammo3 + 284112;
			ammo4_p4 = ammo4 + 284112;
			ammo5_p4 = ammo5 + 284112;
			ammo6_p4 = ammo6 + 284112;
			ammo7_p4 = ammo7 + 284112;
			rapid_p4 = rapid + 284112;
			rapid2_p4 = rapid2 + 284112;
			soldi_p4 = soldi + 284112;
			give1_p4 = give1 + 284112;
			give2_p4 = give2 + 284112;
			give3_p4 = give3 + 284112;
			X_p4 = X + 284112;
			Y_p4 = Y + 284112;
			Z_p4 = Z + 284112;
			perk_p4 = perk + 284112;
			perk2_p4 = perk2 + 284112;
			freeze_p4 = freeze + 284112;
			skull_p4 = skull + 284112;
			model_p4 = model + 284112;
			thirdperson_p4 = thirdperson + 284112;
		}
	}
}
