// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2008 Novell, Inc.
//
// Authors:
//	Andreia Gaita (shana@jitted.com)
//

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Mono.WebKit
{	
	[StructLayout(LayoutKind.Sequential)]
	internal struct XAnyEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XKeyEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		root;
		internal IntPtr		subwindow;
		internal IntPtr		time;
		internal int		x;
		internal int		y;
		internal int		x_root;
		internal int		y_root;
		internal int		state;
		internal int		keycode;
		internal bool		same_screen;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XButtonEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		root;
		internal IntPtr		subwindow;
		internal IntPtr		time;
		internal int		x;
		internal int		y;
		internal int		x_root;
		internal int		y_root;
		internal int		state;
		internal int		button;
		internal bool		same_screen;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XMotionEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		root;
		internal IntPtr		subwindow;
		internal IntPtr		time;
		internal int		x;
		internal int		y;
		internal int		x_root;
		internal int		y_root;
		internal int		state;
		internal byte		is_hint;
		internal bool		same_screen;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XCrossingEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		root;
		internal IntPtr		subwindow;
		internal IntPtr		time;
		internal int		x;
		internal int		y;
		internal int		x_root;
		internal int		y_root;
		internal NotifyMode	mode;
		internal NotifyDetail	detail;
		internal bool		same_screen;
		internal bool		focus;
		internal int		state;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XFocusChangeEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal int		mode;
		internal NotifyDetail	detail;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XKeymapEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal byte		key_vector0;
		internal byte		key_vector1;
		internal byte		key_vector2;
		internal byte		key_vector3;
		internal byte		key_vector4;
		internal byte		key_vector5;
		internal byte		key_vector6;
		internal byte		key_vector7;
		internal byte		key_vector8;
		internal byte		key_vector9;
		internal byte		key_vector10;
		internal byte		key_vector11;
		internal byte		key_vector12;
		internal byte		key_vector13;
		internal byte		key_vector14;
		internal byte		key_vector15;
		internal byte		key_vector16;
		internal byte		key_vector17;
		internal byte		key_vector18;
		internal byte		key_vector19;
		internal byte		key_vector20;
		internal byte		key_vector21;
		internal byte		key_vector22;
		internal byte		key_vector23;
		internal byte		key_vector24;
		internal byte		key_vector25;
		internal byte		key_vector26;
		internal byte		key_vector27;
		internal byte		key_vector28;
		internal byte		key_vector29;
		internal byte		key_vector30;
		internal byte		key_vector31;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XExposeEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal int		x;
		internal int		y;
		internal int		width;
		internal int		height;
		internal int		count;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XGraphicsExposeEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		drawable;
		internal int		x;
		internal int		y;
		internal int		width;
		internal int		height;
		internal int		count;
		internal int		major_code;
		internal int		minor_code;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XNoExposeEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		drawable;
		internal int		major_code;
		internal int		minor_code;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XVisibilityEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal int		state;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XCreateWindowEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		parent;
		internal IntPtr		window;
		internal int		x;
		internal int		y;
		internal int		width;
		internal int		height;
		internal int		border_width;
		internal bool		override_redirect;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XDestroyWindowEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		xevent;
		internal IntPtr		window;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XUnmapEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		xevent;
		internal IntPtr		window;
		internal bool		from_configure;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XMapEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		xevent;
		internal IntPtr		window;
		internal bool		override_redirect;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XMapRequestEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		parent;
		internal IntPtr		window;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XReparentEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		xevent;
		internal IntPtr		window;
		internal IntPtr		parent;
		internal int		x;
		internal int		y;
		internal bool		override_redirect;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XConfigureEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		xevent;
		internal IntPtr		window;
		internal int		x;
		internal int		y;
		internal int		width;
		internal int		height;
		internal int		border_width;
		internal IntPtr		above;
		internal bool		override_redirect;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XGravityEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		xevent;
		internal IntPtr		window;
		internal int		x;
		internal int		y;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XResizeRequestEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal int		width;
		internal int		height;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XConfigureRequestEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		parent;
		internal IntPtr		window;
		internal int		x;
		internal int		y;
		internal int		width;
		internal int		height;
		internal int		border_width;
		internal IntPtr		above;
		internal int		detail;
		internal IntPtr		value_mask;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XCirculateEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		xevent;
		internal IntPtr		window;
		internal int		place;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XCirculateRequestEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		parent;
		internal IntPtr		window;
		internal int		place;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XPropertyEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		atom;
		internal IntPtr		time;
		internal int		state;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XSelectionClearEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		selection;
		internal IntPtr		time;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XSelectionRequestEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		owner;
		internal IntPtr		requestor;
		internal IntPtr		selection;
		internal IntPtr		target;
		internal IntPtr		property;
		internal IntPtr		time;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XSelectionEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		requestor;
		internal IntPtr		selection;
		internal IntPtr		target;
		internal IntPtr		property;
		internal IntPtr		time;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XColormapEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		colormap;
		internal bool		c_new;
		internal int		state;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XClientMessageEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal IntPtr		message_type;
		internal int		format;
		internal IntPtr		ptr1;
		internal IntPtr		ptr2;
		internal IntPtr		ptr3;
		internal IntPtr		ptr4;
		internal IntPtr		ptr5;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XMappingEvent {
		internal XEventName	type;
		internal IntPtr		serial;
		internal bool		send_event;
		internal IntPtr		display;
		internal IntPtr		window;
		internal int		request;
		internal int		first_keycode;
		internal int		count;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XErrorEvent {
		internal XEventName	type;
		internal IntPtr		display;
		internal IntPtr		resourceid;
		internal IntPtr		serial;
		internal byte		error_code;
		internal XRequest	request_code;
		internal byte		minor_code;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct XEventPad {
		internal IntPtr pad0;
		internal IntPtr pad1;
		internal IntPtr pad2;
		internal IntPtr pad3;
		internal IntPtr pad4;
		internal IntPtr pad5;
		internal IntPtr pad6;
		internal IntPtr pad7;
		internal IntPtr pad8;
		internal IntPtr pad9;
		internal IntPtr pad10;
		internal IntPtr pad11;
		internal IntPtr pad12;
		internal IntPtr pad13;
		internal IntPtr pad14;
		internal IntPtr pad15;
		internal IntPtr pad16;
		internal IntPtr pad17;
		internal IntPtr pad18;
		internal IntPtr pad19;
		internal IntPtr pad20;
		internal IntPtr pad21;
		internal IntPtr pad22;
		internal IntPtr pad23;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct XEvent {
		[ FieldOffset(0) ] internal XEventName type;
		[ FieldOffset(0) ] internal XAnyEvent AnyEvent;
		[ FieldOffset(0) ] internal XKeyEvent KeyEvent;
		[ FieldOffset(0) ] internal XButtonEvent ButtonEvent;
		[ FieldOffset(0) ] internal XMotionEvent MotionEvent;
		[ FieldOffset(0) ] internal XCrossingEvent CrossingEvent;
		[ FieldOffset(0) ] internal XFocusChangeEvent FocusChangeEvent;
		[ FieldOffset(0) ] internal XExposeEvent ExposeEvent;
		[ FieldOffset(0) ] internal XGraphicsExposeEvent GraphicsExposeEvent;
		[ FieldOffset(0) ] internal XNoExposeEvent NoExposeEvent;
		[ FieldOffset(0) ] internal XVisibilityEvent VisibilityEvent;
		[ FieldOffset(0) ] internal XCreateWindowEvent CreateWindowEvent;
		[ FieldOffset(0) ] internal XDestroyWindowEvent DestroyWindowEvent;
		[ FieldOffset(0) ] internal XUnmapEvent UnmapEvent;
		[ FieldOffset(0) ] internal XMapEvent MapEvent;
		[ FieldOffset(0) ] internal XMapRequestEvent MapRequestEvent;
		[ FieldOffset(0) ] internal XReparentEvent ReparentEvent;
		[ FieldOffset(0) ] internal XConfigureEvent ConfigureEvent;
		[ FieldOffset(0) ] internal XGravityEvent GravityEvent;
		[ FieldOffset(0) ] internal XResizeRequestEvent ResizeRequestEvent;
		[ FieldOffset(0) ] internal XConfigureRequestEvent ConfigureRequestEvent;
		[ FieldOffset(0) ] internal XCirculateEvent CirculateEvent;
		[ FieldOffset(0) ] internal XCirculateRequestEvent CirculateRequestEvent;
		[ FieldOffset(0) ] internal XPropertyEvent PropertyEvent;
		[ FieldOffset(0) ] internal XSelectionClearEvent SelectionClearEvent;
		[ FieldOffset(0) ] internal XSelectionRequestEvent SelectionRequestEvent;
		[ FieldOffset(0) ] internal XSelectionEvent SelectionEvent;
		[ FieldOffset(0) ] internal XColormapEvent ColormapEvent;
		[ FieldOffset(0) ] internal XClientMessageEvent ClientMessageEvent;
		[ FieldOffset(0) ] internal XMappingEvent MappingEvent;
		[ FieldOffset(0) ] internal XErrorEvent ErrorEvent;
		[ FieldOffset(0) ] internal XKeymapEvent KeymapEvent;

		//[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=24)]
		//[ FieldOffset(0) ] internal int[] pad;
		[ FieldOffset(0) ] internal XEventPad Pad;
		public override string ToString() {
			switch (type)
			{
				case XEventName.ButtonPress:
				case XEventName.ButtonRelease:
					return ToString (ButtonEvent);
				case XEventName.CirculateNotify:
				case XEventName.CirculateRequest:
					return ToString (CirculateEvent);
				case XEventName.ClientMessage:
					return ToString (ClientMessageEvent);
				case XEventName.ColormapNotify:
					return ToString (ColormapEvent);
				case XEventName.ConfigureNotify:
					return ToString (ConfigureEvent);
				case XEventName.ConfigureRequest:
					return ToString (ConfigureRequestEvent);
				case XEventName.CreateNotify:
					return ToString (CreateWindowEvent);
				case XEventName.DestroyNotify:
					return ToString (DestroyWindowEvent);
				case XEventName.Expose:
					return ToString (ExposeEvent);
				case XEventName.FocusIn:
				case XEventName.FocusOut:
					return ToString (FocusChangeEvent);
				case XEventName.GraphicsExpose:
					return ToString (GraphicsExposeEvent);
				case XEventName.GravityNotify:
					return ToString (GravityEvent);
				case XEventName.KeymapNotify:
					return ToString (KeymapEvent);
				case XEventName.MapNotify:
					return ToString (MapEvent);
				case XEventName.MappingNotify:
					return ToString (MappingEvent);
				case XEventName.MapRequest:
					return ToString (MapRequestEvent);
				case XEventName.MotionNotify:
					return ToString (MotionEvent);
				case XEventName.NoExpose:
					return ToString (NoExposeEvent);
				case XEventName.PropertyNotify:
					return ToString (PropertyEvent);
				case XEventName.ReparentNotify:
					return ToString (ReparentEvent);
				case XEventName.ResizeRequest:
					return ToString (ResizeRequestEvent);
				case XEventName.SelectionClear:
					return ToString (SelectionClearEvent);
				case XEventName.SelectionNotify:
					return ToString (SelectionEvent);
				case XEventName.SelectionRequest:
					return ToString (SelectionRequestEvent);
				case XEventName.UnmapNotify:
					return ToString (UnmapEvent);
				case XEventName.VisibilityNotify:
					return ToString (VisibilityEvent);
				case XEventName.EnterNotify:
				case XEventName.LeaveNotify:
					return ToString (CrossingEvent);
				default:
					return type.ToString ();
			}
		}
		
		public static string ToString (object ev)
		{
			string result = string.Empty;
			Type type = ev.GetType ();
			System.Reflection.FieldInfo [] fields = type.GetFields (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Instance);
			for (int i = 0; i < fields.Length; i++) {
				if (result != string.Empty) {
					result += ", ";
				}
				object value = fields [i].GetValue (ev);
				if (fields[i].FieldType == typeof(IntPtr))
					result += String.Format (fields [i].Name + "= 0x{0:x}", (value == null ? 0 : ((IntPtr)value).ToInt32()));
				else
					result += fields [i].Name + "=" + (value == null ? "<null>" : value.ToString ());
			}
			return type.Name + " (" + result + ")";
		}
	}
	
	internal enum XEventName {
		KeyPress                = 2,
		KeyRelease              = 3,
		ButtonPress             = 4,
		ButtonRelease           = 5,
		MotionNotify            = 6,
		EnterNotify             = 7,
		LeaveNotify             = 8,
		FocusIn                 = 9,
		FocusOut                = 10,
		KeymapNotify            = 11,
		Expose                  = 12,
		GraphicsExpose          = 13,
		NoExpose                = 14,
		VisibilityNotify        = 15,
		CreateNotify            = 16,
		DestroyNotify           = 17,
		UnmapNotify             = 18,
		MapNotify               = 19,
		MapRequest              = 20,
		ReparentNotify          = 21,
		ConfigureNotify         = 22,
		ConfigureRequest        = 23,
		GravityNotify           = 24,
		ResizeRequest           = 25,
		CirculateNotify         = 26,
		CirculateRequest        = 27,
		PropertyNotify          = 28,
		SelectionClear          = 29,
		SelectionRequest        = 30,
		SelectionNotify         = 31,
		ColormapNotify          = 32,
		ClientMessage		= 33,
		MappingNotify		= 34,

		LASTEvent
	}

	internal enum NotifyMode {
		NotifyNormal		= 0,
		NotifyGrab		= 1,
		NotifyUngrab		= 2
	}

	internal enum NotifyDetail {
		NotifyAncestor		= 0,
		NotifyVirtual		= 1,
		NotifyInferior		= 2,
		NotifyNonlinear		= 3,
		NotifyNonlinearVirtual	= 4,
		NotifyPointer		= 5,
		NotifyPointerRoot	= 6,
		NotifyDetailNone	= 7
	}
	
	internal enum XRequest : byte {
		X_CreateWindow			= 1,
		X_ChangeWindowAttributes	= 2,
		X_GetWindowAttributes           = 3,
		X_DestroyWindow                 = 4,
		X_DestroySubwindows             = 5,
		X_ChangeSaveSet                 = 6,
		X_ReparentWindow                = 7,
		X_MapWindow                     = 8,
		X_MapSubwindows                 = 9,
		X_UnmapWindow			= 10,
		X_UnmapSubwindows		= 11,
		X_ConfigureWindow		= 12,
		X_CirculateWindow		= 13,
		X_GetGeometry			= 14,
		X_QueryTree			= 15,
		X_InternAtom			= 16,
		X_GetAtomName			= 17,
		X_ChangeProperty		= 18,
		X_DeleteProperty		= 19,
		X_GetProperty			= 20,
		X_ListProperties		= 21,
		X_SetSelectionOwner		= 22,
		X_GetSelectionOwner		= 23,
		X_ConvertSelection		= 24,
		X_SendEvent			= 25,
		X_GrabPointer			= 26,
		X_UngrabPointer			= 27,
		X_GrabButton			= 28,
		X_UngrabButton			= 29,
		X_ChangeActivePointerGrab	= 30,
		X_GrabKeyboard			= 31,
		X_UngrabKeyboard		= 32,
		X_GrabKey			= 33,
		X_UngrabKey			= 34,
		X_AllowEvents			= 35,
		X_GrabServer			= 36,
		X_UngrabServer			= 37,
		X_QueryPointer			= 38,
		X_GetMotionEvents		= 39,
		X_TranslateCoords		= 40,
		X_WarpPointer			= 41,
		X_SetInputFocus			= 42,
		X_GetInputFocus			= 43,
		X_QueryKeymap			= 44,
		X_OpenFont			= 45,
		X_CloseFont			= 46,
		X_QueryFont			= 47,
		X_QueryTextExtents		= 48,
		X_ListFonts			= 49,
		X_ListFontsWithInfo		= 50,
		X_SetFontPath			= 51,
		X_GetFontPath			= 52,
		X_CreatePixmap			= 53,
		X_FreePixmap			= 54,
		X_CreateGC			= 55,
		X_ChangeGC			= 56,
		X_CopyGC			= 57,
		X_SetDashes			= 58,
		X_SetClipRectangles		= 59,
		X_FreeGC			= 60,
		X_ClearArea			= 61,
		X_CopyArea			= 62,
		X_CopyPlane			= 63,
		X_PolyPoint			= 64,
		X_PolyLine			= 65,
		X_PolySegment			= 66,
		X_PolyRectangle			= 67,
		X_PolyArc			= 68,
		X_FillPoly			= 69,
		X_PolyFillRectangle		= 70,
		X_PolyFillArc			= 71,
		X_PutImage			= 72,
		X_GetImage			= 73,
		X_PolyText8			= 74,
		X_PolyText16			= 75,
		X_ImageText8			= 76,
		X_ImageText16			= 77,
		X_CreateColormap		= 78,
		X_FreeColormap			= 79,
		X_CopyColormapAndFree		= 80,
		X_InstallColormap		= 81,
		X_UninstallColormap		= 82,
		X_ListInstalledColormaps	= 83,
		X_AllocColor			= 84,
		X_AllocNamedColor		= 85,
		X_AllocColorCells		= 86,
		X_AllocColorPlanes		= 87,
		X_FreeColors			= 88,
		X_StoreColors			= 89,
		X_StoreNamedColor		= 90,
		X_QueryColors			= 91,
		X_LookupColor			= 92,
		X_CreateCursor			= 93,
		X_CreateGlyphCursor		= 94,
		X_FreeCursor			= 95,
		X_RecolorCursor			= 96,
		X_QueryBestSize			= 97,
		X_QueryExtension		= 98,
		X_ListExtensions		= 99,
		X_ChangeKeyboardMapping		= 100,
		X_GetKeyboardMapping		= 101,
		X_ChangeKeyboardControl		= 102,
		X_GetKeyboardControl		= 103,
		X_Bell				= 104,
		X_ChangePointerControl		= 105,
		X_GetPointerControl		= 106,
		X_SetScreenSaver		= 107,
		X_GetScreenSaver		= 108,
		X_ChangeHosts			= 109,
		X_ListHosts			= 110,
		X_SetAccessControl		= 111,
		X_SetCloseDownMode		= 112,
		X_KillClient			= 113,
		X_RotateProperties		= 114,
		X_ForceScreenSaver		= 115,
		X_SetPointerMapping		= 116,
		X_GetPointerMapping		= 117,
		X_SetModifierMapping		= 118,
		X_GetModifierMapping		= 119,
		X_NoOperation			= 127
	}
	
	[Flags]
	internal enum EventMask {
		NoEventMask		= 0,
		KeyPressMask		= 1<<0,
		KeyReleaseMask		= 1<<1,
		ButtonPressMask		= 1<<2,
		ButtonReleaseMask	= 1<<3,
		EnterWindowMask		= 1<<4,
		LeaveWindowMask		= 1<<5,
		PointerMotionMask	= 1<<6,
		PointerMotionHintMask	= 1<<7,
		Button1MotionMask	= 1<<8,
		Button2MotionMask	= 1<<9,
		Button3MotionMask	= 1<<10,
		Button4MotionMask	= 1<<11,
		Button5MotionMask	= 1<<12,
		ButtonMotionMask	= 1<<13,
		KeymapStateMask		= 1<<14,
		ExposureMask		= 1<<15,
		VisibilityChangeMask	= 1<<16,
		StructureNotifyMask	= 1<<17,
		ResizeRedirectMask	= 1<<18,
		SubstructureNotifyMask	= 1<<19,
		SubstructureRedirectMask= 1<<20,
		FocusChangeMask		= 1<<21,
		PropertyChangeMask	= 1<<22,
		ColormapChangeMask	= 1<<23,
		OwnerGrabButtonMask	= 1<<24
	}
	
	[Flags]
	internal enum GdkEventMask {
		ExposureMask = EventMask.ExposureMask, 
  		PointerMotionMask = EventMask.PointerMotionMask,
		PointerMotionHintMask = EventMask.PointerMotionHintMask,
		ButtonMotionMask = EventMask.ButtonMotionMask,
		Button1MotionMask = EventMask.Button1MotionMask,
		Button2MotionMask = EventMask.Button2MotionMask,
		Button3MotionMask = EventMask.Button3MotionMask,
		ButtonPressMask = EventMask.ButtonPressMask,
		ButtonReleaseMask = EventMask.ButtonReleaseMask,
		KeyPressMask = EventMask.KeyPressMask,
		KeyReleaseMask = EventMask.KeyReleaseMask,
		EnterWindowMask = EventMask.EnterWindowMask,
		LeaveWindowMask = EventMask.LeaveWindowMask,
		FocusChangeMask = EventMask.FocusChangeMask,
		StructureNotifyMask = EventMask.StructureNotifyMask,
		PropertyChangeMask = EventMask.PropertyChangeMask,
		VisibilityChangeMask = EventMask.VisibilityChangeMask,
		PROXIMITY_IN = 0,
		PROXIMTY_OUT = 0,
		SubstructureNotifyMask = EventMask.SubstructureNotifyMask,
		ButtonPressMask2 = EventMask.ButtonPressMask
  }
}
