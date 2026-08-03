namespace PizzaPalace.Ingredients;

/*

    Different ingredient family types that form the basis of pizza will be represented as interfaces. 

    This ensures that there is no violation of the Open-Closed Principle, as the interfaces DO NOT need to be modified at all. Any new specific ingredient (e.g. a new way
    of making the dough) gets introduced at the Pizza Palace, it can simply extend the corresponding interface without modifying any of the code from that interface.

*/

public interface IDough
{
    string Describe();
}

public interface ISauce
{
    string Describe();
}

public interface ICheese
{
    string Describe();
}