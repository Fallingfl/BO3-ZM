using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace zm
{
	public class memory
	{
		public const uint PROCESS_VM_READ = 16u;

		public const uint PROCESS_VM_WRITE = 32u;

		public const uint PROCESS_VM_OPERATION = 8u;

		public const uint PAGE_READWRITE = 4u;

		private Process CurProcess;

		private IntPtr ProcessHandle;

		private string ProcessName;

		private int ProcessID;

		public IntPtr BaseModule;

		public const uint MEM_COMMIT = 4096u;

		public const uint MEM_RESERVE = 8192u;

		public const uint MEM_RELEASE = 32768u;

		public const uint PAGE_EXECUTE_READWRITE = 64u;

		private static byte[] callBytes;

		private static byte[] commandBytes;

		private static IntPtr commandAddress = IntPtr.Zero;

		private static IntPtr FuncAddress = IntPtr.Zero;

		private static int bytes = 0;

		public static string a;

		public static int b;

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint dwAccess, bool inherit, int pid);

		[DllImport("kernel32.dll")]
		public static extern bool CloseHandle(IntPtr handle);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, [In][Out] byte[] lpBuffer, ulong dwSize, out IntPtr lpNumberOfBytesRead);

		[DllImport("kernel32.dll")]
		public static extern bool WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, [In][Out] byte[] lpBuffer, ulong dwSize, out IntPtr lpNumberOfBytesWritten);

		[DllImport("kernel32", SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

		~memory()
		{
			if (ProcessHandle != IntPtr.Zero)
			{
				CloseHandle(ProcessHandle);
			}
		}

		public bool AttackProcess(string _ProcessName)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(_ProcessName);
				if (processesByName.Length != 0)
				{
					BaseModule = processesByName[0].MainModule.BaseAddress;
					CurProcess = processesByName[0];
					ProcessID = processesByName[0].Id;
					ProcessName = _ProcessName;
					ProcessHandle = OpenProcess(56u, inherit: false, ProcessID);
					if (ProcessHandle != IntPtr.Zero)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool IsOpen()
		{
			if (ProcessName == string.Empty)
			{
				return false;
			}
			if (AttackProcess(ProcessName))
			{
				return true;
			}
			return false;
		}

		internal static IntPtr GetBaseAddress(string ProcessName)
		{
			try
			{
				return Process.GetProcessesByName(ProcessName)[0].MainModule.BaseAddress;
			}
			catch
			{
				return IntPtr.Zero;
			}
		}

		public long FindPattern(long startAddress, long endAddress, string pattern, string mask)
		{
			byte[] array = new byte[endAddress - startAddress];
			ReadProcessMemory(ProcessHandle, startAddress, array, (ulong)array.Length, out var _);
			for (long num = 0L; num < array.Length; num++)
			{
				for (int i = 0; i < pattern.Length && (array[num + i] == pattern[i] || mask[i] == '?'); i++)
				{
					if (i == pattern.Length - 1)
					{
						return startAddress + num;
					}
				}
			}
			return -1L;
		}

		[DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
		protected static extern bool ReadProcessMemory2(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesRead);

		public IntPtr AobScan(IntPtr Base, uint _Range, string Signature, int Instance)
		{
			if (Signature != string.Empty)
			{
				int num = -1;
				byte[] array = HX2Bts(Signature);
				byte[] array2 = new byte[_Range];
				ReadProcessMemory2(ProcessHandle, Base, array2, _Range, 0);
				int num2 = 0;
				int i = 0;
				int num3 = ((array.Length < 32) ? array.Length : 32);
				int[] array3 = new int[256];
				int num4 = num3;
				while (num4-- > 0)
				{
					if (array[num4] == 63)
					{
						num2 |= 1 << num3 - num4 - 1;
					}
				}
				if (num2 != 0)
				{
					int num5 = array3.Length;
					while (num5-- > 0)
					{
						array3[num5] = num2;
					}
				}
				num2 = 1;
				int num6 = num3 - 1;
				while (num6 >= 0)
				{
					array3[array[num6]] |= num2;
					num6--;
					num2 <<= 1;
				}
				int num7;
				for (; i <= array2.Length - array.Length; i += num7)
				{
					num2 = array.Length - 1;
					num7 = array.Length;
					int num8;
					for (num8 = -1; num8 != 0; num8 <<= 1)
					{
						num8 &= array3[array2[i + num2]];
						if (num8 != 0)
						{
							if (num2 == 0)
							{
								num++;
								if (num == Instance)
								{
									return Base + i;
								}
								i += 2;
							}
							num7 = num2;
						}
						num2--;
					}
				}
			}
			return IntPtr.Zero;
		}

		private static byte[] HX2Bts(string HXS)
		{
			HXS = Regex.Replace(HXS, "[^a-fA-F0-9?]", "");
			if (HXS.Length % 2 != 0)
			{
				HXS = HXS.Substring(0, HXS.Length - 1);
			}
			byte[] array = new byte[HXS.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)((HXS.Substring(i * 2, 2) != "??") ? byte.Parse(HXS.Substring(i * 2, 2), NumberStyles.HexNumber) : 63);
			}
			return array;
		}

		[DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		private static extern bool WriteProcessMemory2(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, [Out] int lpNumberOfBytesWritten);

		[DllImport("kernel32")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);

		public int ReadPointerInt(long add, long[] offsets, int level)
		{
			long lpBaseAddress = add;
			for (int i = 0; i < level; i++)
			{
				lpBaseAddress = ReadInt64(lpBaseAddress) + offsets[i];
			}
			return ReadString(lpBaseAddress);
		}

		public long GetPointerInt(long add, long[] offsets, int level)
		{
			long num = add;
			for (int i = 0; i < level; i++)
			{
				num = ReadInt64(num) + offsets[i];
			}
			return num;
		}

		public int ReadString(long _lpBaseAddress)
		{
			byte[] array = new byte[4];
			ReadProcessMemory(ProcessHandle, _lpBaseAddress, array, 4uL, out var _);
			return BitConverter.ToInt32(array, 0);
		}

		public uint ReadUInt32(long _lpBaseAddress)
		{
			byte[] array = new byte[4];
			ReadProcessMemory(ProcessHandle, _lpBaseAddress, array, 4uL, out var _);
			return BitConverter.ToUInt32(array, 0);
		}

		public long ReadInt64(long _lpBaseAddress)
		{
			byte[] array = new byte[8];
			ReadProcessMemory(ProcessHandle, _lpBaseAddress, array, 8uL, out var _);
			return BitConverter.ToInt64(array, 0);
		}

		public ulong ReadUInt64(long _lpBaseAddress)
		{
			byte[] array = new byte[8];
			ReadProcessMemory(ProcessHandle, _lpBaseAddress, array, 8uL, out var _);
			return BitConverter.ToUInt64(array, 0);
		}

		public float ReadFloat(long _lpBaseAddress)
		{
			byte[] array = new byte[4];
			ReadProcessMemory(ProcessHandle, _lpBaseAddress, array, 4uL, out var _);
			return BitConverter.ToSingle(array, 0);
		}

		public string ReadString(long _lpBaseAddress, ulong _Size)
		{
			byte[] lpBuffer = new byte[_Size];
			ReadProcessMemory(ProcessHandle, _lpBaseAddress, lpBuffer, _Size, out var _);
			return Encoding.UTF8.GetString(lpBuffer);
		}

		public void WriteMemory(long MemoryAddress, byte[] Buffer)
		{
			VirtualProtectEx(ProcessHandle, (IntPtr)MemoryAddress, (uint)Buffer.Length, 4u, out var _);
			WriteProcessMemory(ProcessHandle, MemoryAddress, Buffer, (uint)Buffer.Length, out var _);
		}

		public void WriteInt32(long _lpBaseAddress, int _Value)
		{
			byte[] buffer = BitConverter.GetBytes(_Value);
			WriteMemory(_lpBaseAddress, buffer);
		}

		public void WriteInt64(long _lpBaseAddress, long _Value)
		{
			byte[] buffer = BitConverter.GetBytes(_Value);
			WriteMemory(_lpBaseAddress, buffer);
		}

		public void WriteProtectedFloat(long _lpBaseAddress, float _Value)
		{
			IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
			byte[] array = BitConverter.GetBytes(ReadString(_lpBaseAddress));
			byte[] array2 = BitConverter.GetBytes(_Value);
			byte b = Convert.ToByte(array2[0] ^ array[0]);
			byte b2 = Convert.ToByte(array2[1] ^ array[1]);
			byte b3 = Convert.ToByte(array2[2] ^ array[2]);
			byte b4 = Convert.ToByte(array2[3] ^ array[3]);
			byte b5 = Convert.ToByte(array2[0] ^ b);
			byte b6 = Convert.ToByte(array2[1] ^ b2);
			byte b7 = Convert.ToByte(array2[2] ^ b3);
			byte b8 = Convert.ToByte(array2[3] ^ b4);
			byte[] array3 = new byte[8]
			{
				array2[0],
				array2[1],
				array2[2],
				array2[3],
				b5,
				b6,
				b7,
				b8
			};
			WriteProcessMemory(ProcessHandle, _lpBaseAddress, array3, (uint)array3.Length, out lpNumberOfBytesWritten);
		}

		public void WriteProtectedInt(long _lpBaseAddress, int _Value)
		{
			IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
			byte[] array = BitConverter.GetBytes(ReadString(_lpBaseAddress));
			byte[] array2 = BitConverter.GetBytes(_Value);
			byte b = Convert.ToByte(array2[0] ^ array[0]);
			byte b2 = Convert.ToByte(array2[1] ^ array[1]);
			byte b3 = Convert.ToByte(array2[0] ^ array[2]);
			byte b4 = Convert.ToByte(array2[1] ^ array[3]);
			byte b5 = Convert.ToByte(array2[0] ^ b);
			byte b6 = Convert.ToByte(array2[1] ^ b2);
			byte b7 = Convert.ToByte(array2[0] ^ b3);
			byte b8 = Convert.ToByte(array2[1] ^ b4);
			byte[] array3 = new byte[8]
			{
				array2[0],
				array2[1],
				array2[2],
				array2[3],
				b5,
				b6,
				b7,
				b8
			};
			WriteProcessMemory(ProcessHandle, _lpBaseAddress, array3, (uint)array3.Length, out lpNumberOfBytesWritten);
		}

		public void WriteUInt32(long _lpBaseAddress, uint _Value)
		{
			byte[] buffer = BitConverter.GetBytes(_Value);
			WriteMemory(_lpBaseAddress, buffer);
		}

		public void WriteFloat(long _lpBaseAddress, float _Value)
		{
			byte[] buffer = BitConverter.GetBytes(_Value);
			WriteMemory(_lpBaseAddress, buffer);
		}

		public void WriteByte(long _lpBaseAddress, byte _Value)
		{
			byte[] array = BitConverter.GetBytes(_Value);
			IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
			WriteProcessMemory(ProcessHandle, _lpBaseAddress, array, (uint)(array.Length - 1), out lpNumberOfBytesWritten);
		}

		public void WriteXBytes(long _lpBaseAddress, byte[] _Value)
		{
			IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
			WriteProcessMemory(ProcessHandle, _lpBaseAddress, _Value, (uint)_Value.Length, out lpNumberOfBytesWritten);
		}

		public void WriteString(long Address, string Text)
		{
			byte[] lpBuffer = new ASCIIEncoding().GetBytes(Text);
			IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
			WriteProcessMemory(ProcessHandle, Address, lpBuffer, (uint)ReadString(Address, 1024uL).Length, out lpNumberOfBytesWritten);
		}

		public void WriteNOP(long Address)
		{
			byte[] array = new byte[5] { 144, 144, 144, 144, 144 };
			IntPtr lpNumberOfBytesWritten = IntPtr.Zero;
			WriteProcessMemory(ProcessHandle, Address, array, (uint)array.Length, out lpNumberOfBytesWritten);
		}
	}
}
