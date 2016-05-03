(* Useful and common operators for use within clicksco*)
 [<AutoOpen>]
module Clicksco.FSharp.Operators

/// Async Pipe
let (!>) x y = async.Bind (x, y >> async.Return)