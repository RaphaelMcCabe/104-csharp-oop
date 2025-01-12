# Exercises 4 - Abstraction

For all of these exercises, it is recommended to:
- Open GitHub Desktop Application
- Select your Assignment Repository (named `gp21-21-1004-csharp-oop-rpg-[yourusername]`)
- Then, from the Menu Bar in GitHub Desktop, select `Repository` > `Open in Terminal` (or `Open in Command Prompt`)
- Switch to the `projects`-directory using `cd projects`
- Create a Project using `dotnet new console -o ProjectName` (replace the Project Name with the name given by each Exercise)
- Add a `.gitignore` to the folder of the newly created Project:
  - First, navigate to the new folder: `cd [ProjectName]`
  - Then, use `dotnet new gitignore`
  - Do NOT commit any files in `/bin/` or `/obj/`, please!
- Open the Project in the IDE of your choice. Remember: Open the `.csproj` file!!
- Then follow the instructions of the exercise

## 16 - Class Casting:
[Read the Slides on Class Casting](../slides/003.5-classes-3.md#1-class-casting)
### Goal
- Have our `Hero` deal Bonus Damage against certain Units.
### Instructions
- Continue working on the Project `RPG`
- Make the `Attack`-Method on the `Unit`-class `virtual`, if you haven't done so already.
  - This allows us to `overload` this method for some Units, giving them special `Attack` abilities.
- `overload` the `Attack`-Method on the `Hero`-class.
  - First, call the `base`-`Attack`-Method.
  - Then, check, if the `target`-`Unit` `is` a `Skeleton`
    - If it is, then Deal 10 Damage extra.
    - Print `"The Hero deals 10 extra Damage against the Skeleton's weak Bones!"`

## 16.1 - Class Casting:
### Goal
- Introduce a new `Unit` called `Ghost` which scares our `Hero` to his bones 👻
### Instructions
- Continue working on the Project `RPG`
- Add a new `class` inheriting from `Unit` named `Ghost`
  - The `Ghost` has 200 Health
  - The `Ghost` uses `Haunt`, a `Weapon` with 10 Damage.
- Edit the `Hero`'s `Attack`-Method.
  - Check first, whether the `target`-`Unit` `is` a `Ghost`
    - If it is, then do a random-roll:
    - With a 55% Chance, the `Hero` is scared and will not attack this round.
    - Write `"The Hero is too scared to attack!"`
    - Make sure that the `Hero` does not scared by other `Unit`s!

## 16.2 - Class Casting:
### Goal
- We will refactor our `TakeDamage`-Method to allow our `Hedgehog`'s `Spikes` to deal damage while he's in defense Mode.
### Instructions
- Change the `Unit`'s Method `TakeDamage` to take a second parameter named `attacker` of type `Unit`.
- Now, change the Code all over the place, where the `TageDamage`-Method is invoked and pass `this` as a second argument.
  - Like this: `unit.TakeDamage(30, this);`
- Now, in the `Hedgehog`'s `TakeDamage` Method, if he is in Defense-Mode, let the Hedgehog deal 5 Damage through its Spikes.
  - Print: `"The Hedgehog's Spikes are up and they hurt!"`
  - Call `TakeDamage` on the `attacker`-`Unit` and deal 5 Damage.
  - What Danger exists right now?
    - ||think about what might happen, if two Hedgehogs in Defense Mode fight each other.||

## 17 - Interfaces:
[Read the Slides on Class Casting](../slides/003.5-classes-3.md#2-interfaces)
### Goal
- Create a System in which `Weapon`s can be equipped and unequipped.
- `IWeapon` is an `interface` for classes that can be Equipped
- `IHand` is an `interface` for classes that can equip items
### Instructions
- Create an `interface` named `IWeapon`.
  - it has a `Property` named `EquippedTo` of type `IHand` with only a getter: `{get;}` 
  - it has a `Method` named `EquipTo` with one parameter of type `IHand` named `Hand`.
  - it has a `Method` named `UnEquip` with no parameters.
- Create an `interface` named `IHand`.
  - it has a `Property` named `Weapon` of type `IWeapon` with a getter and setter: `{get; set;}`
- Have the `Unit` implement `IHand`
  - You just need to add the `Weapon`-Property with getter and setter
- Have the `Weapon` implement `IWeapon`
  - You need to add the `EquippedTo`-Property with a getter and private setter
  - Implement the `UnEquip`-Method:
    - First, we remove ourselves from the `Hand` that we are equipped to:
    - On our own `EquippedTo`-Property, set the `Weapon`-Property to `null`
    - Then, we set our own `Hand` to `null`, since we are not equipped anymore:
    - Set our own `EquippedTo`-Property to `null`
  - Implement to `EquipTo`-Method:
    - First, if there already is a `Weapon` equipped to the `Hand`, we need to `UnEquip` it:
    - On the `Hand`-Parameter, we need to see, if `Weapon` is not `null`. And if it is not `null`, we need to call `UnEquip` on that `IWeapon`.
    - Then, we need to attach ourselves to the `Hand`:
    - On the `Hand`-Parameter, set the `Weapon`-Property to `this`
    - Then, we need to save the `Hand` in our own Property:
    - Assign the `Hand`-Parameter to our own `EquippedTo`-Property
- Now, let's remove the `Weapon`-Property from the `Unit`
- And in the `Unit`'s Constructor, call `EquipTo` on the `weapon` passed as a constructor argument, and pass `this` as an argument to the Method.



Looking forward to see, whether you come this far! :)
