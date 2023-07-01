// Read more
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates
// https://www.youtube.com/watch?v=YT8s-90oDC0&list=PLgDkT5ISTggSkueUxKzOCzBgwk3dVgSf7&index=1&t=1759s

namespace Delegate
{
    internal class Program
    {
        // Define a custom delegate that has a string parameter and returns void.
        public delegate void Del(string message);
        public delegate void CustomDel(string s);

        static void Main(string[] args)
        {
            #region Example 1
            // Instantiate the delegate.
            Del handler = DelegateMethod;
            // Call the delegate.
            handler("Hello World");
            #endregion

            #region Example 2
            //Console.WriteLine("Hello, World!");
            MethodWithCallback(1, 2, handler);
            #endregion

            #region Example 3
            var requiredFieldIsValid = CommonFieldValidatorFunctions.RequiredFieldValidDel("Hello World");
            #endregion

            #region Example 4
            // Declare instances of the custom delegate.
            CustomDel hiDel, byeDel, multiDel, multiMinusHiDel;

            // In this example, you can omit the custom delegate if you
            // want to and use Action<string> instead.
            //Action<string> hiDel, byeDel, multiDel, multiMinusHiDel;

            // Initialize the delegate object hiDel that references the
            // method Hello.
            hiDel = Hello;

            // Initialize the delegate object byeDel that references the
            // method Goodbye.
            byeDel = Goodbye;

            // The two delegates, hiDel and byeDel, are combined to
            // form multiDel.
            multiDel = hiDel + byeDel;

            // Remove hiDel from the multicast delegate, leaving byeDel,
            // which calls only the method Goodbye.
            multiMinusHiDel = multiDel - hiDel;

            Console.WriteLine("Invoking delegate hiDel:");
            hiDel("A");
            Console.WriteLine("Invoking delegate byeDel:");
            byeDel("B");
            Console.WriteLine("Invoking delegate multiDel:");
            multiDel("C");
            Console.WriteLine("Invoking delegate multiMinusHiDel:");
            multiMinusHiDel("D");
            #endregion

            #region Example 5
            var allCustomIsValid1 = CommonFieldValidatorFunctions.AllCustomValidDel("Hello World");

            var allCustomIsValid2 = CommonFieldValidatorFunctions.AllCustomValidDel(string.Empty);

            var allCustomIsValid3 = CommonFieldValidatorFunctions.AllCustomValidDel("Hello World more then 20 caracteres");

            #endregion
        }

        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }

        public static void Hello(string s)
        {
            Console.WriteLine($"  Hello, {s}!");
        }

        public static void Goodbye(string s)
        {
            Console.WriteLine($"  Goodbye, {s}!");
        }
    }
}