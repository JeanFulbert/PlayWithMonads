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

type Result<'value, 'error> =
| Success of 'value
| Failure of 'error

type Error =
| UnknownLogin
| MissingUser of string
| RestrictedPrivileges

let newToken () = Token <| Guid.NewGuid().ToString()

let adminToken = newToken ()

let stagiaireToken = newToken ()

let log login =
    match login with
    | "" -> Failure UnknownLogin
    | "admin" -> Success adminToken
    | _ -> Success <| newToken ()

let getUser token =
    if stagiaireToken = token
    then Failure <| MissingUser "stagiaire inconnu"
    else
        Success <|
            if adminToken = token
            then { name = "Jeannine" ; privileges = AllPrivileges }
            else { name = "Jean-Pierre" ; privileges = Restricted }

let getAllSalaries user =
    match user.privileges with
    | Restricted -> Failure RestrictedPrivileges
    | AllPrivileges ->
        Success <|
            [
                { name = "Gontrand" ; salary = 20000 }
                { name = "Huberte" ; salary = 25000 }
                { name = "Tchang-Yves" ; salary = 30000 }
                { name = "Rosa" ; salary = 35000 }
            ]