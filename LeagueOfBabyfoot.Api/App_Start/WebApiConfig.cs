﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace LeagueOfBabyfoot.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.Clear();
			//config.Formatters.Add(new XmlMediaTypeFormatter());
			config.Formatters.Add(new JsonMediaTypeFormatter());
			config.Formatters.Add(new FormUrlEncodedMediaTypeFormatter());

			config.EnableCors();
		}
	}
}
