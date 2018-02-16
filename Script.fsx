open System

type Token = Token of string

type Privileges =
    | AllPrivileges
    | Restricted

type User = {
    name: string
    privileges: Privileges
}

type Employee = {
    name: string
    salary: int
}

type Maybe<'a> =
| Some of 'a
| None


let newToken () = Token <| Guid.NewGuid().ToString()

let adminToken = newToken ()

let stagiaireToken = newToken ()

let log login =
    match login with
    | "" -> None
    | "admin" -> Some adminToken
    | _ -> Some <| newToken ()

let getUser token =
    if stagiaireToken = token
    then None
    else
        Some (
            if adminToken = token
            then { name = "Jeannine" ; privileges = AllPrivileges }
            else { name = "Jean-Pierre" ; privileges = Restricted })

let getAllSalaries user =
    match user.privileges with
    | Restricted -> None
    | AllPrivileges ->
        Some (
            [
                { name = "Gontrand" ; salary = 20000 }
                { name = "Huberte" ; salary = 25000 }
                { name = "Tchang-Yves" ; salary = 30000 }
                { name = "Rosa" ; salary = 35000 }
            ])