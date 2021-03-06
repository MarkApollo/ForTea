﻿#region License
//    Copyright 2012 Julien Lebosquain
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
#endregion
using JetBrains.ReSharper.Feature.Services.CSharp.CodeStructure;
using JetBrains.ReSharper.Feature.Services.CodeStructure;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util;

namespace GammaJul.ReSharper.ForTea.Services.CodeStructure {

	internal sealed class T4CSharpCodeStructureRegionEnd : CodeStructurePreprocessorElement, ICodeStructureBlockEnd {

		private readonly CSharpCodeStructureRegion _parentRegion;
		
		public override ICodeStructureBlockStart ParentBlock {
			get { return _parentRegion; }
		}

		public T4CSharpCodeStructureRegionEnd(CodeStructureElement parentElement, ITreeNode preprocessorDirective, CSharpCodeStructureProcessingState state)
			: base(parentElement, preprocessorDirective) {
			_parentRegion = state.Regions.TryPeek();
		}

	}

}