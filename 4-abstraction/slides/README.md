# Slides 4 - Abstraction

## 1. Class Casting
Class Casting describes the process in Polymorphism of changing the Shape of a class to either its base or its parent:

```cs
public class Animal { 
   public void Breathe() { } 
}
```
```cs
public class Dog : Animal { 
   public void Bark() { } 
}
```
```cs
public class Cat : Animal { 
   public void Meow() { } 
}
```
```cs
public class Teapot { }
```

### Down-Casting

It is very easy to Down-Cast.\
Down-Casting describes the process of casting a class to one of its base-classes.\
If you have a Dog:
```cs
Dog dog = new Dog();
dog.Breathe();
dog.Bark();
```

Then you can implicitly Down-Cast him to an Animal, without requiring any explicit code for casting:
```cs
Animal animal = dog;
animal.Breathe();
```

### Up-Casting

Up-Casting however, the Process of casting a base class to one of its child classes, brings a few more problems.\
If you need to Up-Cast from an `Animal` to a `Dog`, you need to specify it:
```cs
Animal animal = new Dog();
Dog dog = (Dog)animal;
dog.Bark();
```

Why is that? Well, because you need to be quite sure, that this Animal actually is a Dog!\
Every Dog is an Animal. But not every Animal is a Dog.\
In fact, if you try to cast a Cat to a Dog, bad things will happen...

```cs
Animal animal = new Cat();
Dog dog = (Dog)animal;
dog.Bark();
```

Result: `Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.`

This means, when casting, you should always make sure, that the casting was successful:

```cs
Animal animal = new Cat();
Dog dog = (Dog)animal;
if(dog != null) {
   dog.Bark();
}
```

### Keywords for Casting

Since Casting and Type-Checking is awfully ugly, C# has introduced two new keywords.\
There is `is` for Type-Checking:

```cs
Animal animal = new Cat();
if(animal is Dog) {
   Console.WriteLine("I'll be damned, it's a dog!");
}
```

And `as` for Type-Casting:

```cs
Animal animal = new Cat();
Dog dog = animal as Dog;
if(dog != null) {
   dog.Bark();
}
```

They're quite nice in combination:

```cs
Animal animal = new Cat();
if(animal is Dog) {
   (animal as Dog).Bark();
}
```

But even better is the newest addition to the Cast-Club.\
This Syntax can do the Type-Check and Type-Cast in one go:

```cs
Animal animal = new Cat();
if(animal is Dog dog) {
   dog.Bark();
}
```

### Illegal Casting

By the way, all of these methods of Up-Casting do not allow you to even just try to do impossible Up-Casts.\
You will not even be able to Compile / Run the following Code on your Machine:

```cs
Animal animal = new Animal();
Teapot teapot = animal as Teapot;
```

Error: Cannot convert `Animal` to `Teapot` via built-in conversion.

---

## 2. Interfaces

Interfaces are used in C# to make sure that we can communicate with classes whose exact implementation we don't know, yet.\
By defining an interface that we want to interact with and then allowing any class that implements that interface to interact with us.

This interface here:
```cs
public interface IConsumable {
   void Consume();
}
```

For example only defines that whatever class implements `IConsumable`, must have a `Consume` Method.\
Therefore, without knowing, what class might implement `IConsumable` or, what `Consume` will actually do, we can interact with that interface:

```cs
public class Hero {
   public void Use(IConsumable consumable) {
      consumable.Consume();
   }
}
```

What will happen will depend on the class implementing that cosumable:
```cs
public class HealthPotion : IConsumable {
   public void Consume() {
      Player.Health += 50;
   }
}
```

Or maybe:

```cs
public class ManaPotion : IConsumable {
   public void Consume() {
      Player.Mana += 50;
   }
}
```

### Interface vs Abstract Class

What is the difference to an abstract base class, though?
```cs
public abstract class Consumable {
   public abstract void Consume();
}
```

Well not, much, actually. This is, how it would be used:
```cs
public class Hero {
   public void Use(Consumable consumable) {
      consumable.Consume();
   }
}
```

And this is, how it would be implemented:
```cs
public class HealthPotion : Consumable {
   public override void Consume() {
      Player.Health += 50;
   }
}
```

In fact, the only difference is, that we need to use the `override` keyword.

