﻿namespace MvcTurbine.Web.Filters {
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ComponentModel;

    /// <summary>
    /// Performs the same operations as <see cref="FilterAttributeFilterProvider"/> however, it injects depedencies into the attribute.
    /// </summary>
    public class InjectableAttributeFilterProvider : FilterAttributeFilterProvider {
        public IServiceInjector Injector { get; private set; }

        ///<summary>
        /// Default constructor
        ///</summary>
        ///<param name="serviceLocator"></param>
        public InjectableAttributeFilterProvider(IServiceInjector serviceLocator) {
            Injector = serviceLocator;
        }

        /// <summary>
        /// Calls <see cref="FilterAttributeFilterProvider.GetFilters"/> then injects any filters that are returned from the list prior
        /// to returning them to the framework.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="actionDescriptor"></param>
        /// <returns>A filter list of injected filters (if any require it).</returns>
        public override IEnumerable<System.Web.Mvc.Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor) {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            
            foreach (var filter in filters) {
                Injector.Inject(filter.Instance);
            }

            return filters;
        }
    }
}
