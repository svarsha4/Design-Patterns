namespace PizzaPalace.Models;

/*

    The "ICloneablePizza" interface implements the Prototype Pattern by allowing the creation of a new pizza object by cloning an existing pizza object. 
    This allows for the pizza object's properties to be reused, without having to create a new pizza object from scratch every time.

    This ensures that there is no violation of the following SOLID principles:
    1) Interface Segregation Principle: The "ICloneablePizza" interface is a small, focused interface that does not need to be needlessly used in any context
    outside of cloning an existing pizza object.

*/

public interface ICloneablePizza
{
    Pizza Clone();
}