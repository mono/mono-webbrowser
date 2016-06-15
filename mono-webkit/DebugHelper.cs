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

//#define DEBUG
//#define TRACE

using System;
#if NET_2_0
using System.Collections.Generic;
#else
using System.Collections;
#endif
using System.Reflection;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Mono.WebKit
{
	internal class DebugHelper
	{
		static DebugHelper () {
			Debug.AutoFlush = true;
		}

		struct Data {
			public MethodBase method;
			public object[] args;
			public Data (MethodBase m, object[] a) {
				this.method = m;
				this.args = a;
			}
		}
#if NET_2_0
		static Stack<Data> methods = new Stack<Data>();
#else
		class DataStack : System.Collections.Stack {
			public new Data Peek () {
				return (Data) base.Peek ();
			}
			public new Data Pop () {
				return (Data) base.Pop ();
			}
			public DataStack (int initialCapacity) : base (initialCapacity) {}
			public DataStack () : base () {}
			public DataStack (ICollection icol) : base (icol) {}
		}
		static DataStack methods = new DataStack();
#endif

		[Conditional("DEBUG")]
		internal static void DumpCallers () {
            StackTrace trace = new StackTrace(true);
			int count = trace.FrameCount;
			Debug.Indent ();
			for (int i = 1; i < count; i++) {
            	StackFrame parentFrame = trace.GetFrame(i);
            	MethodBase parentMethod = parentFrame.GetMethod();
				string file = parentFrame.GetFileName();
				if (file != null && file.Length > 1)
					file = file.Substring (file.LastIndexOf (Path.DirectorySeparatorChar) + 1);
				Debug.WriteLine(parentMethod.DeclaringType.Name + "." + parentMethod.Name +
				              " at " + file + ":" + parentFrame.GetFileLineNumber()
				              );
			}

			Debug.Unindent ();
		}

		[Conditional("DEBUG")]
		internal static void DumpCallers (int count) {
            StackTrace trace = new StackTrace(true);
			int c = (count > trace.FrameCount ? trace.FrameCount : count);
			Debug.Indent ();
			for (int i = 1; i < c; i++) {
            	StackFrame parentFrame = trace.GetFrame(i);
            	MethodBase parentMethod = parentFrame.GetMethod();
				string file = parentFrame.GetFileName();
				if (file != null && file.Length > 1)
					file = file.Substring (file.LastIndexOf (Path.DirectorySeparatorChar) + 1);
				Debug.WriteLine(parentMethod.DeclaringType.Name + "." + parentMethod.Name +
				              " at " + file + ":" + parentFrame.GetFileLineNumber()
				              );
			}

			Debug.Unindent ();
		}

		[Conditional("DEBUG")]
		internal static void Enter ()
		{
			StackTrace trace = new StackTrace();
			methods.Push (new Data (trace.GetFrame(1).GetMethod(), null));
			Debug.WriteLine ("Entering " + Current);
			Debug.Indent ();
		}

		[Conditional("DEBUG")]
		internal static void Enter (object[] args)
		{
			StackTrace trace = new StackTrace();
			methods.Push (new Data (trace.GetFrame(1).GetMethod(), args));
			Debug.WriteLine ("Entering " + Current);
			Debug.Indent ();
		}

		[Conditional("DEBUG")]
		internal static void Leave ()
		{
			if (methods.Count > 0) {

				Debug.Unindent ();
				Debug.WriteLine ("Leaving " + Current);
				methods.Pop ();
			}
		}


		static string Current
		{
			get {
				if (methods.Count == 0)
					return "";

				Data data = methods.Peek ();
				return data.method.DeclaringType.Name + "." + data.method.Name;
			}
		}

		[Conditional("DEBUG")]
		internal static void Print ()
		{
			Debug.WriteLine (Current);
		}

		[Conditional("DEBUG")]
		internal static void Print (int index)
		{
			if (methods.Count == 0 || methods.Count <= index || index < 0)
				return;

#if NET_2_0
			Stack<Data> temp = new Stack<Data>(index-1);
#else
			DataStack temp = new DataStack(index-1);
#endif
			for (int i = 0; i < index; i++)
				temp.Push (methods.Pop ());

			Data data = methods.Peek ();
			for (int i = 0; i < temp.Count; i++)
				methods.Push (temp.Pop());
			temp = null;

			Debug.WriteLine (data.method.DeclaringType.Name + "." + data.method.Name);
		}

		[Conditional("DEBUG")]
		internal static void Print (string methodName, string parameterName)
		{
			if (methods.Count == 0)
				return;

#if NET_2_0
			Stack<Data> temp = new Stack<Data>();
#else
			DataStack temp = new DataStack();
#endif
			Data data = methods.Peek ();
			bool foundit = false;
			for (int i = 0; i < methods.Count; i++)
			{
				data = methods.Peek ();
				if (data.method.Name.Equals (methodName)) {
					foundit = true;
					break;
				}
				temp.Push (methods.Pop ());
			}

			for (int i = 0; i < temp.Count; i++)
				methods.Push (temp.Pop());
			temp = null;

			if (!foundit)
				return;

			Debug.WriteLine (data.method.DeclaringType.Name + "." + data.method.Name);
			ParameterInfo[] pi = data.method.GetParameters ();

			for (int i = 0; i < pi.Length; i++) {
				if (pi[i].Name == parameterName) {
					Debug.Indent ();
					Debug.Write (parameterName + "=");
					if (pi[i].ParameterType == typeof(IntPtr))
						Debug.WriteLine (String.Format ("0x{0:x}", ((IntPtr)data.args[i]).ToInt32()));
					else
						Debug.WriteLine (data.args[i]);
					Debug.Unindent ();
				}
			}
		}

		[Conditional("DEBUG")]
		internal static void Print (string parameterName)
		{
			if (methods.Count == 0)
				return;
			Data data = methods.Peek ();

			ParameterInfo[] pi = data.method.GetParameters ();

			for (int i = 0; i < pi.Length; i++) {
				if (pi[i].Name == parameterName) {
					Debug.Indent ();
					Debug.Write (parameterName + "=");
					if (pi[i].ParameterType == typeof(IntPtr))
						Debug.WriteLine (String.Format ("0x{0:x}", data.args[i]));
					else
						Debug.WriteLine (data.args[i]);
					Debug.Unindent ();
				}
			}
		}

		[Conditional("DEBUG")]
		internal static void WriteLine (object arg)
		{
			Debug.WriteLine (arg);
		}

		[Conditional("DEBUG")]
		internal static void WriteLine (string format, params object[] arg)
		{
			Debug.WriteLine (String.Format (format, arg));
		}

		[Conditional("DEBUG")]
		internal static void WriteLine (string message)
		{
			Debug.WriteLine (message);
		}

		[Conditional("DEBUG")]
		internal static void Indent ()
		{
			Debug.Indent ();
		}

		[Conditional("DEBUG")]
		internal static void Unindent ()
		{
			Debug.Unindent ();
		}

		[Conditional("TRACE")]
		internal static void TraceWriteLine (string format, params object[] arg)
		{
			Debug.WriteLine (String.Format (format, arg));
		}

		[Conditional("TRACE")]
		internal static void TraceWriteLine (string message)
		{
			Debug.WriteLine (message);
		}

	}
}
