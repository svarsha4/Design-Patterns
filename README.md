# Pizza Palace — Design Patterns Portfolio Project


## Background


**Pizza Palace** is a C# console application built to demonstrate practical, working implementations of all **23 design patterns**. Rather than implementing each pattern in isolation, every pattern here solves a real problem within a pizza ordering and preparation system.

This project contains **Notes**, a **Presentation** covering the design patterns from a conceptual point of view, and **Code** covering the design patterns from a practical point of view.


## Design Patterns Implemented



### Creational Patterns


**Factory Method** 

`Factories/PizzaFactory.cs`  Subclasses (`NYPizzaFactory`, `ChicagoPizzaFactory`) override `CreatePizza()` to decide which concrete `Pizza` gets built, while `OrderPizza()` stays fixed in the base class

**Abstract Factory** 

`Factories/IPizzaIngredientFactory.cs`, `Ingredients/`  `NYIngredientFactory` and `ChicagoIngredientFactory` each produce a consistent *family* of ingredients (i.e. dough, sauce, cheese) 

**Builder**

`Builders/CustomPizzaBuilder.cs` Assembles a `CustomPizza` step by step (i.e. size, crust, toppings, price) through chained method calls instead of one large constructor

**Prototype**

`Models/Pizza.cs` (`ChefSpecialPizza`) `Clone()` produces an independent copy of the "Chef's Special" pizza, avoiding re-running construction logic

**Singleton**

`Logging/OrderLogger.cs` Guarantees exactly one `OrderLogger` instance exists throughout the whole application, accessed through a single static `Instance` property with a private constructor



### Structural Patterns


**Decorator**

`Decorators/ToppingDecorator.cs` Wraps an `IOrderItem` to add extra toppings and cost at runtime, without modifying the `Pizza` classes

**Facade**

`Facades/OrderFacade.cs` Hides the coordination of `PizzaFactory`, `ToppingDecorator`, and `OrderLogger` behind one simple `PlaceOrder()` call

**Adapter**

`Payments/LegacyPaymentAdapter.cs` Translates a "legacy" payment gateway's incompatible method signature (`MakePayment(int cents)`) into the app's expected interface (`ProcessPayment(decimal dollars)`)

**Bridge**

`Notifications/OrderNotifier.cs` Keeps emails and SMSs as independent hierarchies that can be mixed freely at runtime

**Composite**

`Models/ComboMeal.cs` Treats a bundle of items (i.e. pizza, drink, and side) through the same `IOrderItem` interface as a single item

**Iterator**

`Menu/Menu.cs` Implements `IEnumerable<IOrderItem>` so a `Menu` can be looped over with `foreach`, without exposing its internal structure

**Flyweight** 

`Toppings/ToppingFactory.cs` Caches and reuses shared `ToppingInfo` objects across many pizzas instead of duplicating identical topping data

**Proxy** 

`Nutrition/NutritionServiceProxy.cs` Sits in front of a slow `RealNutritionService`, caching results so repeat lookups for the same pizza return instantly



### Behavioral Patterns


**Strategy** 

`Payments/IPaymentStrategy.cs`, `Checkout/Checkout.cs` Lets a customer swap payment algorithms (i.e. credit card, cash, wallet) at runtime

**State** 

`Orders/OrderContext.cs`, `Orders/IOrderState.cs` Models an order's lifecycle (i.e. Placed → Preparing → Ready → Delivered), where each state decides its own transition to the next one

**Command** 

`Commands/ICommand.cs`, `Commands/CommandManager.cs` Wraps cart actions (i.e. add and remove item) as objects, enabling execution history and undo functionality

**Memento** 

`Cart/CartMemento.cs`, `Cart/CartHistory.cs` Captures and restores a `Cart`'s full internal state at a point in time, without exposing that state through public setters

**Template Method** 

`Models/Pizza.cs` (`Prepare()`), `Models/RegionalPizza.cs` Fixes the sequence of pizza preparation steps in the base class, while `RegionalPizza` overrides individual steps to pull regional ingredients from the Abstract Factory

**Chain of Responsibility** 

`Discounts/DiscountApprover.cs` Passes a discount request down a line of approvers (i.e. Cashier → Manager → Owner) until one has the authority to approve it

**Mediator** 

`Kitchen/KitchenMediator.cs` Routes communication between `OrderStation` and `Chef` through a central mediator

**Visitor** 

`Visitors/IVisitor.cs`, `ReceiptVisitor`, `NutritionReportVisitor` Adds new operations (i.e. receipt generation, nutrition reporting) to existing item classes without modifying those classes

**Interpreter** 
`Interpreter/OrderInterpreter.cs` Parses a simple text-based order format (i.e. `"2xMargherita, 1xCola"`) into real `Pizza` objects.
