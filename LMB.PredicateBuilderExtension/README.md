# Predicate Builder Extension

Predicate Builder is a powerful LINQ expression that is mainly used when too many search filter parameters are used for querying data by writing dynamic query expression.

Using the Predicate Builder we can create LINQ to SQL dynamic query and Query with Entity Framework is easy.

## How it works?

This is using [Expression Trees](http://msdn.microsoft.com/en-us/library/bb397951.aspx) to "build" a predicate from two input expressions representing predicates.

Expression Trees are a way to use lambda's to generate a representation of code in a tree like structure (rather than a delegate directly).
This takes two expression trees representing predicates (`Expression<Func<T,bool>>`), and combines them into a new expression tree representing the _"or"_ case (or the _"and"_ case).

Expression trees, and their corresponding utilities like above, are useful for things like ORMs. For example, Entity Framework uses expression trees with `IQueryable<T>` to turn "code" defined as a lambda into SQL that's run on the server.

## How to use this extension?

For this example, we will use the `Person` class:

```C#
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

And a `Collection` of persons...

```C#
public ICollection<Person> Persons = new List<Person>
{
    { new Person {   Name  = "Albert", Age = 31 } },
    { new Person {   Name  = "Amanda" , Age = 18 } },
    { new Person {   Name  = "Angelina" , Age = 23 } },
    { new Person {   Name  = "Bishop", Age = 28 } },
    { new Person {   Name  = "Brad", Age = 35 } },
    { new Person {   Name  = "Dilbert", Age = 50 } },
    { new Person {   Name  = "Lilith", Age = 8 } },
    { new Person {   Name  = "Lindsey", Age = 29 }  },
    { new Person {   Name  = "Tom", Age = 30 }  }
};
```

**Step 1 - Create a predicate expression:**

With the code below, we are creating a `predicate` variable of type `Expression<Func<Person, bool>> True<Person>()`

```C#
var predicate = PredicateBuilderExtension.True<Person>();
```

**Step 2 - Add your _flavored_ predicates:**

```C#
predicate = predicate.And(x => x.Name.StartsWith("A"));
predicate = predicate.Or(x => x.Name.StartsWith("B"));
```

Here we are adding a logical operator _AND_ (`predicate.And()`) to filter all persons wich name starts with the _"A"_ character and we are adding a logical operator _"OR"_ (`predicate.Or()`) to filter all persons  wich name starts with the _"B"_ character.

With the syntax above, our filter will bring all persons that name starts with _"A"_ **OR** starts with _"B"_ character.

**Step 3 - Apply the predicate:**

```C#
var queryResult = Persons.AsQueryable().Where(predicate).ToList();
```

Here we are creating a `queryResult` variable of type `List<Person>` and we are filtering the `Person` collection applying the `predicate` into the `Where()` clause.

Based on our person collection, the results inside the `queryResult` variable will be:

```C#
{ Name = "Albert",   Age = 31 }
{ Name = "Amanda" ,  Age = 18 }
{ Name = "Angelina", Age = 23 }
{ Name = "Bishop",   Age = 28 }
{ Name = "Brad",     Age = 35 }
```

## Where to get this extension?

You can install this extension direct from Nuget:

```C#
Install-Package LMB.PredicateBuilderExtension
```

Or you can download this github project and copy the `PredicateBuilderExtension.cs` file direct into your project.