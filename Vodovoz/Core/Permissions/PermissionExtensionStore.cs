﻿using System;
using System.Collections.Generic;
using System.Linq;
using QS.Permissions;
using QS.Project.Services;
using Vodovoz.Domain.Permissions;

namespace Vodovoz.Core.Permissions
{
	public class PermissionExtensionStore
	{
		private SortedList<string, IPermissionExtension> permissionExtensions;
		public SortedList<string, IPermissionExtension> PermissionExtensions {
			get 
			{
				if(permissionExtensions == null)
					permissionExtensions = GetExtensions();

				return permissionExtensions;
			}
		}

		protected SortedList<string,IPermissionExtension> GetExtensions()
		{
			SortedList<string, IPermissionExtension> extensions = new SortedList<string, IPermissionExtension>(StringComparer.Ordinal);
			Type parent = typeof(IPermissionExtension);
			IEnumerable<Type> types = new List<Type>();

			foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
				var list = assembly.GetTypes().Where(x => parent.IsAssignableFrom(x) && !x.IsAbstract);
				if(list?.FirstOrDefault() != null)
					types = types.Concat(list);
			}
			foreach(var item in types) {
				try 
				{
					if(Activator.CreateInstance(item) is IPermissionExtension instance)
						extensions.Add(instance.PermissionId ,instance);
				}
				catch(MissingMethodException ex) {
					continue;
				}
			}

			return extensions;
		}


	}
}
