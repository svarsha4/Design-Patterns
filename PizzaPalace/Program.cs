using PizzaPalace.Factories;
using PizzaPalace.Builders;
using PizzaPalace.Models;
using PizzaPalace.Logging;
using PizzaPalace.Decorators;
using PizzaPalace.Facades;
using PizzaPalace.Payments;
using PizzaPalace.Notifications;
using PizzaPalace.Menu;
using PizzaPalace.Toppings;
using PizzaPalace.Nutrition;
using PizzaPalace.Checkout;
using PizzaPalace.Orders;
using PizzaPalace.Cart;
using PizzaPalace.Commands;
using PizzaPalace.Discounts;
using PizzaPalace.Kitchen;
using PizzaPalace.Visitors;
using PizzaPalace.Interpreter;



// Create locations of Pizza Palace in New York and Chicago
PizzaFactory nyFactory = new NYPizzaFactory();
PizzaFactory chicagoFactory = new ChicagoPizzaFactory();



// Make pizza orders at those locations
nyFactory.OrderPizza("pepperoni");
chicagoFactory.OrderPizza("veggie");



// Specify the ingredients family types for New York and Chicago locations
IPizzaIngredientFactory nyIngredients = new NYIngredientFactory();
IPizzaIngredientFactory chicagoIngredients = new ChicagoIngredientFactory();

Console.WriteLine("NY ingredient family: " + nyIngredients.CreateDough().Describe() + ", " + nyIngredients.CreateSauce().Describe() + ", " + nyIngredients.CreateCheese().Describe());
Console.WriteLine("Chicago ingredientfamily: " + chicagoIngredients.CreateDough().Describe() + ", " + chicagoIngredients.CreateSauce().Describe() + ", " + chicagoIngredients.CreateCheese().Describe());



// Create regional pizzas
var nyPepperoni = new RegionalPizza(
    "NY Pepperoni",
    new List<string> { "Pepperoni" },
    11.99m,
    nyIngredients
);

var chicagoPepperoni = new RegionalPizza(
    "Chicago Pepperoni",
    new List<string> { "Pepperoni" },
    13.99m,
    chicagoIngredients
);

Console.WriteLine("--- Preparing NY Pepperoni ---");
nyPepperoni.Prepare();

Console.WriteLine("\n--- Preparing Chicago Pepperoni ---");
chicagoPepperoni.Prepare();



// Create a customized pizza
var pizza = new CustomPizzaBuilder();

pizza.SetSize("Large");
pizza.SetCrust("Stuffed Crust");

pizza.AddTopping("Extra Cheese");
pizza.AddTopping("Mushrooms");
pizza.AddTopping("Bacon");

pizza.SetPrice(14.99m);

pizza.Build();



// Two customers order the Chef's Special, with one each one getting a clone
var chefSpecialTemplate = new ChefSpecialPizza();
var order1 = chefSpecialTemplate.Clone();
var order2 = (ChefSpecialPizza)chefSpecialTemplate.Clone();



// This allows the customer to customize the chef's pizza without affecting the original chef's special pizza
order2.Toppings.Add("Extra Basil");



// Log the openings of the two locations
OrderLogger.Instance.Log("NY store opened for business.");
OrderLogger.Instance.Log("Chicago store opened for business.");



// Log the orders placed at the two locations
OrderLogger.Instance.Log("Order placed: Pepperoni pizza (NY).");
OrderLogger.Instance.Log("Order placed: Veggie pizza (Chicago).");

OrderLogger.Instance.PrintAllLogs();



// Toppings gets added to an existing pizza order
IOrderItem basePizza = new PepperoniPizza();
Console.WriteLine($"{basePizza.GetDescription()} - ${basePizza.GetPrice()}");

IOrderItem withExtraCheese = new ToppingDecorator(basePizza, "Extra Cheese", 1.50m);
Console.WriteLine($"{withExtraCheese.GetDescription()} - ${withExtraCheese.GetPrice()}");

IOrderItem withCheeseAndBacon = new ToppingDecorator(withExtraCheese, "Bacon", 2.00m);
Console.WriteLine($"{withCheeseAndBacon.GetDescription()} - ${withCheeseAndBacon.GetPrice()}");



// Place an order with extra toppings
var facade = new OrderFacade(new NYPizzaFactory());
var order = facade.PlaceOrder("pepperoni", new List<(string, decimal)>
{
    ("Extra Cheese", 1.50m),
    ("Bacon", 2.00m)
});

Console.WriteLine($"Final order: {order.GetDescription()} - ${order.GetPrice()}");



// Process a payment using the legacy payment gateway through the adapter
IPaymentProcessor payment = new LegacyPaymentAdapter(new LegacyPaymentGateway());
payment.ProcessPayment(14.99m);

