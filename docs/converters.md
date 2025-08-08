# Converters

ADVTheme comes bundled with some additional converters that are made use of within the theme itself. Below is documentation on each including links to each converters respective cs file.

## [BoolValueConverter](../ADVTheme/Converters/BoolValueConverter.cs)
Converts an input bool to return specified values for both True and False. 

Supports Two-Way Binding: No

| Variable Name | Type                                                         | Description                                                                                 |
|---------------|--------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| ValueType     | [ValueTypes](../ADVTheme/Converters/BoolValueConverter.cs#L13) | Defines what the value type is that will be returned. Supports `int`, `float`, and `double` |
| TrueValue     | object                                                       | Returned when the bound bool is `True`                                                      |
| FalseValue    | object                                                       | Returned when the bound bool is `False`                                                     |

## [DoubleIncrementConverter](../ADVTheme/Converters/DoubleIncrementConverter.cs)
Increments a supplied double using Addition, Multiplication, Subtraction, or Division

Supports Two-Way Binding: No

| Variable Name  | Type                                                                | Description                                                                        |
|----------------|---------------------------------------------------------------------|------------------------------------------------------------------------------------|
| ModifierMethod | [ModifierType](../ADVTheme/Converters/DoubleIncrementConverter.cs#L13) | Defines the increment method. Supports `Add`, `Subtract`, `Multiply`, and `Divide` |
| ModifierValue  | double                                                              | The value used to increment the bound value.                                       |

## [MultiDoubleComparer](../ADVTheme/Converters/MultiDoubleComparer.cs)
Compares the first two values from a MultiValue Binding and returns false if the values do not match.

Supports Two-Way Binding: No

## [OpacityBoolConverter](../ADVTheme/Converters/OpacityBoolConverter.cs) 
Checks if the bound value is <= 0 and returns false if it is or true if not when ConvertingTo. When ConvertingBack, it checks if the value is > 0.001 and returns true if if is.

Supports Two-Way Binding: Yes

## [PlatformBoolConverter](../ADVTheme/Converters/PlatformBoolConverter.cs)
Compares against the selected platform to be compared to and returns True if the platform matches the requested platform.

Supports Two-Way Binding: No

| Variable Name | Type                                                              | Description                                                                       |
|---------------|-------------------------------------------------------------------|-----------------------------------------------------------------------------------|
| Platform      | [OSPlatform](../ADVTheme/Converters/PlatformBoolConverter.cs#L11) | Defines the Platform to be checked for. Options are `Windows`, `Mac`, and `Linux` |

