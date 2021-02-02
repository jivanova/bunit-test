using Bunit;
using Xunit;
using Moq;
using BUnit_Sample_App.Pages;
using BUnit_Sample_App.Components;
using Microsoft.AspNetCore.Components;
using BUnit_Test.Common;

namespace BUnit_Test
{
    public class SampleAppTest
    {
        [Fact]
        public void PopupContainer_from_extension_method()
        {
            using var ctx = new MyTestContext();

            ctx.Setup();

            // render index page that defines popup
            ctx.RenderComponent<Index>();

            Assert.Contains("Content1", ctx.PopupContainer.Markup);
        }

        [Fact]
        public void PopupContainer_from_test()
        {
            using var ctx = new MyTestContext();

            var popupContainer = ctx.RenderComponent<PopupContainer>();

            var indexPage = ctx.RenderComponent<Index>(parameters => parameters.AddCascadingValue("Container", popupContainer.Instance));

            Assert.Contains("Content1", popupContainer.Markup);
        }
    }
}
