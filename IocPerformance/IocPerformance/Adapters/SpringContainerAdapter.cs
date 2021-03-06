﻿using System;
using Spring.Context;

namespace IocPerformance.Adapters
{
    public sealed class SpringContainerAdapter : ContainerAdapterBase
    {
        private IApplicationContext container;

        public override string Name
        {
            get { return "Spring.NET"; }
        }

        public override string PackageName
        {
            get { return "Spring.Core"; }
        }

        public override bool SupportsInterception
        {
            get { return true; }
        }

        public override string Url
        {
            get { return "http://www.springframework.net/"; }
        }

        public override bool SupportsPropertyInjection
        {
            get { return true; }
        }

        public override object Resolve(Type type)
        {
            return this.container.GetObject(type.FullName);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.container == null)
            {
                return;
            }

            this.container.Dispose();
            Spring.Context.Support.ContextRegistry.Clear();
            this.container = null;
        }

        public override void PrepareBasic()
        {
            // TODO: use named contexts for basic and full registrations to allow for fair comparison http://www.springframework.net/doc/reference/html/objects.html 3.15. Customized behavior in the ApplicationContext
            this.container = Spring.Context.Support.ContextRegistry.GetContext();
        }
    }
}