using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace dllinject
{
	public sealed class DllInjector
	{
		private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

		private static DllInjector _instance;

		public static DllInjector GetInstance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DllInjector();
				}
				return _instance;
			}
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		public DllInjectionResult Inject(string sProcName, string sDllPath)
		{
			if (!File.Exists(sDllPath))
			{
				return DllInjectionResult.DllNotFound;
			}
			uint num = 0u;
			Process[] processes = Process.GetProcesses();
			for (int i = 0; i < processes.Length; i++)
			{
				if (processes[i].ProcessName == sProcName)
				{
					num = (uint)processes[i].Id;
					break;
				}
			}
			if (num == 0)
			{
				return DllInjectionResult.GameProcessNotFound;
			}
			if (!bInject(num, sDllPath))
			{
				return DllInjectionResult.InjectionFailed;
			}
			return DllInjectionResult.Success;
		}

		private unsafe bool bInject(uint pToBeInjected, string sDllPath)
		{
			IntPtr intPtr = OpenProcess(1082u, 1, pToBeInjected);
			if (intPtr == INTPTR_ZERO)
			{
				return false;
			}
			IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			if (procAddress == INTPTR_ZERO)
			{
				return false;
			}
			IntPtr intPtr2 = VirtualAllocEx(intPtr, (IntPtr)(void*)null, (IntPtr)sDllPath.Length, 12288u, 64u);
			if (intPtr2 == INTPTR_ZERO)
			{
				return false;
			}
			byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
			if (WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, 0) == 0)
			{
				return false;
			}
			if (CreateRemoteThread(intPtr, (IntPtr)(void*)null, INTPTR_ZERO, procAddress, intPtr2, 0u, (IntPtr)(void*)null) == INTPTR_ZERO)
			{
				return false;
			}
			CloseHandle(intPtr);
			return true;
		}
	}
}
