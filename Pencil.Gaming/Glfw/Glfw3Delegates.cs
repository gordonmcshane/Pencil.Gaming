#region License
// Copyright (c) 2013 Antonie Blom
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

#if USE_GLFW3
using System;
using System.Security;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Pencil.Gaming {
	internal static unsafe class GlfwDelegates {
		static GlfwDelegates() {
#if DEBUG
			Stopwatch sw = new Stopwatch();
			sw.Start();
#endif
			Type glfwInterop = (IntPtr.Size == 8) ? typeof(Glfw64) : typeof(Glfw32);
#if DEBUG
			Console.WriteLine("GLFW interop: {0}", glfwInterop.Name);
#endif
			FieldInfo[] fields = typeof(GlfwDelegates).GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
			foreach (FieldInfo fi in fields) {
				MethodInfo mi = glfwInterop.GetMethod(fi.Name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
				Delegate function = Delegate.CreateDelegate(fi.FieldType, mi);
				fi.SetValue(null, function);
			}
#if DEBUG
			sw.Stop();
			Console.WriteLine("Copying GLFW delegates took {0} milliseconds.", sw.ElapsedMilliseconds);
#endif
		}

#pragma warning disable 0649

		[SuppressUnmanagedCodeSecurity]
		internal delegate int Init();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void Terminate();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void GetVersion(out int major,out int minor,out int rev);
		[SuppressUnmanagedCodeSecurity]
		internal delegate sbyte * GetVersionString();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetErrorCallback(GlfwErrorFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate GlfwMonitorPtr * GetMonitors(out int count);
		[SuppressUnmanagedCodeSecurity]
		internal delegate GlfwMonitorPtr GetPrimaryMonitor();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void GetMonitorPos(GlfwMonitorPtr monitor,out int xpos,out int ypos);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void GetMonitorPhysicalSize(GlfwMonitorPtr monitor,out int width,out int height);
		[SuppressUnmanagedCodeSecurity]
		internal delegate sbyte * GetMonitorName(GlfwMonitorPtr monitor);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetMonitorCallback(GlfwMonitorFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate GlfwVidMode * GetVideoModes(GlfwMonitorPtr monitor,out int count);
		[SuppressUnmanagedCodeSecurity]
		internal delegate GlfwVidMode GetVideoMode(GlfwMonitorPtr monitor);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetGamma(GlfwMonitorPtr monitor,float gamma);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void GetGammaRamp(GlfwMonitorPtr monitor,out GlfwGammaRampInternal ramp);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetGammaRamp(GlfwMonitorPtr monitor,ref GlfwGammaRamp ramp);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void DefaultWindowHints();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void WindowHint(Pencil.Gaming.WindowHint target,int hint);
		[SuppressUnmanagedCodeSecurity]
		internal delegate GlfwWindowPtr CreateWindow(int width,int height,[MarshalAs(UnmanagedType.LPStr)] string title,GlfwMonitorPtr monitor,GlfwWindowPtr share);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void DestroyWindow(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate int WindowShouldClose(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowShouldClose(GlfwWindowPtr window,int value);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowTitle(GlfwWindowPtr window,[MarshalAs(UnmanagedType.LPStr)] string title);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void GetWindowPos(GlfwWindowPtr window,out int xpos,out int ypos);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowPos(GlfwWindowPtr window,int xpos,int ypos);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void GetWindowSize(GlfwWindowPtr window,out int width,out int height);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowSize(GlfwWindowPtr window,int width,int height);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void IconifyWindow(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void RestoreWindow(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void ShowWindow(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void HideWindow(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate GlfwMonitorPtr GetWindowMonitor(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate int GetWindowAttrib(GlfwWindowPtr window,int param);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowUserPointer(GlfwWindowPtr window,IntPtr pointer);
		[SuppressUnmanagedCodeSecurity]
		internal delegate IntPtr GetWindowUserPointer(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowPosCallback(GlfwWindowPtr window,GlfwWindowPosFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowSizeCallback(GlfwWindowPtr window,GlfwWindowSizeFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowCloseCallback(GlfwWindowPtr window,GlfwWindowCloseFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowRefreshCallback(GlfwWindowPtr window,GlfwWindowRefreshFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowFocusCallback(GlfwWindowPtr window,GlfwWindowFocusFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetWindowIconifyCallback(GlfwWindowPtr window,GlfwWindowIconifyFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void PollEvents();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void WaitEvents();
		[SuppressUnmanagedCodeSecurity]
		internal delegate int GetInputMode(GlfwWindowPtr window,InputMode mode);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetInputMode(GlfwWindowPtr window,InputMode mode,CursorMode value);
		[SuppressUnmanagedCodeSecurity]
		internal delegate int GetKey(GlfwWindowPtr window,Key key);
		[SuppressUnmanagedCodeSecurity]
		internal delegate int GetMouseButton(GlfwWindowPtr window,MouseButton button);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void GetCursorPos(GlfwWindowPtr window,out int xpos,out int ypos);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetCursorPos(GlfwWindowPtr window,int xpos,int ypos);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetKeyCallback(GlfwWindowPtr window,GlfwKeyFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetCharCallback(GlfwWindowPtr window,GlfwCharFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetMouseButtonCallback(GlfwWindowPtr window,GlfwMouseButtonFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetCursorPosCallback(GlfwWindowPtr window,GlfwCursorPosFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetCursorEnterCallback(GlfwWindowPtr window,GlfwCursorEnterFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetScrollCallback(GlfwWindowPtr window,GlfwScrollFun cbfun);
		[SuppressUnmanagedCodeSecurity]
		internal delegate int JoystickPresent(Joystick joy);
		[SuppressUnmanagedCodeSecurity]
		internal delegate float * GetJoystickAxes(Joystick joy, out int numaxes);
		[SuppressUnmanagedCodeSecurity]
		internal delegate byte * GetJoystickButtons(Joystick joy, out int numbuttons);
		[SuppressUnmanagedCodeSecurity]
		internal delegate sbyte * GetJoystickName(Joystick joy);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetClipboardString(GlfwWindowPtr window,[MarshalAs(UnmanagedType.LPStr)] string @string);
		[SuppressUnmanagedCodeSecurity]
		internal delegate sbyte * GetClipboardString(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate double GetTime();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SetTime(double time);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void MakeContextCurrent(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate GlfwWindowPtr GetCurrentContext();
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SwapBuffers(GlfwWindowPtr window);
		[SuppressUnmanagedCodeSecurity]
		internal delegate void SwapInterval(int interval);
		[SuppressUnmanagedCodeSecurity]
		internal delegate int ExtensionSupported([MarshalAs(UnmanagedType.LPStr)] string extension);
		[SuppressUnmanagedCodeSecurity]
		internal delegate IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPStr)] string procname);

		internal static Init glfwInit;
		internal static Terminate glfwTerminate;
		internal static GetVersion glfwGetVersion;
		internal static GetVersionString glfwGetVersionString;
		internal static SetErrorCallback glfwSetErrorCallback;
		internal static GetMonitors glfwGetMonitors;
		internal static GetPrimaryMonitor glfwGetPrimaryMonitor;
		internal static GetMonitorPos glfwGetMonitorPos;
		internal static GetMonitorPhysicalSize glfwGetMonitorPhysicalSize;
		internal static GetMonitorName glfwGetMonitorName;
		internal static SetMonitorCallback glfwSetMonitorCallback;
		internal static GetVideoModes glfwGetVideoModes;
		internal static GetVideoMode glfwGetVideoMode;
		internal static SetGamma glfwSetGamma;
		internal static GetGammaRamp glfwGetGammaRamp;
		internal static SetGammaRamp glfwSetGammaRamp;
		internal static DefaultWindowHints glfwDefaultWindowHints;
		internal static WindowHint glfwWindowHint;
		internal static CreateWindow glfwCreateWindow;
		internal static DestroyWindow glfwDestroyWindow;
		internal static WindowShouldClose glfwWindowShouldClose;
		internal static SetWindowShouldClose glfwSetWindowShouldClose;
		internal static SetWindowTitle glfwSetWindowTitle;
		internal static GetWindowPos glfwGetWindowPos;
		internal static SetWindowPos glfwSetWindowPos;
		internal static GetWindowSize glfwGetWindowSize;
		internal static SetWindowSize glfwSetWindowSize;
		internal static IconifyWindow glfwIconifyWindow;
		internal static RestoreWindow glfwRestoreWindow;
		internal static ShowWindow glfwShowWindow;
		internal static HideWindow glfwHideWindow;
		internal static GetWindowMonitor glfwGetWindowMonitor;
		internal static GetWindowAttrib glfwGetWindowAttrib;
		internal static SetWindowUserPointer glfwSetWindowUserPointer;
		internal static GetWindowUserPointer glfwGetWindowUserPointer;
		internal static SetWindowPosCallback glfwSetWindowPosCallback;
		internal static SetWindowSizeCallback glfwSetWindowSizeCallback;
		internal static SetWindowCloseCallback glfwSetWindowCloseCallback;
		internal static SetWindowRefreshCallback glfwSetWindowRefreshCallback;
		internal static SetWindowFocusCallback glfwSetWindowFocusCallback;
		internal static SetWindowIconifyCallback glfwSetWindowIconifyCallback;
		internal static PollEvents glfwPollEvents;
		internal static WaitEvents glfwWaitEvents;
		internal static GetInputMode glfwGetInputMode;
		internal static SetInputMode glfwSetInputMode;
		internal static GetKey glfwGetKey;
		internal static GetMouseButton glfwGetMouseButton;
		internal static GetCursorPos glfwGetCursorPos;
		internal static SetCursorPos glfwSetCursorPos;
		internal static SetKeyCallback glfwSetKeyCallback;
		internal static SetCharCallback glfwSetCharCallback;
		internal static SetMouseButtonCallback glfwSetMouseButtonCallback;
		internal static SetCursorPosCallback glfwSetCursorPosCallback;
		internal static SetCursorEnterCallback glfwSetCursorEnterCallback;
		internal static SetScrollCallback glfwSetScrollCallback;
		internal static JoystickPresent glfwJoystickPresent;
		internal static GetJoystickAxes glfwGetJoystickAxes;
		internal static GetJoystickButtons glfwGetJoystickButtons;
		internal static GetJoystickName glfwGetJoystickName;
		internal static SetClipboardString glfwSetClipboardString;
		internal static GetClipboardString glfwGetClipboardString;
		internal static GetTime glfwGetTime;
		internal static SetTime glfwSetTime;
		internal static MakeContextCurrent glfwMakeContextCurrent;
		internal static GetCurrentContext glfwGetCurrentContext;
		internal static SwapBuffers glfwSwapBuffers;
		internal static SwapInterval glfwSwapInterval;
		internal static ExtensionSupported glfwExtensionSupported;
		internal static GetProcAddress glfwGetProcAddress;
	}
}

#endif