### Why Interfaces?

Then why use interfaces? They have one big advantage:

```cs
public class LuckyCharm : IEquippable, IConsumable {
   public void Equip() {
      Player.Luck += 5;
   }
   
   public void Consume() {
      Player.Gold += 10;
   }
}
```

In other words: Classes cannot inherit from multiple classes, but they can implement multiple interfaces!

### Defining an Interface

So, let's compare it again. A class that has only abstract members...

```cs
public abstract class Animal {
   public abstract string FavoriteFood { get; }
   public abstract string Name { get; set; }
   public abstract void MakeSound();
   public abstract void Feed(string food);
}
```

... can also be defined as an `interface`
- interface Members are always `public`
  - unless explicitly implemented, more on that later.
- Common Scheme for naming interfaces: `IName`

```cs
public interface IAnimal {
   string FavoriteFood { get; }
   string Name { get; set; }
   void MakeSound();
   void Feed8string food);
}
```

### Implementing an Interface

Now, other classes can `implement` this interface:
- We do not say, `Dog` inherits from `IAnimal`, but `Dog` implements `IAnimal`
  - even though, they both use the `:` symbol!
- The class implementing the interface has to:
  - Implement ALL Properties defined in the interface
  - Implement ALL Methods defined in the interface

```cs
public class Dog : IAnimal {
   public string FavoriteFood => "Bones";
   public string Name { get; set; }
   public void MakeSound() {
      Console.WriteLine("Woof!");
   }
   public void Feed(string food) {
      Console.WriteLine("Dog eating " + food);
   }
}
```

### Implementing multiple Interfaces

If your class inherits multiple interfaces, you need to separate them by comma `,`:

```cs
public class Dog : IFeedable, IAdoptable {
   // ...
}
```

If your class inherits from a class and also implements an interface, the class needs to come first:

```cs
public abstract class Animal { }
public interface IFeedable {
  void Feed(string food);
}

public interface IAdoptable {
   void Adopt();
}

public interface ICarriable {
   void Carry();
}

public class Dog : Animal, IFeedable, IAdoptable {
   public void Feed(string food) { }
   public void Adopt() { }
}
```

In above sample, a Dog can be fed and adopted.\
In the example below, we can see that a Cat can be fed and adopted, too, but also carried:

```cs
public class Cat : Animal, IFeedable, IAdoptable, ICarriable {
   public void Feed(string food) { }
   public void Adopt() { }
   public void Carry() { }
}
```

And the poor Lion can neither be carried nor adopted (it's a biiiiig cat), but you can feed it:
```cs
public class Lion : Animal, IFeedable {
   public void Feed(string food) { }
}
```

### Using Interfaces

So, what's the advantage of these interfaces, really?\
Well, imagine, we have a small Zoo, full of animals:

```cs
Animal[] animals = {
   new Lion(), new Dog(), new Cat(), 
   new Cat(), new Dog(), new Lion(), new Cat(),
};
```

Now, how can we Feed all the animals that can be fed?\
We could check, what Animal each of them is, and then feed them, if possible:

```cs
for(int i = 0; i < animals.Length; i++) {
   IAnimal animal = animals[i];
   
   if(animal is Cat cat) {
      cat.Feed();
   }
   
   if(animal is Dog dog) {
      dog.Feed();
   }
   
   // ...
}
```

But you can see, that this can get quite annoying, actually. Imagine that for 150 different animals in the Zoo...\
But if each animal, which can be fed, implements the same `IFeedable` interface, then we can do this:

```cs
for(int i = 0; i < animals.Length; i++) {
   IAnimal animal = animals[i];
   
   if(animal is IFeedable feedable) {
      feedable.Feed("SomeFood");
   }
}
```

The same, we can cast for other interfaces like `IAdoptable`, when someone comes to adopt an animal from the zoo:
```cs
for(int i = 0; i < animals.Length; i++) {
   IAnimal animal = animals[i];
   
   if (animal is IAdoptable adoptable) {
      adoptable.Adopt();
   }
}
```

And for `ICarriable` in case someone tries to lift our animals:
```cs
for(int i = 0; i < animals.Length; i++) {
   IAnimal animal = animals[i];
   
   if ( animal is ICarriable carriable ) {
      carriable.Carry();
   }
}
```
