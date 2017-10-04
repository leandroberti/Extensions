# Extensions
A set of .NET extension methods.

# Projects

## LMB.PredicateBuilderExtension

Predicate Builder is a powerful LINQ expression that is mainly used when too many search filter parameters are used for querying data by writing dynamic query expression.

You can install this extension direct from Nuget:

```C#
Install-Package LMB.PredicateBuilderExtension
```

Or you can download this github project and copy the PredicateBuilderExtension.cs file direct into your project.

## LMB.PropertyExtension

This extension contains methods for retrieving the Name value of an attribute of type System.ComponentModel.DataAnnotations.DisplayAttribute and the DisplayName value of an attribute of type System.ComponentModel.DisplayNameAttribute.

You can install this extension direct from Nuget:

```C#
Install-Package LMB.PropertyExtension
```

Or you can download this github project and copy the PropertyExtension.cs file direct into your project.

## LMB.GenericEntityBase

This is a template for creating entity models.

By using this template, we end up with the need to duplicate entity properties in view models that represent them.
The great advantage of this is that we exterminate the maintenance nightmare that usually entails in having to remember to mirror changes to the entity to its view models.

You can install this extension direct from Nuget:

```C#
Install-Package LMB.GenericEntityBase
```

Or you can download this github project and copy the `Entity.cs` file, along with all interfaces files, direct into your project.
