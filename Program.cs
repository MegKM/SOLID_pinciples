using System;

//Create inteface, this allows the creation of multiple subclasses without modifying the core code
public interface IArrayService
{
    void SortArray(int[] arr);
}

//Sort the array ascending
public class SortArrayAscending : IArrayService
{
    public void SortArray(int[] arr)
    {
        Array.Sort(arr);
    }
}

//Example of additional subclass that could be added
public class SortArrayDescending : IArrayService
{
    public void SortArray(int[] arr)
    {
        Array.Sort(arr);
        Array.Reverse(arr);
    }
}

public class FindMissingArrayValue
{
    //Create temporary/private interface and array
    private readonly IArrayService _arrayService;
    private readonly int[] _array;

    //Define constructor that accepts required values
    public FindMissingArrayValue(IArrayService arrayService, int[] array)
    {
        _arrayService = arrayService;
        _array = array;
    }

    //Use the sorting strategy to order the array before searching for the missing number.
    //Print value to console.
    public void Run()
    {
        _arrayService.SortArray(_array);

        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] != i)
            {
                Console.WriteLine($"Missing number: {i}");
                return;
            }
        }
    }
}

//Run the program; pulling all classes together and deciding on which sort to use
class Program 
{
    static void Main()
    {
        int[] testArray1 = {3, 0, 1};
        int[] testArray2 = {9, 6, 4, 2, 3, 5, 7, 0, 1};

        IArrayService arrayService = new SortArrayAscending(); 
        FindMissingArrayValue find = new FindMissingArrayValue(arrayService, testArray2);
        find.Run();
    }
}
