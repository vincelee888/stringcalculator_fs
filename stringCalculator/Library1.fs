module ``string calculator``

open NUnit.Framework
open System

let delimeter = [|',';'\n';'|'|]  //[A-Z]
    
let Calculate(input : string) =
    match String.length input with
    | 0 -> 0
    | _ -> input.Split delimeter
            |> Seq.map Int32.Parse
            |> Seq.sum

[<Test>] 
let ``Empty string should equal 0``() =
    let result = Calculate ""
    Assert.AreEqual(result, 0)

[<Test>] 
let ``String containing single number should equal number``() =
    let input = 8
    let inputAsString = input.ToString()
    let result = Calculate inputAsString
    Assert.AreEqual(result, input)

[<Test>] 
let ``String containing multiple numbers delimited by comma should equal numbers added together``() =
    let result = Calculate "1,2,3,4"
    Assert.AreEqual(result, 10)

[<Test>] 
let ``String containing multiple numbers delimited by some other delimiter should equal numbers added together``() =
    let result = Calculate "1\n2,3,4"
    Assert.AreEqual(result, 10)
//
//[<Test>] 
//let ``String containing multiple numbers delimited by specified delimiter limit should equal numbers added together``() =
//    let result = Calculate "//[,]\n1\n2,3|4"
//    Assert.AreEqual(result, 10)