using Bunit;
using BUnit_Sample_App.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUnit_Test.Common
{
    public static class TestContextExtensions
    {
        public static void Setup(this MyTestContext ctx)
        {
            ctx.PopupContainer = ctx.RenderComponent<PopupContainer>();

            ctx.RenderTree.TryAdd<CascadingValue<PopupContainer>>(p =>
            {
                p.Add(parameters => parameters.Name, "Container");
                p.Add(parameters => parameters.Value, ctx.PopupContainer.Instance);
            });
        }
    }

    public class MyTestContext : TestContext
    {
        public IRenderedComponent<PopupContainer> PopupContainer { get; set; }
    }
}
