module ExampleTestFixture
open canopy
open canopy.runner
open System

let all _ =
    context "Sample test fixture in Canopy"

    once (fun _ -> Console.WriteLine("Before entire test fixture"))
    before (fun _ -> Console.WriteLine("  Before each test"))
    after (fun _ -> Console.WriteLine("  After each test"))
    lastly (fun _ -> Console.WriteLine("After entire test fixture"))

    "Test case 1" &&& fun _ ->
        Console.WriteLine("    Test1")

    "Test case 2" &&& fun _ ->
        Console.WriteLine("    Test2")
        