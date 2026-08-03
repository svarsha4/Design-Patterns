namespace PizzaPalace.Visitors;

using PizzaPalace.Models;

/*

    The "IVisitor" interface forms the Visitor Pattern. It defines a set of "Visit" methods, with 
    each corresponding to a different type of food offered at the PizzaPalace (e.g. Pizza, Drink, Side). 
    The "ReceiptVisitor" and "NutritionReportVisitor" classes implement this interface, providing specific behaviors for each food type. 
    Specifically, the "Accept" method in the food classes (Pizza, Drink, Side) allows operations performed on the food items without modifying any of the classes
    associated with them.

    This ensures that there is no violation of the following SOLID principles:
    1) Open-Closed Principle: New types of "visitors" can be added without modifying the existing food classes (Pizza, Drink, Side)

*/

public interface IVisitor
{
    void Visit(Pizza pizza);
    void Visit(Drink drink);
    void Visit(Side side);
}