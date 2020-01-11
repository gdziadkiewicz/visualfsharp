namespace FSharp.Compiler.UnitTests

open NUnit.Framework
open FSharp.Compiler.SourceCodeServices

[<TestFixture>]
module TypeAttributeTests = 

    [<Test>]
    let ``Attribute can be applied to type definition``() = 
        CompilerAssert.Pass
            """
[<Struct>]
type Point = {x:int; y:int}
            """
    [<Test>]
    let ``Attribute can be applied to type definition 2``() = 
        CompilerAssert.Pass
            """
type [<Struct>] Point = {x:int; y:int}
            """
    [<Test>]
    let ``Attribute can be applied to type definition 3``() = 
        CompilerAssert.Pass
            """
[<Struct>]
type [<Struct>] Point = {x:int; y:int}
            """
    [<Test>]
    let ``Attribute can be applied to type definition 4``() = 
        CompilerAssert.Pass
            """
[<Struct>]
type [<NoEquality;NoComparison>] Point = {x:int; y:int}
            """
    
    [<Test>]
    let ``Attribute can be applied to module 1``() = 
        CompilerAssert.Pass
            """
[<AutoOpen>]
module m =
    let x = 2
            """

    [<Test>]
    let ``Attribute can be applied to module 2``() = 
        CompilerAssert.Pass
            """
module [<AutoOpen>] m =
    let x = 2
        """
    
    [<Test>]
    let ``Attribute can be applied to module 3``() = 
        CompilerAssert.Pass
            """
[<AutoOpen;AutoOpen>]
module m
let x = 2
"""

    [<Test>]
    let ``Attribute can be applied to module 4``() = 
        CompilerAssert.Pass
            """
module [<AutoOpen>] m
let x = 2
"""
    [<Test>]
    let ``Attribute can be applied to module 5``() = 
        CompilerAssert.Pass
            """
[<AutoOpen>]
module [<AutoOpen>] m
let x = 2
"""
    [<Test>]
    let ``Attribute can be applied to module 6``() = 
        CompilerAssert.Pass
            """
[<AutoOpen>]
module [<AutoOpen>] m =
    let x = 2
"""

    [<Test>]
    let ``Attribute cannot be applied to optional type extension``() = 
        CompilerAssert.TypeCheckSingleError
            """
open System

[<NoEquality>]
type String with 
    member this.test = 42
            """
            FSharpErrorSeverity.Error
            3246
            (4, 1, 4, 15)
            "Attributes cannot be applied to type extensions."

    [<Test>]
    let ``Attribute cannot be applied to intrinsic type extension``() = 
        CompilerAssert.TypeCheckSingleError
            """
type Point = {x:int; y:int}

[<NoEquality>]
type Point with 
    member this.test = 42
            """
            FSharpErrorSeverity.Error
            3246
            (4, 1, 4, 15)
            "Attributes cannot be applied to type extensions."
