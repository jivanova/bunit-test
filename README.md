# bunit-test

Playing around with components that are used to dynamically inject RenderFragments, such as popup components.

I used two approached through:

1. Extension method of the bunit TestContext:

```
public static void Setup(this MyTestContext ctx)
{
    ctx.PopupContainer = ctx.RenderComponent<PopupContainer>();

    ctx.RenderTree.TryAdd<CascadingValue<PopupContainer>>(p =>
    {
        p.Add(parameters => parameters.Name, "Container");
        p.Add(parameters => parameters.Value, ctx.PopupContainer.Instance);
    });
}
```

2. Rendering in test


```
using var ctx = new MyTestContext();

var popupContainer = ctx.RenderComponent<PopupContainer>();

var indexPage = ctx.RenderComponent<Index>(parameters => parameters
                          .AddCascadingValue("Container", popupContainer.Instance));

Assert.Contains("Content1", popupContainer.Markup);
```