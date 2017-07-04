// <copyright file="AssemblyInfo.cs" company="natsnudasoft">
// Copyright (c) Adrian John Dunstan. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: CLSCompliant(true)]

// Internals visible to unit testing and Moq proxy.
#pragma warning disable MEN002 // Line is too long
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
#if APPVEYOR
[assembly: InternalsVisibleTo("EgamiFlowScreensaver.Test, PublicKey=00240000048000009400000006020000002400005253413100040000010001006d6afe1f134cd1f34c7d0b8aae97f417ae304739b5e7d73d8ad2bd4738f531b84c4963e3c589d7df5c967c0a33a8b09d77167586fa594baee0540995cac16bb3c16d5e8879f0561d8c2bc4de2ba22d075336561c94d1eaa50a22304b01b1fa5ebde4c4ccf42a2e9e87848bfea4dbd47a1737d4620bfe4321d5910cea72e10cbc")]
#else
[assembly: InternalsVisibleTo("EgamiFlowScreensaver.Test")]
#endif
#pragma warning restore MEN002 // Line is too long

[assembly: AssemblyTitle("EgamiFlowScreensaver")]
[assembly: AssemblyDescription("Egami Flow Screensaver")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("4973021b-04dc-4d0b-be25-b0c39cd545b4")]
