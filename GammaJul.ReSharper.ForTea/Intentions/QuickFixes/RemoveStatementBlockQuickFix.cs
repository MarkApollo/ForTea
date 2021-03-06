#region License
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
using System;
using GammaJul.ReSharper.ForTea.Daemon.Highlightings;
using JetBrains.Annotations;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.QuickFixes;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.TextControl;
using JetBrains.Util;

namespace GammaJul.ReSharper.ForTea.Intentions.QuickFixes {

	[QuickFix]
	public class RemoveStatementBlockQuickFix : QuickFixBase {
		private readonly StatementAfterFeatureHighlighting _highlighting;

		protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress) {
			using (WriteLockCookie.Create(_highlighting.AssociatedNode.IsPhysical()))
				ModificationUtil.DeleteChild(_highlighting.AssociatedNode);
			return null;
		}

		public override string Text {
			get { return "Remove statement block"; }
		}

		public override bool IsAvailable(IUserDataHolder cache) {
			return _highlighting.IsValid();
		}

		public RemoveStatementBlockQuickFix([NotNull] StatementAfterFeatureHighlighting highlighting) {
			_highlighting = highlighting;
		}

	}

}