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

            ctx.RenderComponent<Index>(parameters => parameters.AddCascadingValue("Container", popupContainer.Instance));

            var indexPage = popupContainer.FindComponent<Index>();

            Assert.Contains("Content1", popupContainer.Markup);
        }


        [Fact]
        public void PopupContainer_find_inner_button()
        {
            using var ctx = new MyTestContext();

            var popupContainer = ctx.RenderComponent<PopupContainer>(ps => ps.AddChildContent<Index>());
            var popup = popupContainer.FindComponent<Popup>();
            
            //following the structure of nesting components cannot find the button
            var button = popup.FindComponent<Button>();

            //the below code works
            //var button = popupContainer.FindComponent<Button>();

            Assert.Contains("Test1", button.Markup);
        }
    }
}
