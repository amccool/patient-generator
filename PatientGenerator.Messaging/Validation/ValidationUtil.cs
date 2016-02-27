﻿/*
 * Copyright 2016-2016 Mohawk College of Applied Arts and Technology
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
 * Date: 2016-2-15
 */
using PatientGenerator.Core.ComponentModel;
using PatientGenerator.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientGenerator.Messaging.Validation
{
	public static class ValidationUtil
	{
		public static IEnumerable<IResultDetail> ValidateMessage(DemographicOptions options)
		{
			List<IResultDetail> details = new List<IResultDetail>();

			if (options.AssigningAuthority == null)
			{
				details.Add(new MandatoryElementMissingResultDetail(ResultDetailType.Error, nameof(options.AssigningAuthority) + " cannot be null."));
			}

			if ((options.DateOfBirthOptions?.Start != null && options.DateOfBirthOptions?.End != null) && options.DateOfBirthOptions?.Exact != null)
			{
				details.Add(new ConflictingValueResultDetail(ResultDetailType.Error, nameof(options.DateOfBirthOptions) + " cannot have all fields populated. Either Start and End OR Exact"));
			}

			if (options.UseHL7v2)
			{
				if (options.ReceivingApplication == null)
				{
					details.Add(new MandatoryElementMissingResultDetail(ResultDetailType.Error, nameof(options.ReceivingApplication) + " cannot be null."));
				}

				if (options.ReceivingFacility == null)
				{
					details.Add(new MandatoryElementMissingResultDetail(ResultDetailType.Error, nameof(options.ReceivingFacility) + " cannot be null."));
				}

				if (options.SendingApplication == null)
				{
					details.Add(new MandatoryElementMissingResultDetail(ResultDetailType.Error, nameof(options.SendingApplication) + " cannot be null."));
				}

				if (options.SendingFacility == null)
				{
					details.Add(new MandatoryElementMissingResultDetail(ResultDetailType.Error, nameof(options.SendingFacility) + " cannot be null."));
				}
			}

			return details;
		}
	}
}