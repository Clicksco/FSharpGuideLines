(* All standards are based on http://fsharp.org/specs/component-design-guidelines/
 Any common, ambigous or Clicksco specifc guidelines are exampled in this file*)
namespace Clicksco.FSharp.Standards

// Opening states should be in Alphabetical order
open System

(*
    Large comments or multi lined comments

    Follow the standard .net naming http://fsharp.org/specs/component-design-guidelines/#naming-conventions

    For casing follow: http://fsharp.org/specs/component-design-guidelines/#suggest-using-camelcase-for-class-bound-expression-bound-and-pattern-bound-values-and-functions

    Modules shold have RequireQualifiedAccess attribute

    The guide lines module is focused on how naming works.
*)
[<RequireQualifiedAccess>]
module GuideLines = 
    (*
        Default spacing is 4 
        Leave a space between each function/value
    *)

    // No underscores in funtion names: http://fsharp.org/specs/component-design-guidelines/#avoid-using-underscores-in-names
    let private underscore_function() = ()

    // Option types should be prefixed with Opt
    let private welcomeMessageOpt = Some "Hello Wold"
    
    /// XML domments are required on all public facing APIs and types.
    let publicValue() = ()
    
    // Functions that return options type should start with try/Try: http://fsharp.org/specs/component-design-guidelines/#consider-using-option-values-for-return-types-instead-of-raising-exceptions-for-f-facing-code
    let private tryShowWelcomeMessage() = 
        match welcomeMessageOpt with
        | None -> Console.WriteLine "No Welcome Message"
        | Some welcomeMessage -> Console.WriteLine welcomeMessage
    
    // Public F# functions that are explosed to C# should be camelCase and the CompiledNameAttribute being the PascalCase
    [<CompiledName("ShowMessage")>]
    let showMessage() = tryShowWelcomeMessage()

    let private ``Try to restrict functions names with backticks to tests and cases where clarity is important``() = ()
    
    // Discriminated Unions are should have RequireQualifiedAccess
    [<RequireQualifiedAccess>]
    /// Discriminated Unions are PascalCase
    type DU = 
        /// Each public case should be commented
        | Case1
        /// Cases with fields should be named
        | Case2 of age : int
        | ``Back ticks should be avoided for DU``
    
    // Make sure proper attributes are assigned to record types. This is set when the warning Level is 5
    [<NoEquality>]
    [<NoComparison>]
    /// Records Require public comments too
    type Record = 
        { /// Standard Member Comment
          Member1 : string
          /// Standard Function Comment
          Function1 : string -> string }

(*
    Usage module shows the prefered way of working with F#
*)
[<RequireQualifiedAccess>]
module Usage = 
    // When packing tuples avoid the use of ()
    let packedTuples = 1, 2, 3, "x"

    // When unpacking avoid the use ()
    let a, b, c, d = packedTuples
    
    // Make use of the pipe operator: http://fsharp.org/specs/component-design-guidelines/#do-place-pipeline-operator--at-the-start-of-a-line-when-writing-multi-line-pipeline-series
    let pipes = 
        [] // [] or List.empty is appropriate. Same for Arrays
        |> List.filter (fun _ -> true)
        |> List.map (fun f -> f * 2)
        |> List.map (fun f -> f * 4) // Avoid Multiple maps
        |> Array.ofList // When changing between list types, use the new type module to visually indicate this

