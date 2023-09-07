module Hw5.MaybeBuilder

open System

type MaybeBuilder() =
    member builder.Bind(a, f): Result<'e,'d> =
        (NotImplementedException() |> raise)
    member builder.Return x: Result<'a,'b> =
        (NotImplementedException() |> raise)
let maybe = MaybeBuilder()