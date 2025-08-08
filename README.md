# ADV Theme - A Theme for Avalonia

This repository contains the themes used by X-Hax Org developed applications using [Avalonia](https://github.com/AvaloniaUI/Avalonia). 

## Using this Theme

This repository is not setup as a package and should be submoduled into any projects using it if they're git based or cloned into the repo if it's not.

If you have a git repository, you can use the following command:

```
git submodule add https://github.com/X-Hax/ADVTheme
```

Once added as a submodule, simply include the ADVTheme `.cspoj` file in your solution and add it as a dependency to the projects that will be utilizing it. 

Documentation on features this theme includes can be found [here](docs/features.md)

## Supported Controls

This theme does not cover every control offered by Avalonia, but it covers the majority of them including the **ColorPicker** Avalonia offers. This is subject to change if the org's needs with this theme change over time or if there is interest in adding them despite a need for them. As such, this list below is subject to change at any time.

The controls **not** included under this theme are:
- Calendar
- Calendar Button
- Calendar Date Picker
- Calendar Day Button
- Calendar Item
- Tab Strip
- Tab Strip Item
- Time Picker

---
### Palettes

This theme comes bundled with three palettes to work with, more may be added at a later date. The included palettes are:
- Light
- Dark
- Telegram

---
### Icons

This theme also comes bundled with multiple icons for a variety of uses. Most of these were created by users of the org or they were sourced from Public Domain/CC0 resources. 