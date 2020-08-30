# TinyValidator

| Category | Status |
|:---------|:-------|
| Package |  |
| Code Quality  | [![CodeFactor](https://www.codefactor.io/repository/github/pbouillon/tinyvalidator/badge)](https://www.codefactor.io/repository/github/pbouillon/tinyvalidator) |
| CI / CD | ![Build](https://github.com/pBouillon/TinyValidator/workflows/Build/badge.svg) |

TinyValidator is a lightweight and framework-agnostic .NET validation library

## Overview

Given a custom type, struct or class, you can easily create your own rule set and generate validation pipeline from them to validate any instance of the desired entity.

### Example

Assuming you have to validate a business class which is a `Person`:

```csharp
public class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
}
```

You can write your custom validation rules:

```csharp
public class MustBeAdult : Rule<Person>
{
    protected override bool IsValidWhen(Person person)
        => person.Age >= 18;

    protected override void OnInvalid()
        => throw new RuleViolatedException("The provided person is still a minor");
}

public class MustNotBeDead : Rule<Person>
{
    protected override bool IsValidWhen(Person person)
        => person.Age < 100;

    protected override void OnInvalid()
        => throw new RuleViolatedException("This person seems to be a bit old");
}
```

And from then, creating your generator to validate your instances

```csharp
// Create the validator from a custom pipeline
var validator = Validator<Person>.CreateValidationPipelineWith(
        new MustBeAdult(),
        new MustNotBeDead());

// Validate your instance
_validator.Validate(person);
```

When calling `.Validate` on your instance, each custom `Rule` will be checked in the same order as at the `Validator` creation.

If any fails, `.OnInvalid` will be called for the failing rule.

> You may also want to create your `Validator` as a class member to make your code a bit less verbose and avoid its creation each time you perform a validation

### Built-in validators

Some types already have some built-in validators such as `string` and others yet to come.

If you can't find the rule you are looking for, you are free to add yours !

> For simple validations with no reference to a business rule, you may want to check [LiteGuard](https://github.com/adamralph/liteguard)


## Installation

*In Progress*

## Documentation

*In Progress*

## Contributing

All contributions are warmly welcomed !  
Feel free to [open an issue](https://github.com/pBouillon/TinyValidator/issues/new) to report a bug, suggest an feature or any other improvement.