var emailNotifier = new OrderNotifier(new EmailSender());
var smsNotifier = new OrderNotifier(new SmsSender());

emailNotifier.NotifyOrderPlaced("Pepperoni Pizza");
smsNotifier.NotifyOrderReady("Pepperoni Pizza");



// Create a combo meal
var combo = new ComboMeal("Family Combo");
combo.AddItem(new PepperoniPizza());
combo.AddItem(new Drink("Cola", 1.99m));
combo.AddItem(new Side("Garlic Bread", 3.49m));

Console.WriteLine($"{combo.GetDescription()} - ${combo.GetPrice()}");



// Create a menu and add items to it
var menu = new Menu();
menu.AddItem(new MargheritaPizza());
menu.AddItem(new PepperoniPizza());
menu.AddItem(new Drink("Cola", 1.99m));
menu.AddItem(combo);

Console.WriteLine("\n--- Menu ---");
foreach (var item in menu)
{
    Console.WriteLine($"{item.GetDescription()} - ${item.GetPrice()}");
}


// Retrieve topping information
var pepperoniOnPizza1 = ToppingFactory.GetTopping("Pepperoni", 60);
var pepperoniOnPizza2 = ToppingFactory.GetTopping("Pepperoni", 60);
Console.WriteLine($"Same ToppingInfo instance? {ReferenceEquals(pepperoniOnPizza1, pepperoniOnPizza2)}");

// Retrieve nutrition information for a pizza
INutritionService nutritionService = new NutritionServiceProxy();
Console.WriteLine(nutritionService.GetNutritionInfo("Pepperoni Pizza"));
Console.WriteLine(nutritionService.GetNutritionInfo("Pepperoni Pizza"));


// Use different payment methods to complete purchases
var checkout = new Checkout(new CreditCardStrategy());
checkout.CompletePurchase(14.99m);

checkout.SetPaymentStrategy(new CashStrategy()); // swap strategies at runtime
checkout.CompletePurchase(9.99m);


// Go through different order states for a customer's order
var orderTwo = new OrderContext();
Console.WriteLine($"Status: {orderTwo.GetCurrentStatus()}");

orderTwo.AdvanceOrder();
orderTwo.AdvanceOrder(); 
orderTwo.AdvanceOrder(); 
orderTwo.AdvanceOrder(); 


// Add items to the customer's "cart"
var cart = new Cart();
var commandManager = new CommandManager();

commandManager.ExecuteCommand(new AddItemCommand(cart, "Pepperoni Pizza"));
commandManager.ExecuteCommand(new AddItemCommand(cart, "Cola"));
cart.PrintCart();

commandManager.UndoLastCommand();
cart.PrintCart();


// Save the current state of the cart to history
var history = new CartHistory();
cart.AddItem("Garlic Bread");
history.Save(cart.CreateSnapshot());

cart.AddItem("Extra Cheese Topping");
cart.PrintCart();

var snapshot = history.Restore();
if (snapshot != null) cart.RestoreSnapshot(snapshot);
cart.PrintCart();


// Determine discount approvals based on differing roles
var cashier = new Cashier();
var manager = new Manager();
var owner = new Owner();

cashier.SetNext(manager);
manager.SetNext(owner);

cashier.ProcessRequest(new DiscountRequest(20.00m, 3m));  
cashier.ProcessRequest(new DiscountRequest(20.00m, 10m));
cashier.ProcessRequest(new DiscountRequest(20.00m, 25m)); 



// Go through the process of placing an order and having it cooked
IKitchenMediator mediator = new KitchenMediator();
var orderStation = new OrderStation(mediator);
var chef = new Chef(mediator);

orderStation.PlaceOrder("Pepperoni Pizza");
chef.FinishCooking("Pepperoni Pizza");


// Performs operations on different types of food items (i.e. Pizza, Drink, Side) without modifying their classes
var items = new List<IOrderItem> { new PepperoniPizza(), new Drink("Cola", 1.99m), new Side("Garlic Bread", 3.49m) };

Console.WriteLine("--- Receipt ---");
((Pizza)items[0]).Accept(new ReceiptVisitor());
((Drink)items[1]).Accept(new ReceiptVisitor());
((Side)items[2]).Accept(new ReceiptVisitor());

Console.WriteLine("\n--- Nutrition Report ---");
((Pizza)items[0]).Accept(new NutritionReportVisitor());
((Drink)items[1]).Accept(new NutritionReportVisitor());
((Side)items[2]).Accept(new NutritionReportVisitor());


// Interpret a string representation of an order and convert it into a list of Pizza objects
PizzaFactory factory = new NYPizzaFactory();
var parsedPizzas = OrderInterpreter.Interpret("2xMargherita, 1xPepperoni", factory);

Console.WriteLine($"\nParsed {parsedPizzas.Count} pizzas from text order.");