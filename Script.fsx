let add1 x =  x + 1
let mult2 x = x * 2

let compose f g x = g (f x)
compose add1 mult2 5
5 |> compose add1 mult2

let (>>!) f g x = compose f g x
(>>!) add1 mult2 5
5 |> (>>!) add1 mult2
5 |> (add1 >>! mult2)

let add1Mult2 = add1 >>! mult2
5 |> add1Mult2