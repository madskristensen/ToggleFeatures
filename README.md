# Disable Solution Explorer's Dynamic Nodes

[![Build status](https://ci.appveyor.com/api/projects/status/pcst2rgduofvuru1?svg=true)](https://ci.appveyor.com/project/madskristensen/togglefeatures)

Download the extension at the
[VS Gallery](https://visualstudiogallery.msdn.microsoft.com/62461a72-4255-4eac-a630-52758e9c3723)
or get the
[nightly build](http://vsixgallery.com/extension/4ce74140-3f68-4438-92a4-a54afea98179/).

---------------------------------------------------

A single-purpose extension that makes it easy to
disable/enable Solution Explorer's dynamic nodes such as
inline Class View nodes from C# and VB files.

## Warning - here's how it works
This extension disables all dynamic nodes implemented using
the `IGraphProvider` interface, so there might be other
nodes besides the Class View nodes that will be disabled.

However, this extensions allows you to turn the feature
back on without leaving a trace, so it is safe to try out.

Visual Studio doesn't allow to turn off just a single
implementation of the `IGraphProvider`, such as inline 
Class View, so the entire feature has to be disabled. 

That's unfortunate.

## Inline class view
Solution Explorer injects extra virtual nodes under certain
code files to give a sneak peek inside them.

![Solution Explorer](art/solution-explorer.png)

Though it provides more information about a file, it also
adds complexity to the Solution Explorer that may confuse
more than help.

## File nesting
One of the issues with in inline class view is that it
makes it more difficult to find nested files.

When files are nested under C# files, it is impossible
to tell since it looks like any other C# file with the
expander icon next to it.

![File nesting closed](art/file-nesting-closed.png)

It's only when the file is expanded that the nested file
becomes visible.

![File nesting](art/file-nesting.png)

In this example the file _VSPackage.resx_ is nested under
the C# file _VSPackage.cs_ but it's only visible when
the file is expanded.

## Hide inline class view
Under the top-level **View** menu, a new button is added
to toggle the visibility of the inline class view.

![View menu](art/view-menu.png)

Clicking the button will prompt the user with a question
to proceed and restart Visual Studio.

![Prompt](art/prompt.png)

Clicking **Yes** will toggle the inline class view feature
on/off and restart VS.

The result is a much cleaner Solution Explorer.

![Solution Explorer after](art/solution-explorer-after.png)

## License

[Apache 2.0](LICENSE)