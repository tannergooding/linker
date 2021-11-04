﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Mono.Linker.Tests.Cases.Expectations.Assertions;
using Mono.Linker.Tests.Cases.Expectations.Metadata;

namespace Mono.Linker.Tests.Cases.FunctionPointers
{
	[SetupCompileArgument ("/unsafe")]
	unsafe class CanCompileMethodWithFunctionPointerParameter
	{
		public static void Main()
		{
			new CanCompileMethodWithFunctionPointerParameter.B ().Method (null);
		}

		[KeptMember (".ctor()")]
		class B
		{
			public void Unused (delegate* unmanaged<void> fnptr)
			{
			}

			[Kept]
			public void Method (delegate* unmanaged<void> fnptr)
			{
			}
		}
	}
}
