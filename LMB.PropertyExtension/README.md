# Property Extension

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=26TY9QLTDWDSE&lc=US&item_name=leandroberti&item_number=github&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted)

This extension contains methods for retrieving the `Name` value of an attribute of type `System.ComponentModel.DataAnnotations.DisplayAttribute` and the `DisplayName` value of an attribute of type `System.ComponentModel.DisplayNameAttribute`.

## How it works?

This extension is using [Reflection](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection) to find a property (informed in the method parameter) and from there, retrieve the `Name` from an attribute of type `System.ComponentModel.DataAnnotations.DisplayAttribute` or the `DisplayName` from an attribute of type `System.ComponentModel.DisplayNameAttribute`.


## How to use this extension?

For this example, we will use the `Customer` class and it's `CustomerCategory` enumerator.

_Note that the both are decorated with `Display` or `DisplayName` attributes._
_To use those attributes, you need to add a reference to the `System.ComponentModel.DataAnnotations` assembly._

```C#
using System.ComponentModel.DataAnnotations;

namespace MyNamespace
{
    public class Customer
    {
        [Display(Name = "Customer's Id")]
        public int Id { get; set; }

        [DisplayName("Customer's Full Name")]
        public string Name { get; set; }

        [Display(Name = "Customer's Category")]
        public CustomerCategory Category { get; set; }
    }

    public enum CustomerCategory
    {

        [Display(Name = "Silver Category")]
        Silver = 1,

        [Display(Name = "Gold Category")]
        Gold = 2,

        [Display(Name = "Platinum Category")]
        Platinum = 3
    }
}
```

**From a Class:**

```C#
// Creates a new instance of the Customer class
var customer = new Customer
{
    Category = CustomerCategory.Platinum,
    Id = 1,
    Name = "Homer 'Jay' Simpson"
};

// Get the DisplayName from System.ComponentModel.DisplayNameAttribute
var displayNameAttribute = customer.GetDisplayNameAttributeValue("Name");

// Get the Name from System.ComponentModel.DataAnnotations.DisplayAttribute
var nameAttribute = customer.GetDisplayAttributeValue("Id");
```

**From an Enum:**

```C#
// Get the Name from System.ComponentModel.DataAnnotations.DisplayAttribute
var nameAttribute = CustomerCategory.Gold.GetDisplayAttributeValue();
```

## Where to get this extension?

You can install this extension direct from:

[![Nuget](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/LMB.PropertyExtension/)

Or instal with Package Manager Console

```C#
Install-Package LMB.PropertyExtension
```

Or you can download this github project and copy the `PropertyExtension.cs` file direct into your project.

# Donations

**If you enjoy this work, please consider supporting me for developing and maintaining this (and others) templates.**

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=26TY9QLTDWDSE&lc=US&item_name=leandroberti&item_number=github&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted)
