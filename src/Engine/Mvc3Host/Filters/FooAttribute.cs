﻿namespace Mvc3Host.Filters {
    using System.Web.Mvc;
    using Mvc3Host.Services;

    public class FooAttribute : ActionFilterAttribute {
        public IFooService FooService { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            filterContext.Controller.ViewBag.fooMessage = FooService.GetFoo();
        }
    }
}