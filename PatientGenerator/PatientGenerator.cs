﻿/*
 * Copyright 2016-2017 Mohawk College of Applied Arts and Technology
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may
 * obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * User: Nityan
 * Date: 2016-2-12
 */

using MARC.HI.EHRS.SVC.Core;
using System.Diagnostics;
using System.ServiceProcess;

namespace PatientGenerator
{
	public partial class PatientGenerator : ServiceBase
	{
		public PatientGenerator()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			ExitCode = ServiceUtil.Start(typeof(Program).GUID);
			if (ExitCode != 0)
				Stop();

			Trace.TraceInformation("Service Started");
		}

		protected override void OnStop()
		{
			Trace.TraceInformation("Service Stopped");
			ServiceUtil.Stop();
		}
	}
}